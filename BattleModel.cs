using System;
using System.Collections.Generic;
using System.Linq;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class BattleModel
    {
        public const int DefaultTotalPeople = 16000;
        public const double AlliesRatioCoefficient = 0.02;
        public const int DefaultMoodPercentage = 50;

        public CommanderPerson[] AlliesCommanders => alliesCommanders.ToArray();
        public CommanderPerson[] FoesCommanders => foesCommanders.ToArray();
        public CommanderPerson ActiveCommander => activeCommander;

        public int AlliesPeople => alliesPeople;
        public int FoesPeople => foesPeople;
        public int TotalPeople => alliesPeople + foesPeople;
        public int AlliesMood => alliesMood;
        public int FoesMood => foesMood;

        private IBattleScreen screen;
        private CommanderPerson[] alliesCommanders;
        private CommanderPerson[] foesCommanders;
        private int alliesPeople = (int)Math.Ceiling(DefaultTotalPeople * AlliesRatioCoefficient);
        private int foesPeople = (int)Math.Floor(DefaultTotalPeople * (1 - AlliesRatioCoefficient));
        private int alliesMood = DefaultMoodPercentage;
        private int foesMood = DefaultMoodPercentage;
        private CommanderPerson activeCommander;
        private int commanderCount = 0;
        private IRandom rand;

        public BattleModel(IBattleScreen screen, CommanderPerson[] chosenComrades, IRandom random)
        {
            this.screen = screen;
            rand = random;

            alliesCommanders = new[] { Commanders.MainProtag }.Concat(chosenComrades)
                .OrderBy(x => rand.Next())
                .ToArray();
        }
        
        public void StartGame()
        {
            foesCommanders = Commanders.AllCommanders.Except(alliesCommanders).OrderBy(x => rand.Next())
                .Take(3)
                .ToArray();

            activeCommander = alliesCommanders[0];
            screen.UpdateTeamsStatus();
            screen.UpdateMoveLabel();
            screen.SelectSpell();
        }

        public void Step(Spell spell)
        {
            var outcomesNotModeled = Spells.EvaluateOutcome(rand, spell);
            var outcomes = new List<SpellOutcome>();
            var alliesMoodAlteration = 0;
            var foesMoodAlteration = 0;
            foreach (var e in outcomesNotModeled)
            {
                switch (e.Type)
                {
                    case Spells.OutcomeType.AlliesMood:
                        if (commanderCount / 3 == 0) // if ally
                            alliesMoodAlteration += e.Value;
                        else
                            foesMoodAlteration += e.Value;
                        break;

                    case Spells.OutcomeType.FoesMood:
                        if (commanderCount / 3 == 1)  // if foe
                            alliesMoodAlteration += e.Value;
                        else
                            foesMoodAlteration += e.Value;
                        
                        break;

                    case Spells.OutcomeType.AlliesDeath:
                        if (commanderCount / 3 == 0) // if ally
                            alliesPeople -= e.Value *= foesMood;
                        else
                            foesPeople -= e.Value *= alliesMood;
                        break;

                    case Spells.OutcomeType.FoesDeath:
                        if (commanderCount / 3 == 1) // if foe
                            alliesPeople -= e.Value *= (int) Math.Ceiling(foesMood * 0.4);
                        else
                            foesPeople -= e.Value *= (int)Math.Ceiling(alliesMood * 0.4);
                        break;

                    case Spells.OutcomeType.Poaching:
                        // foe or negative poaching needs people transmission inverse,
                        // both occasions at the same time needs nothing
                        if ((commanderCount / 3 == 1) ^ (e.Value < 0))
                            e.Value *= (int)Math.Ceiling(foesMood * -0.4);
                        else
                            e.Value *= (int)Math.Ceiling(alliesMood * 0.4);

                        alliesPeople += e.Value;
                        foesPeople -= e.Value;
                        e.Value = Math.Abs(e.Value);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                outcomes.Add(new SpellOutcome { Type = e.Type, Value = e.Value });
            }

            alliesMood = Math.Max(0, Math.Min(alliesMood + alliesMoodAlteration, 100));
            foesMood = Math.Max(0, Math.Min(foesMood + foesMoodAlteration, 100));
            alliesPeople = Math.Max(alliesPeople, 0);
            foesPeople = Math.Max(foesPeople, 0);

            screen.CastedSpellInfo(activeCommander, spell, outcomes.ToArray());
            screen.UpdateTeamsStatus();

            if (alliesPeople * foesPeople == 0)
                return;

            commanderCount = (commanderCount + 1) % 6;
            activeCommander = (commanderCount / 3 == 0)
                ? alliesCommanders[commanderCount]
                : foesCommanders[commanderCount - 3];

            screen.UpdateMoveLabel();

            if (commanderCount / 3 == 0)
                screen.SelectSpell();
            else
                Step(AIChooseFoeSpell(activeCommander));
        }

        // здесь мог быть нормальный алгоритм ИИ, но что-то пошло не так
        private Spell AIChooseFoeSpell(CommanderPerson activeCommander)
            => activeCommander.Spells.OrderBy(x => rand.Next()).First();
    }
}
