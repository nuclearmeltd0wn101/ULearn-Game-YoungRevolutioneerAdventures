using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
    public static class PeopleOnMap
    {
        public static Image[] Allies = new[]
        { 
            default,
            Properties.Resources.AlliesUpTo25,
            Properties.Resources.AlliesUpTo50,
            Properties.Resources.AlliesUpTo75,
            Properties.Resources.AlliesUpTo100,
            Properties.Resources.AlliesWin
        };

        public static Image[] Foes = new[]
        {
            default,
            Properties.Resources.FoesUpTo25,
            Properties.Resources.FoesUpTo50,
            Properties.Resources.FoesUpTo75,
            Properties.Resources.FoesUpTo100,
            Properties.Resources.FoesWin
        };
    }

    public interface IBattleScreen : IScreen
    {
        public void UpdateMoveLabel();
        public void SelectSpell();
        public void CastedSpellInfo(CommanderPerson commander, Spell spell, SpellOutcome[] outcomes);
        public void UpdateTeamsStatus();
    }

    public class BattleScreen : IBattleScreen
    {
        const int SpellsCount = 2;
        private Form form;
        private BattleModel model;

        private Label alliesStatusLabel = new Label();
        private Label foesStatusLabel = new Label();
        private Label currentMoveLabel = new Label();
        private Button[] spellSelectButtons = new Button[SpellsCount];

        private PictureBox alliesOnMap = new PictureBox();
        private PictureBox foesOnMap = new PictureBox();

        public BattleScreen(CommanderPerson[] chosenComrades)
        {
            model = new BattleModel(this, chosenComrades);
        }

        public void Initialize(Form form)
        {
            this.form = form;

            foreach (var e in new[] { alliesOnMap, foesOnMap })
            {
                e.BackColor = Color.Transparent;
                e.Size = form.Size;
            }
            alliesOnMap.Parent = form;
            foesOnMap.Parent = alliesOnMap;


            for (var i = 0; i < SpellsCount; i++)
            {
                var j = i;
                spellSelectButtons[j] = new Button();
                spellSelectButtons[j].Parent = foesOnMap;
                spellSelectButtons[j].Size = new Size(150, 24);
                spellSelectButtons[j].Location = new Point(480 + j * 160, 535);
                spellSelectButtons[j].Click += (o, e)
                    => model.Step(model.ActiveCommander.Spells[j]);
            }

            foreach (var e in new[] { alliesStatusLabel, foesStatusLabel })
            {
                e.BackColor = Color.Transparent;
                e.ForeColor = Color.White;
                e.Size = new Size(160, 165);
                e.Font = new Font("Comic Sans", 12);
                e.Parent = foesOnMap;
            }
            
            alliesStatusLabel.Location = new Point(5, 360);
            foesStatusLabel.Location = new Point(635, 360);

            currentMoveLabel.Location = new Point(5, 535);
            currentMoveLabel.Size = new Size(380, 20);
            currentMoveLabel.BackColor = Color.Transparent;
            currentMoveLabel.ForeColor = Color.White;
            currentMoveLabel.Font = new Font("Comic Sans", 13);
            currentMoveLabel.Parent = foesOnMap;

            model.StartGame();
        }

        public void UpdateMoveLabel() 
            => currentMoveLabel.Text  = $"Сейчас ходит {model.ActiveCommander.DisplayName} "
                + (model.AlliesCommanders.Contains(model.ActiveCommander) ? "(союзн.)" : "(враг)");

        public void SelectSpell()
        {
            for (var i = 0; i < SpellsCount; i++)
                spellSelectButtons[i].Text = model.ActiveCommander.Spells[i].Name;
        }

        public void CastedSpellInfo(CommanderPerson commander, Spell spell, SpellOutcome[] outcomes)
        {
            var sb = new StringBuilder();
            sb.Append($"{commander.DisplayName} использовал(а) навык {spell.Name}\n\nПоследствия относительно своего формирования:\n");
            foreach (var e in outcomes)
                sb.Append($"  {Spells.OutcomeStringFormat(e)}\n");

            MessageBox.Show(sb.ToString(),
                "Последствия хода " + (model.AlliesCommanders.Contains(commander) ? "союзников" : "врагов"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateTeamsStatus()
        {
            var alliesOnMapIndex = (int) Math.Ceiling(4.0 * model.AlliesPeople / model.TotalPeople);
            var foesOnMapIndex = (int) Math.Ceiling(4.0 * model.FoesPeople / model.TotalPeople);
            
            alliesOnMap.Image = PeopleOnMap.Allies[alliesOnMapIndex];
            foesOnMap.Image = PeopleOnMap.Foes[foesOnMapIndex];

            alliesStatusLabel.Text = BuildStatusText("Толпа Ленина:", model.AlliesPeople,
                model.AlliesMood, model.AlliesCommanders);
            foesStatusLabel.Text = BuildStatusText("Толпа врагов:", model.FoesPeople, 
                model.FoesMood, model.FoesCommanders);

            if (model.AlliesPeople * model.FoesPeople == 0)
            {
                if (model.AlliesPeople > 0)
                    alliesOnMap.Image = PeopleOnMap.Allies[5];
                else
                    foesOnMap.Image = PeopleOnMap.Foes[5];

                MessageBox.Show(model.AlliesPeople > 0 ? "Побьеда сладкоя побьеда" : "Вы потерпели поражение", 
                    "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GameScreen.CloseConfirmation = false;
                Application.Exit();
            }
            
        }

        public void Draw()
        {
            form.BackgroundImage = Properties.Resources.BattleBg;
            
            form.Controls.Add(alliesOnMap);
            alliesOnMap.Controls.Add(foesOnMap);
           
            foreach (var e in spellSelectButtons)
                foesOnMap.Controls.Add(e);

            foreach (var e in new[] { alliesStatusLabel, foesStatusLabel, currentMoveLabel })
                foesOnMap.Controls.Add(e);
        }

        public void Clear()
        {
            form.BackgroundImage = default;

            form.Controls.Remove(alliesOnMap);
            alliesOnMap.Controls.Remove(foesOnMap);

            foreach (var e in new[] { alliesStatusLabel, foesStatusLabel, currentMoveLabel })
                foesOnMap.Controls.Remove(e);

            foreach (var e in spellSelectButtons)
                foesOnMap.Controls.Remove(e);
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
    