using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public class BattleScreen : IScreen
    {
        private Form form;
        private BattleModel model;

        private Label alliesStatusLabel = new Label();
        private Label foesStatusLabel = new Label();
        private Label currentMoveLabel = new Label();

        public BattleScreen(CommanderPerson[] chosenComrades)
        {
            model = new BattleModel(this, chosenComrades);
        }

        public void Initialize(Form form)
        {
            this.form = form;
            model.StartGame();

            alliesStatusLabel.Location = new Point(15, 130);
            foesStatusLabel.Location = new Point(605, 130);
            currentMoveLabel.Location = new Point(240, 125);

            foreach (var e in new[] { alliesStatusLabel, foesStatusLabel })
            {
                e.BackColor = Color.Black;
                e.ForeColor = Color.White;
                e.Size = new Size(180, 165);
                e.Font = new Font("Comic Sans", 12);
            }

            currentMoveLabel.Size = new Size(320, 24);
            currentMoveLabel.BackColor = Color.Black;
            currentMoveLabel.ForeColor = Color.White;
            currentMoveLabel.Font = new Font("Comic Sans", 14);
        }

        public void SelectSpell()
        {
            var commander = model.ActiveCommander;
            currentMoveLabel.Text = $"Сейчас ходит {commander.DisplayName}";
        }

        public void CastedSpellInfo(CommanderPerson commander, Spell spell)
        {
            MessageBox.Show($"{commander.DisplayName} использовал навык {spell.Name}",
            "Был использован навык", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateTeamsStatus()
        {
            alliesStatusLabel.Text = BuildStatusText("Толпа Ленина:", 
                model.AlliesPeople, model.AlliesMood, model.AlliesCommanders);
            foesStatusLabel.Text = BuildStatusText("Толпа врагов:",
                model.FoesPeople, model.FoesMood, model.FoesCommanders);
        }


        public void Draw()
        {
            form.BackgroundImage = Properties.Resources.BattleBg;
            foreach (var e in new[] { alliesStatusLabel, foesStatusLabel, currentMoveLabel })
                form.Controls.Add(e);
        }

        public void Clear()
        {
            form.BackgroundImage = default;
        }

        private string BuildStatusText(string title, int peopleCount, int moodPercentage, CommanderPerson[] commanders)
        {
            var sb = new StringBuilder();
            sb.Append(title + "\n");
            sb.Append($"   {peopleCount} сторонников\n");
            sb.Append($"   Боевой дух: {moodPercentage}%\n");
            sb.Append("\n   Командиры:\n");

            foreach (var e in commanders)
                sb.Append($"      {e.DisplayName}\n");

            return sb.ToString();
        }
    }
}
    