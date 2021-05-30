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

        public static SpellOutcome[] EvaluateOutcome(IRandom rand, Spell spell)
        => spell.PossibleOutcomes
                .SelectMany(x => rand.Next(100) <= x.PrimaryProbabilityPercentage ? x.Primary : x.Secondary)
                .Select(x => new SpellOutcome { Type = x.Type, Value = x.ValueMin + rand.Next(x.ValueMax - x.ValueMin) })
                .ToArray();

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
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 10, ValueMax = 70 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = 1, ValueMax = 16 },
                    },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMax = 2, ValueMin = -5 } }
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
                    PrimaryProbabilityPercentage = 50,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 3, ValueMax = 35 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = 5, ValueMax = 15 },
                    },
                    Secondary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 15, ValueMax = 40 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMin = 0, ValueMax = 3 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -6, ValueMax = -3 },
                    }
                }
            }
        };

        public static Spell PublishMagazine = new Spell
        {
            Name = "Выпустить газету",
            PossibleOutcomes = new[]
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 80,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 10, ValueMax = 40 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = 3, ValueMax = 9 },
                    },
                    Secondary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 5, ValueMax = 20 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMin = 0, ValueMax = 1 },
                    }
                }
            }
        };

        public static Spell MoneyPoaching = new Spell
        {
            Name = "Раздача на спавне",
            PossibleOutcomes = new[]
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 70,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 10, ValueMax = 25 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = 0, ValueMax = 2 },
                    },
                    Secondary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = -35, ValueMax = 5 },
                    }
                }
            }
        };

        public static Spell Bloodoath = new Spell
        {
            Name = "Стачка",
            PossibleOutcomes = new[] 
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 60,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesDeath, ValueMin = 4, ValueMax = 15 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMin = 0, ValueMax = 12 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -8, ValueMax = 2 },
                    },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMin = 7, ValueMax = 20 } }
                }
            }
        };

        public static Spell Diversion = new Spell
        {
            Name = "Диверсия",
            PossibleOutcomes = new[]
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 30,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesDeath, ValueMin = 2, ValueMax = 25 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesMood, ValueMin = -8, ValueMax = -2 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -4, ValueMax = -2 },
                    },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMin = 4, ValueMax = 16 } }
                }
            }
        };

        public static Spell TerrAct = new Spell
        {
            Name = "Терроризм",
            PossibleOutcomes = new[]
            {
                new OutcomeFork
                {
                    PrimaryProbabilityPercentage = 20,
                    Primary = new[]
                    {
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesDeath, ValueMin = 5, ValueMax = 15 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesMood, ValueMin = -20, ValueMax = -5 },
                        new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -4, ValueMax = -2 }
                    },
                    Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesDeath, ValueMin = 5, ValueMax = 30 } }
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
