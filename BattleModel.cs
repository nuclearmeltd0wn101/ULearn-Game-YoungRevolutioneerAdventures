using System;
using System.Linq;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class BattleModel
    {
        const int DefaultTotalPeople = 123400;

        public int TotalPeople => totalPeople;
        public int AlliesPeople => alliesPeople;
        public int FoesPeople => foesPeople;
        public CommanderPerson ActiveCommander => activeCommander;

        private BattleScreen screen;
        private Random random;
        private CommanderPerson[] ourTeamCommanders;
        private CommanderPerson[] enemiesCommanders;
        private int totalPeople;
        private int alliesPeople;
        private int foesPeople;
        private CommanderPerson activeCommander;
        

        public BattleModel(BattleScreen screen, CommanderPerson[] chosenComrades)
        {
            this.screen = screen;
            random = new Random();

            ourTeamCommanders = new[] { Commanders.MainProtag }.Concat(chosenComrades).ToArray();
        }
        
        public void StartGame()
        {
            enemiesCommanders = Commanders.EnemiesAllCommanders.OrderBy(x => random.Next())
                .Take(3)
                .ToArray();

            totalPeople = DefaultTotalPeople;
            alliesPeople = foesPeople = DefaultTotalPeople / 2;
        }
    }
}
