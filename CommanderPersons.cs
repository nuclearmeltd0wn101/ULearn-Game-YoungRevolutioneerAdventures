using System.Drawing;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class CommanderPerson
    {
        public string DisplayName;
        public Spell[] Spells;
        public Image SelectorViewDetailsImage;
    }

    public static class Commanders
    {
        public static readonly CommanderPerson MainProtag = new CommanderPerson
        {
            DisplayName = "В. И. Ленин",
            SelectorViewDetailsImage = null,
            Spells = new[] {
                new Spell
                {
                    Name = "Воодушевляющая речь",
                    PossibleOutcomes = new [] {
                        new OutcomeFork
                        {
                            PrimaryProbabilityPercentage = 70,
                            Primary = new[]
                            {
                                new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 1, ValueMax = 10 },
                                new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = 10, ValueMax = 40 },
                                new SpellPossibleOutcome { Type = Spells.OutcomeType.FoesMood, ValueMin = -40, ValueMax = -10 }
                            },
                            Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMax = 5, ValueMin = -5 } }
                        }
                    }
                },

                new Spell
                {
                    Name = "Бахнуть побоище",
                    PossibleOutcomes = new [] {
                        new OutcomeFork
                        {
                            PrimaryProbabilityPercentage = 60,
                            Primary = new[]
                            {
                                new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                            },
                            Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                        }
                    }
                },
            }
        };

        public static readonly CommanderPerson[] AllCommanders = new[]
        {
            new CommanderPerson
            {
                DisplayName = "А. С. Мартынов",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageMartynov,
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    },
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    }
                }
            },

            new CommanderPerson
            {
                DisplayName = "Г. И. Сафаров",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSafarov,
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    },
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    }
                }

            },

            new CommanderPerson
            {
                DisplayName = "Б. В. Савинков",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSavinkov,
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    },
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    }
                }
            },

            new CommanderPerson
            {
                DisplayName = "Н. Н. Суханов",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSukhanov,
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    },
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    }
                }
            },

            new CommanderPerson
            {
                DisplayName = "Г. Е. Зиновьев",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageZinovyev,
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Призыв на мытенг",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 55,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.Poaching, ValueMin = 2, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = 10, ValueMax = 40 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 5, ValueMin = 0 } }
                            }
                        }
                    },
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    }
                }
            },

            new CommanderPerson
            {
                DisplayName = "Ф. Е. Каплан",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageKaplan,
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    },
                    new Spell
                    {
                        Name = "Бахнуть побоище",
                        PossibleOutcomes = new [] {
                            new OutcomeFork
                            {
                                PrimaryProbabilityPercentage = 60,
                                Primary = new[]
                                {
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderFoes, ValueMin = 5, ValueMax = 20 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMin = 0, ValueMax = 5 },
                                    new SpellPossibleOutcome { Type = Spells.OutcomeType.AlliesMood, ValueMin = -5, ValueMax = 5 },
                                },
                                Secondary = new[] { new SpellPossibleOutcome { Type = Spells.OutcomeType.MurderAllies, ValueMax = 10, ValueMin = 1 } }
                            }
                        }
                    }
                }
            }
        };
    }
}
