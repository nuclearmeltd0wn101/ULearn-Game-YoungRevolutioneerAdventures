using System.Drawing;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public partial class GameScreen : Form
    {
        public static bool CloseConfirmation = true;
        public GameScreen(IScreen screen)
        {
            InitializeComponent();

            DoubleBuffered = true;
            Size = new Size(814, 600);
            Text = "Young Revolutioneer Game v0.4 by TwoDegeneratesTeam, where only one actually works";
            
            // add disablable game close confirmation
            FormClosing += new FormClosingEventHandler((o, e) => e.Cancel = CloseConfirmation 
                && DialogResult.No == MessageBox.Show("Текст (Выйти?)", "Ладно", MessageBoxButtons.YesNo));

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
