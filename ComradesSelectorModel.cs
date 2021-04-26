using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    class ComradePerson
    {
        public string Name;
        public string description;

        public double ImposterousnessCoefficient;
    }

    class ComradesSelectorModel
    {
        public void Choose(int num)
        {
            MessageBox.Show(num.ToString(), "Вы выбрали чела",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public ComradePerson[] GetOptions()
        {
            throw new NotImplementedException();
        }

    }
}
