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
            Location = new Point(654, 522),
            Image = Properties.Resources.BackButton,
            FlatStyle = FlatStyle.Flat
        };

        private Form form;
        private IScreen previousScreen;

        public AboutScreen(IScreen previousScreen)
        {
            backButton.FlatAppearance.BorderSize = 0;
            this.previousScreen = previousScreen;
        }

        public void Initialize(Form form)
        {
            this.form = form;
            backButton.Click += (o, e) =>
            {
                Clear();
                previousScreen.Draw();
            };
        }

        public void Draw()
        {
            form.BackgroundImage = Properties.Resources.AboutScreenBg;
            form.Controls.Add(backButton);
        }

        public void Clear()
        {
            form.Controls.Remove(backButton);
            form.BackgroundImage = default;
        }
    }
}
