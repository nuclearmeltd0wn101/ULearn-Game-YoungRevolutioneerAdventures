using System;
using System.Collections.Generic;
using System.Linq;

namespace ulearn_game_YoungRevolutioneerGame
{
    public static class Spells
    {
        public enum OutcomeType
        {
            AlliesMood,
            FoesMood,
            Poaching,
            FoesDeath,
            AlliesDeath
        }

        public static SpellOutcome[] EvaluateOutcome(Spell spell)
        {
            var rand = new Random();
            return spell.PossibleOutcomes
                .SelectMany(x => rand.Next(100) <= x.PrimaryProbabilityPercentage ? x.Primary : x.Secondary)
                .Select(x => new SpellOutcome { Type = x.Type, Value = x.ValueMin + rand.Next(x.ValueMax - x.ValueMin) })
                .ToArray();
        }

        public static string OutcomeStringFormat(SpellOutcome outcome)
            => (outcome.Type) switch
            {
                OutcomeType.AlliesMood => (outcome.Value >= 0 ? "Подъем" : "Упадок")
                    + $" настроя союзников на {Math.Abs(outcome.Value)}%",
                OutcomeType.FoesMood => (outcome.Value >= 0 ? "Подъем" : "Упадок")
                    + $" настроя врагов на {Math.Abs(outcome.Value)}%",
                OutcomeType.Poaching => $"Переманено на свою сторону {outcome.Value} чел.",
                OutcomeType.FoesDeath => $"Смерть {outcome.Value} врагов",
                OutcomeType.AlliesDeath => $"Смерть {outcome.Value} союзников",
                _ => throw new NotSupportedException()
            };


        public static Spell LeninSpeech = new Spell
        {
            Name = "Воодушевляющая речь",
            PossibleOutcomes = new[]
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 90,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 4, ValueMax = 16 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = 5, ValueMax = 25 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesMood, ValueMin = -16, ValueMax = -4 }
                    },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMax = 5, ValueMin = -10 } }
                }
            }
        };

        public static Spell Bloodoath = new Spell
        {
            Name = "Бахнуть побоище",
            PossibleOutcomes = new[] 
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 80,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesDeath, ValueMin = 5, ValueMax = 20 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMin = 0, ValueMax = 5 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                    },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMax = 10, ValueMin = 5 } }
                }
            }
        };

        public static Spell Diversion = new Spell
        {
            Name = "Устроить диверсию",
            PossibleOutcomes = new[]
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 70,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesDeath, ValueMin = 10, ValueMax = 40 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesMood, ValueMin = -20, ValueMax = -10 },
                    },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMax = 5, ValueMin = 1 } }
                }
            }
        };

        public static Spell TerrAct = new Spell
        {
            Name = "Устроить терракт",
            PossibleOutcomes = new[]
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 60,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesDeath, ValueMin = 20, ValueMax = 50 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesMood, ValueMin = -30, ValueMax = -5 },
                    },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMax = 60, ValueMin = 5 } }
                }
            }
        };

        public static Spell MakeRally = new Spell
        {
            Name = "Призыв на мытенг",
            PossibleOutcomes = new[]
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 60,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 2, ValueMax = 8 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = 5, ValueMax = 15 },
                    },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMax = 5, ValueMin = 0 } }
                }
            }
        };
    }

    public class SpellPossibleOutcome
    {
        public Spells.OutcomeType Type;
        public int ValueMin;
        public int ValueMax;
    }

    public class SpellOutcome
    {
        public Spells.OutcomeType Type;
        public int Value;
    }


    public class OutcomeFork
    {
        public int PrimaryProbabilityPercentage;
        public SpellPossibleOutcome[] Primary;
        public SpellPossibleOutcome[] Secondary;
    }


    public class Spell
    {
        public string Name;
        public OutcomeFork[] PossibleOutcomes;
    }
}
