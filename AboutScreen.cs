using System;
using System.Drawing;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    class AboutScreen : IScreen
    {
        private static Button backButton = new Button
        {
            Size = new Size(145, 40),
            Location = new Point(650, 522),
            Image = Properties.Resources.BackButton
        };

        private IScreen previousScreen;

        public AboutScreen(IScreen previousScreen)
        {
            this.previousScreen = previousScreen;
        }

        public void Initialize(Form form)
        {
            backButton.Click += (o, e) =>
            {
                Clear(form);
                previousScreen.Draw(form);
            };
        }

        public void Draw(Form form)
        {
            form.BackgroundImage = Properties.Resources.AboutScreenBg;
            form.Controls.Add(backButton);
        }

        public void Clear(Form form)
        {
            form.Controls.Remove(backButton);
            form.BackgroundImage = default;
        }
    }
}
