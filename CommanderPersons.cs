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
            Spells = new[] {
                new Spell
                {
                    Name = "Воодушевляющая речь",
                    PossibleOutcomes = new [] {
                        new OutcomeFork
                        {
                            PrimaryProbabilityPercentage = 90,
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
                            PrimaryProbabilityPercentage = 90,
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
            },
            SelectorViewDetailsImage = null
        };

        public static readonly CommanderPerson[] AllCommanders = new[]
        {
            new CommanderPerson
            {
                DisplayName = "А. С. Мартынов",
                Spells = null,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageMartynov
            },

            new CommanderPerson
            {
                DisplayName = "Г. И. Сафаров",
                Spells = null,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSafarov
            },

            new CommanderPerson
            {
                DisplayName = "Б. В. Савинков",
                Spells = null,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSavinkov
            },

            new CommanderPerson
            {
                DisplayName = "Н. Н. Суханов",
                Spells = null,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSukhanov
            },

            new CommanderPerson
            {
                DisplayName = "Г. Е. Зиновьев",
                Spells = null,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageZinovyev
            },

            new CommanderPerson
            {
                DisplayName = "Ф. Е. Каплан",
                Spells = null,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageKaplan
            }
        };
    }
}
