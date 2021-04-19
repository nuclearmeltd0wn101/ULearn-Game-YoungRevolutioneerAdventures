using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class ComradesSelector : IScreen
    {
        Form form;
        public void Clear()
        {
            form.BackgroundImage = default;
        }

        public void Draw()
        {
            form.BackgroundImage = Properties.Resources.ComradesSelectorBg;
        }

        public void Initialize(Form form)
        {
            this.form = form;
        }
    }
}
