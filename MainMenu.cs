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
            Location = new Point(650, 520),
            Image = Properties.Resources.QuitButton,
            FlatStyle = FlatStyle.Flat
        };

        public void Initialize(Form form)
        {
            foreach (var button in new[] { newGameButton, aboutButton, quitButton })
                button.FlatAppearance.BorderSize = 0;

            var aboutScreen = new AboutScreen(this);
            aboutScreen.Initialize(form);

            aboutButton.Click += (o, e) =>
            {
                Clear(form);
                aboutScreen.Draw(form);    
            };
            quitButton.Click += (o, e) => form.Close();
        }

        public void Draw(Form form)
        {
            form.BackgroundImage = Properties.Resources.MainMenuBg;

            form.Controls.Add(newGameButton);
            form.Controls.Add(aboutButton);
            form.Controls.Add(quitButton);
        }

        public void Clear(Form form)
        {
            form.Controls.Remove(newGameButton);
            form.Controls.Remove(aboutButton);
            form.Controls.Remove(quitButton);
            form.BackgroundImage = default;
        }
    }
}