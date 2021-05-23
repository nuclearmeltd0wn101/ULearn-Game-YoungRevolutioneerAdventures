using System;
using System.Linq;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class BattleModel
    {
        const int DefaultTotalPeople = 123400;
        const int DefaultMoodPercentage = 50;

        public CommanderPerson[] AlliesCommanders => alliesCommanders.ToArray();
        public CommanderPerson[] FoesCommanders => foesCommanders.ToArray();
        public CommanderPerson ActiveCommander => activeCommander;

        public int AlliesPeople => alliesPeople;
        public int FoesPeople => foesPeople;
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
            screen.SelectSpell();
        }

        public void Step(Spell spell)
        {
            screen.CastedSpellInfo(activeCommander, spell);
            foreach (var e in Spells.EvaluateOutcome(spell))
            {
                switch (e.Type)
                {
                    case Spells.OutcomeType.AlliesMood:
                        if (commanderCount % 3 == 0)
                            alliesMood += e.Value;
                        else
                            foesMood += e.Value;
                        break;

                    case Spells.OutcomeType.FoesMood:
                        if (commanderCount % 3 == 1)
                            alliesMood += e.Value;
                        else
                            foesMood += e.Value;
                        break;

                    case Spells.OutcomeType.MurderAllies:
                        if (commanderCount % 3 == 0)
                            alliesPeople -= e.Value;
                        else
                            foesPeople -= e.Value;
                        break;

                    case Spells.OutcomeType.MurderFoes:
                        if (commanderCount % 3 == 1)
                            alliesPeople -= e.Value;
                        else
                            foesPeople -= e.Value;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }  
            }

            screen.UpdateTeamsStatus();
            commanderCount++;
            commanderCount %= 6;
            activeCommander = (commanderCount % 3 == 0)
                ? alliesCommanders[commanderCount % 3]
                : foesCommanders[commanderCount % 3];

            if (commanderCount % 3 == 0)
                screen.SelectSpell();
            else
                AIChooseFoeSpell();
        }

        private void AIChooseFoeSpell()
        {
            var spell = activeCommander.Spells.OrderBy(x => random.Next()).First(); // placeholder

            screen.CastedSpellInfo(activeCommander, spell);
            Step(spell);
        }
    }
}
