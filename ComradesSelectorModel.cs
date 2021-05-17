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

        public FinishChoices Choose(CommanderPerson option)
        {
            chosenPeople.Add(option);

            return NewChoice();
        }

        private FinishChoices NewChoice()
        {
            var currentOptions = leftOptions.Take(3)
                .ToArray();
            leftOptions = leftOptions.Except(currentOptions)
                .ToArray();

            if (currentOptions.Length == 0)
                return FinishChoices.Yes;

            view.LoadCurrentOptions(currentOptions);
            return FinishChoices.No;
        }

    }
}
