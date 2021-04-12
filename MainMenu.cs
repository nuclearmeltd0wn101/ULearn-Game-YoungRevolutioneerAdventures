using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public partial class MainMenu : Form
    {
        private static FormClosingEventHandler CloseConfirmation
            = new FormClosingEventHandler((o, e) => e.Cancel 
                = DialogResult.No == MessageBox.Show("Текст", "Ладно", MessageBoxButtons.YesNo));

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

        public MainMenu()
        {
            //InitializeComponent();
            
            Size = new Size(814, 600);
            BackgroundImage = Properties.Resources.mainMenuBg;
            Text = "Young Revolutioneer Game v. 1e-31 by two degenerates team, where only one is actually works";

            quitButton.Click += (o, e) => Close();
            FormClosing += CloseConfirmation;

            Controls.Add(newGameButton);
            Controls.Add(aboutButton);
            Controls.Add(quitButton);

            aboutButton.Click += (o, e) => DisposeMenu();
        }
        public void DisposeMenu()
        {
            quitButton.Click -= (o, e) => Close();
            FormClosing -= CloseConfirmation;
            Controls.Remove(newGameButton);
            Controls.Remove(aboutButton);
            Controls.Remove(quitButton);
            BackgroundImage = default;
        }
    }

    interface IScreen
    {
        void Draw(Form form);
        void Clear(Form form);
    }
}
