using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class ComradesSelectorScreen : IScreen
    {
        private ComradesSelectorModel model;
        private Form form;
        Button[] selectButtons = new Button[3];

        public void Initialize(Form form)
        {
            this.form = form;
            model = new ComradesSelectorModel();

            var selectButtonsLocations = new[] { new Point(50, 482), new Point(320, 482), new Point(590, 482) };
            for (var i = 0; i < 3; i++)
            {
                var j = i;
                selectButtons[i] = new Button
                {
                    Size = new Size(145, 40),
                    Location = selectButtonsLocations[i],
                    Image = Properties.Resources.SelectButton,
                    FlatStyle = FlatStyle.Flat
                };
                selectButtons[i].FlatAppearance.BorderSize = 0;
                selectButtons[i].Click += (o, e) => model.Choose(j);
            }
        }

        public void Draw()
        {
            form.BackgroundImage = Properties.Resources.ComradesSelectorBg;
            foreach (var button in selectButtons)
                form.Controls.Add(button);
        }

        public void Clear()
        {
            form.BackgroundImage = default;
            foreach (var button in selectButtons)
                form.Controls.Remove(button);
        }

    }
}
