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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            var label = new Label
            {
                Location = new Point(40, 40),
                Size = new Size(ClientSize.Width, 200),
                Text = "Ty 3.14dor",
                Font = new Font("Arial", 48, FontStyle.Bold)
                
            };
            Text = "Young Revolutioneer Game v. 1e-31 by two degenerates team";
            Controls.Add(label);
        }
    }
}
