using System;
using System.Drawing;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class MainMenu : IScreen
    {
        private static Button newGameButton = new Button
        {
            Text = "Новая игра",
            Size = new Size(196, 40),
            Location = new Point(473, 283)
        };

        private static Button aboutButton = new Button
        {
            Text = "Об игре",
            Size = new Size(196, 40),
            Location = new Point(473, 364)
        };

        private static Button quitButton = new Button
        {
            Text = "Вiйди отсюда, розбiйник",
            Size = new Size(124, 34),
            Location = new Point(671, 471)
        };

        public void Draw(Form form)
        {
            form.BackgroundImage = Properties.Resources.mainMenuBg;

            form.Controls.Add(newGameButton);
            form.Controls.Add(aboutButton);
            form.Controls.Add(quitButton);

            aboutButton.Click += (o, e) => Clear(form);
            quitButton.Click += (o, e) => form.Close();
        }

        public void Clear(Form form)
        {
            quitButton.Click -= (o, e) => form.Close();
            form.Controls.Remove(newGameButton);
            form.Controls.Remove(aboutButton);
            form.Controls.Remove(quitButton);
            form.BackgroundImage = default;
        }
    }
}