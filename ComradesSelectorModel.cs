using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    class ComradesSelectorModel
    {
        private ComradesSelectorScreen view;
        private CommanderPerson[] currentOptions;

        public ComradesSelectorModel(ComradesSelectorScreen view)
        {
            this.view = view;

            currentOptions = Commanders.ComradesCommanders
                .Skip(Commanders.ComradesCommanders.Length - 3)
                .ToArray();

            view.LoadComradeDetails(currentOptions
                .Select(x => x.SelectorViewDetailsImage)
                .ToArray());
        }

        public ComradeSelectorAction Choose(int num)
        {
            MessageBox.Show(
                "Вы выбрали в команду следующего человека:\n " 
                + currentOptions[num].DisplayName, 
                
                "Вы выбрали чела",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return ComradeSelectorAction.RefreshOptions;
        }

    }
}
