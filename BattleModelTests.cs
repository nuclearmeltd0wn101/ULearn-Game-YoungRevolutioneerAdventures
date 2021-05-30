using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ulearn_game_YoungRevolutioneerGame
{
    [TestFixture]
    class BattleModelTests
    {
        [Test]
        public void TestTeamsFormation()
        {
            var rand = new Random();
            var replayValues = new List<int> { 0, 2, 1 };
            var comrades = Commanders.AllCommanders
                .OrderBy(x => rand.Next())
                .Take(2)
                .ToArray();

            var comradesWithLenin = comrades.Append(Commanders.MainProtag)
                .ToArray();

            var model = new BattleModel(null, comrades, new ReplayingRandom(replayValues));

            for (var i = 0; i < comradesWithLenin.Length; i++)
                Assert.AreEqual(comradesWithLenin[i], model.AlliesCommanders[2 - i]);
        }
    }
}
