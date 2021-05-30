using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NUnit.Framework;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class HollowBattleScreen : IBattleScreen
    {
        public void UpdateMoveLabel()
        {
        }

        public void SelectSpell()
        {
        }

        public void CastedSpellInfo(CommanderPerson commander, Spell spell, SpellOutcome[] outcomes)
        {
        }

        public void UpdateTeamsStatus()
        {
        }

        public void Initialize(Form form)
        {
        }

        public void Draw()
        {
        }

        public void Clear()
        {
        }
    }

    [TestFixture]
    class BattleModelTests
    {
        [Test]
        public void TestTeamsFormation()
        {
            var rand = new Random();
            var replayValues = new List<int> { 0, 2, 1, 0, 2, 1, 2 };
            var comrades = Commanders.AllCommanders
                .OrderBy(x => rand.Next())
                .Take(2)
                .ToArray();

            var comradesWithLenin = comrades.Append(Commanders.MainProtag)
                .ToArray();

            var model = new BattleModel(new HollowBattleScreen(), comrades, new ReplayingRandom(replayValues));

            for (var i = 0; i < comradesWithLenin.Length; i++)
                Assert.AreEqual(comradesWithLenin[i], model.AlliesCommanders[2 - i]);

            model.StartGame();
            var foesChooseRange = Commanders.AllCommanders.Except(comradesWithLenin);

            foreach (var e in model.FoesCommanders)
                Assert.AreEqual(true, foesChooseRange.Contains(e));
        }
    }
}