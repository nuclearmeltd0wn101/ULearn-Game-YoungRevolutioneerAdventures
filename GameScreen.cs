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
            Size = new Size(800, 600);
            Text = "Young Revolutioneer Game v. 1e-31 by two degenerates team, where only one is actually works";
            
            FormClosing += CloseConfirmation;

            // lock screen size
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            screen.Initialize(this);
            screen.Draw(this);
        }
    }

    public interface IScreen
    {
        void Initialize(Form form);
        void Draw(Form form);
        void Clear(Form form);
    }
}
