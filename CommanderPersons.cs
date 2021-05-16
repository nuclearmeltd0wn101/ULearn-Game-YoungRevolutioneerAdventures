using System.Drawing;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class CommanderPerson
    {
        public string DisplayName;
        public double ImposterousnessCoefficient;
        public Image SelectorViewDetailsImage;
    }

    public static class Commanders
    {
        public static readonly CommanderPerson[] ComradesCommanders = new[]
        {
            new CommanderPerson
            {
                DisplayName = "А. С. Мартынов",
                ImposterousnessCoefficient = 0.2,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageMartynov
            },

            new CommanderPerson
            {
                DisplayName = "Г. И. Сафаров",
                ImposterousnessCoefficient = 0.1,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSafarov
            },

            new CommanderPerson
            {
                DisplayName = "Б. В. Савинков",
                ImposterousnessCoefficient = 0.8,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSavinkov
            },

            new CommanderPerson
            {
                DisplayName = "Н. Н. Суханов",
                ImposterousnessCoefficient = 0.05,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageSukhanov
            },

            new CommanderPerson
            {
                DisplayName = "Г. Е. Зиновьев",
                ImposterousnessCoefficient = 0.01,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageZinovyev
            },

            new CommanderPerson
            {
                DisplayName = "Ф. Е. Каплан",
                ImposterousnessCoefficient = 0.99,
                SelectorViewDetailsImage = Properties.Resources.DetailsImageKaplan
            }

        };
    }
}
