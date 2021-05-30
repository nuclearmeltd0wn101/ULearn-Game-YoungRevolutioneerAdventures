using System.Collections.Generic;
using NUnit.Framework;
using System.Text;

namespace ulearn_game_YoungRevolutioneerGame
{
    [TestFixture]
    class SpellsTests
    {
        private static Spell forkTestSpell = new Spell
        {
            PossibleOutcomes = new[]
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 10,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 10, ValueMax = 70 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = 1, ValueMax = 16 },
                    },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMax = 2, ValueMin = -5 } }
                }
            }
        };

        private static Spell multipleForksTestSpell = new Spell
        {
            PossibleOutcomes = new[]
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 50,
                    Primary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 1, ValueMax = 1 } },
                    Secondary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMax = 2, ValueMin = 2 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesMood, ValueMax = 8, ValueMin = 8 }
                    }
                },
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 12,
                    Primary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesDeath, ValueMin = 4, ValueMax = 4 } },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMax = 3, ValueMin = 3 } }
                }
            }
        };

        [TestCase]
        public void TestPrimaryOutcomeChoose()
        {
            var replayValues = new List<int> { 0, 10, 10 };
            var expected = new[]
            {
                new SpellOutcome { Type = Spells.OutcomeType.Poaching, Value = 20 },
                new SpellOutcome { Type = Spells.OutcomeType.AlliesMood, Value = 11}
            };

            EvaluateOutcomeTest(forkTestSpell, replayValues, expected);
        }

        [TestCase]
        public void TestMarginalValueIsForPrimaryOutcomeChoose()
        {
            var replayValues = new List<int> { 10, 10, 10 };
            var expected = new[]
            {
                new SpellOutcome { Type = Spells.OutcomeType.Poaching, Value = 20 },
                new SpellOutcome { Type = Spells.OutcomeType.AlliesMood, Value = 11}
            };

            EvaluateOutcomeTest(forkTestSpell, replayValues, expected);
        }

        [TestCase]
        public void TestSecondaryOutcomeChoose()
        {
            var replayValues = new List<int> { 100, 3 };
            var expected = new[]
            {
                new SpellOutcome { Type = Spells.OutcomeType.AlliesMood, Value = -2 }
            };

            EvaluateOutcomeTest(forkTestSpell, replayValues, expected);
        }

        [TestCase]
        public void TestMultipleForksChoose()
        {
            var replayValues = new List<int> { 60, 0, 0, 5, 0 };
            // first it takes percentage for fork and then shift value for each spell outcome value
            // for each spell in fork, and then and then
            var expected = new[]
            {
                new SpellOutcome { Type = Spells.OutcomeType.AlliesMood, Value = 2 },
                new SpellOutcome { Type = Spells.OutcomeType.FoesMood, Value = 8 },
                new SpellOutcome { Type = Spells.OutcomeType.FoesDeath, Value = 4 }
            };

            EvaluateOutcomeTest(multipleForksTestSpell, replayValues, expected);
        }

        public void EvaluateOutcomeTest(Spell spell, List<int> randomReplayValues, SpellOutcome[] expected)
        {
            var actual = Spells.EvaluateOutcome(new ReplayingRandom(randomReplayValues), spell);
            Assert.AreEqual(expected.Length, actual.Length);

            for (var i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i].Type, actual[i].Type);
                Assert.AreEqual(expected[i].Value, actual[i].Value);
            }
        }
    }
}
