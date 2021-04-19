using System;
using System.Drawing;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class MainMenu : IScreen
    {
        private static Button newGameButton = new Button
        {
            Size = new Size(200, 40),
            Location = new Point(473, 283),
            Image = Properties.Resources.NewGameButton,
            FlatStyle = FlatStyle.Flat
        };

        private static Button aboutButton = new Button
        {
            Size = new Size(200, 40),
            Location = new Point(473, 364),
            Image = Properties.Resources.AboutButton,
            FlatStyle = FlatStyle.Flat

        };

        private static Button quitButton = new Button
        {
            Size = new Size(125, 30),
            Location = new Point(654, 520),
            Image = Properties.Resources.QuitButton,
            FlatStyle = FlatStyle.Flat
        };

        private Form form;

        public void Initialize(Form form)
        {
            foreach (var button in new[] { newGameButton, aboutButton, quitButton })
                button.FlatAppearance.BorderSize = 0;

            this.form = form;

            var aboutScreen = new AboutScreen(this);
            aboutScreen.Initialize(form);

            aboutButton.Click += (o, e) =>
            {
                Clear();
                aboutScreen.Draw();    
            };
            quitButton.Click += (o, e) => form.Close();

            newGameButton.Click += (o, e) =>
            {
                var cs = new ComradesSelector();
                cs.Initialize(form);
                Clear();
                cs.Draw();
            };
        }

        public void Draw()
        {
            form.BackgroundImage = Properties.Resources.MainMenuBg;

            form.Controls.Add(newGameButton);
            form.Controls.Add(aboutButton);
            form.Controls.Add(quitButton);
        }

        public void Clear()
        {
            form.Controls.Remove(newGameButton);
            form.Controls.Remove(aboutButton);
            form.Controls.Remove(quitButton);
            form.BackgroundImage = default;
        }
    }
}