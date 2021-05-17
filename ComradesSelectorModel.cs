using System;
using System.Collections.Generic;
using System.Linq;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class ComradesSelectorModel
    {
        public CommanderPerson[] GetChoices => chosenPeople.ToArray();
        
        private ComradesSelectorScreen view;
        private List<CommanderPerson> chosenPeople = new List<CommanderPerson>();
        private CommanderPerson[] leftOptions;

        public ComradesSelectorModel(ComradesSelectorScreen view)
        {
            this.view = view;
            var rand = new Random();

            leftOptions = Commanders.ComradesAllCommanders.OrderBy(x => rand.Next())
                .ToArray();

            StartSelection();
        }

        public FinishSelection Choose(CommanderPerson option)
        {
            chosenPeople.Add(option);
            return StartSelection();
        }

        private FinishSelection StartSelection()
        {
            var currentOptions = leftOptions.Take(3)
                .ToArray();
            leftOptions = leftOptions.Except(currentOptions)
                .ToArray();

            if (currentOptions.Length == 0)
                return FinishSelection.Yes;

            view.LoadCurrentOptions(currentOptions);
            return FinishSelection.No;
        }
    }
}
