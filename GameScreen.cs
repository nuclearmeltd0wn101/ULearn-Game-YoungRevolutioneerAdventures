using System.Drawing;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public partial class GameScreen : Form
    {
        private static FormClosingEventHandler CloseConfirmation
            = new FormClosingEventHandler((o, e) => e.Cancel 
                = DialogResult.No == MessageBox.Show("Текст", "Ладно", MessageBoxButtons.YesNo));
        public GameScreen(IScreen screen)
        {
            InitializeComponent();

            DoubleBuffered = true;
            Size = new Size(814, 600);
            Text = "Young Revolutioneer Game v0.2 by TwOdEgEnErAtEsTeAm, where only one actually works";
            
            FormClosing += CloseConfirmation;

            // lock screen size
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            screen.Initialize(this);
            screen.Draw();
        }
    }

    public interface IScreen
    {
        void Initialize(Form form);
        void Draw();
        void Clear();
    }
}
