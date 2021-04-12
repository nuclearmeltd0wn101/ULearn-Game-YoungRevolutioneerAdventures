using System.Drawing;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public partial class GameScreen : Form
    {
        private static FormClosingEventHandler CloseConfirmation
            = new FormClosingEventHandler((o, e) => e.Cancel 
                = DialogResult.No == MessageBox.Show("Текст", "Ладно", MessageBoxButtons.YesNo));
        public GameScreen()
        {
            InitializeComponent();
            
            Size = new Size(814, 600);
            Text = "Young Revolutioneer Game v. 1e-31 by two degenerates team, where only one is actually works";
            
            FormClosing += CloseConfirmation;

            var menu = new MainMenu();
            menu.Draw(this);
        }
    }

    public interface IScreen
    {
        void Draw(Form form);
        void Clear(Form form);
    }
}
