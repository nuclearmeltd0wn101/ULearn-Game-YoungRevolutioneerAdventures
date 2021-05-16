using System;
using System.Collections.Generic;
using System.Linq;

namespace ulearn_game_YoungRevolutioneerGame
{
    class ComradesSelectorModel
    {
        public CommanderPerson[] GetChoices => chosenPeople.ToArray();
        
        private ComradesSelectorScreen view;
        private List<CommanderPerson> chosenPeople = new List<CommanderPerson>();
        private CommanderPerson[] leftOptions;

        public ComradesSelectorModel(ComradesSelectorScreen view)
        {
            this.view = view;
            var rand = new Random();

            leftOptions = Commanders.ComradesCommanders.OrderBy(x => rand.Next())
                .ToArray();

            NewChoice();
        }

        public AfterPersonSelect Choose(CommanderPerson option)
        {
            chosenPeople.Add(option);

            return NewChoice();
        }

        private AfterPersonSelect NewChoice()
        {
            var currentOptions = leftOptions.Take(3)
                .ToArray();

            leftOptions = leftOptions.Except(currentOptions).ToArray();

            if (currentOptions.Length == 0)
                return AfterPersonSelect.Finish;

            view.LoadCurrentOptions(currentOptions);
            return AfterPersonSelect.NextChoice;
        }

    }
}
