using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class BattleScreen : IScreen
    {
        private Form form;
        private BattleModel model;

        public BattleScreen(CommanderPerson[] chosenComrades)
        {
            model = new BattleModel(this, chosenComrades);

            foreach (var e in chosenComrades)
                MessageBox.Show("Вы выбрали в команду следующего человека:\n " + e.DisplayName,
                    "Результат выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);

            model.StartGame();
        }

        public void Initialize(Form form)
        {
            this.form = form;
        }

        public void Draw()
        {
            form.BackgroundImage = Properties.Resources.BattleBg;
        }

        public void Clear()
        {
            form.BackgroundImage = default;
        }
    }
}
