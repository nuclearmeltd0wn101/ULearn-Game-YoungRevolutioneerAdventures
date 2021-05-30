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
                Spells.LeninSpeech,
                Spells.PublishMagazine
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
                    Spells.PublishMagazine,
                    Spells.Bloodoath
                }
            },

            new CommanderPerson
            {
                DisplayName = "Г. И. Сафаров",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSafarov,
                Spells = new[]
                {
                    Spells.MakeRally,
                    Spells.Bloodoath
                }

            },

            new CommanderPerson
            {
                DisplayName = "Б. В. Савинков",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSavinkov,
                Spells = new[]
                {
                    Spells.Bloodoath,
                    Spells.TerrAct
                }
            },

            new CommanderPerson
            {
                DisplayName = "Н. Н. Суханов",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSukhanov,
                Spells = new[]
                {
                    Spells.MoneyPoaching,
                    Spells.Bloodoath
                }
            },

            new CommanderPerson
            {
                DisplayName = "Г. Е. Зиновьев",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageZinovyev,
                Spells = new[]
                {
                    Spells.MakeRally,
                    Spells.PublishMagazine
                }
            },

            new CommanderPerson
            {
                DisplayName = "Ф. Е. Каплан",
                SelectorViewDetailsImage = Properties.Resources.DetailsImageKaplan,
                Spells = new[]
                {
                    Spells.Diversion,
                    Spells.Bloodoath
                }
            }
        };
    }
}
