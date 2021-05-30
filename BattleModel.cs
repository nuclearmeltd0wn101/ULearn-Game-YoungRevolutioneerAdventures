using System;
using System.Collections.Generic;
using System.Linq;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class BattleModel
    {
        public const int DefaultTotalPeople = 12000;
        public const int DefaultMoodPercentage = 50;

        public CommanderPerson[] AlliesCommanders => alliesCommanders.ToArray();
        public CommanderPerson[] FoesCommanders => foesCommanders.ToArray();
        public CommanderPerson ActiveCommander => activeCommander;

        public int AlliesPeople => alliesPeople;
        public int FoesPeople => foesPeople;
        public int TotalPeople => alliesPeople + foesPeople;
        public int AlliesMood => alliesMood;
        public int FoesMood => foesMood;

        private BattleScreen screen;
        private Random random;
        private CommanderPerson[] alliesCommanders;
        private CommanderPerson[] foesCommanders;
        private int alliesPeople = DefaultTotalPeople / 2;
        private int foesPeople = DefaultTotalPeople / 2;
        private int alliesMood = DefaultMoodPercentage;
        private int foesMood = DefaultMoodPercentage;
        private CommanderPerson activeCommander;
        private int commanderCount = 0;

        public BattleModel(BattleScreen screen, CommanderPerson[] chosenComrades)
        {
            this.screen = screen;
            random = new Random();

            alliesCommanders = new[] { Commanders.MainProtag }.Concat(chosenComrades)
                .OrderBy(x => random.Next())
                .ToArray();
        }
        
        public void StartGame()
        {
            foesCommanders = Commanders.AllCommanders.Except(alliesCommanders).OrderBy(x => random.Next())
                .Take(3)
                .ToArray();

            activeCommander = alliesCommanders[0];
            screen.UpdateTeamsStatus();
            screen.UpdateMoveLabel();
            screen.SelectSpell();
        }

        public void Step(Spell spell)
        {
            var outcomesNotModeled = Spells.EvaluateOutcome(spell);
            var outcomes = new List<SpellOutcome>();
            foreach (var e in outcomesNotModeled)
            {
                switch (e.Type)
                {
                    case Spells.OutcomeType.AlliesMood:
                        if (commanderCount / 3 == 0)
                            alliesMood += e.Value;
                        else
                            foesMood += e.Value;
                        break;

                    case Spells.OutcomeType.FoesMood:
                        if (commanderCount / 3 == 1)
                            alliesMood += e.Value;
                        else
                            foesMood += e.Value;
                        
                        break;

                    case Spells.OutcomeType.AlliesDeath:
                        if (commanderCount / 3 == 0)
                            alliesPeople -= e.Value *= foesMood;
                        else
                            foesPeople -= e.Value *= alliesMood;
                        break;

                    case Spells.OutcomeType.FoesDeath:
                        if (commanderCount / 3 == 1)
                            alliesPeople -= e.Value *= foesMood;
                        else
                            foesPeople -= e.Value *= alliesMood;
                        break;

                    case Spells.OutcomeType.Poaching:
                        if ((commanderCount / 3 == 1) ^ (e.Value < 0))
                            e.Value *= -foesMood;
                        else
                            e.Value *= alliesMood;

                        alliesPeople += e.Value;
                        foesPeople -= e.Value;
                        e.Value = Math.Abs(e.Value);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                outcomes.Add(new SpellOutcome { Type = e.Type, Value = e.Value });
            }

            alliesMood = Math.Max(0, Math.Min(alliesMood, 100));
            foesMood = Math.Max(0, Math.Min(foesMood, 100));
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
            => activeCommander.Spells.OrderBy(x => random.Next()).First();
    }
}
