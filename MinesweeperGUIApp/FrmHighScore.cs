using MinesweeperGUIApp.Models;
using MinesweeperLibrary.BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUIApp
{
    public partial class FrmHighScore : Form
    {
        MinesweeperBusiness business = new MinesweeperBusiness();
        int sort = 0;
        public FrmHighScore()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            DisplayScores();

            this.FormBorderStyle = FormBorderStyle.None;

            // Makes form rounded
            int radius = 30;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90); // Top-left corner
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), 270, 90); // Top-right corner
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90); // Bottom-right corner
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90); // Bottom-left corner
            path.CloseFigure();

            this.Region = new Region(path);

        }


        /// <summary>
        /// Display the scores on the form.
        /// </summary>
        public void DisplayScores() => DisplayScores("All");
        public void DisplayScores(string sort)
        {
            List<HighScore> scores = business.GetHighScores(sort);

            for (int i = 0; scores.Count > i; i++)
            {

                if (i >= 15) { break; }

                string arg1 = $"{i + 1}. {scores[i].name}";
                HighScore arg2 = scores[i];
                switch (i)
                {
                    case 0:
                        InputScore1(arg1, arg2);
                        break;
                    case 1:
                        InputScore2(arg1, arg2);
                        break;
                    case 2:
                        InputScore3(arg1, arg2);
                        break;
                    default:
                        InputScore(arg1, arg2);
                        break;

                }
            }
        }








        public void InputScore1(string name, HighScore score) => GenerateScoreTag(name, score, 1);
        public void InputScore2(string name, HighScore score) => GenerateScoreTag(name, score, 2);
        public void InputScore3(string name, HighScore score) => GenerateScoreTag(name, score, 3);
        public void InputScore(string name, HighScore score) => GenerateScoreTag(name, score, 4);

        /// <summary>
        /// Generates a score tag for the high score.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <param name="fileNum"></param>
        public void GenerateScoreTag(string name, HighScore scoreObj, int fileNum)
        {
            int score = scoreObj.score;
            string mode = scoreObj.mode;

            Label lblName = new Label();
            Label lblScore = new Label();
            Panel container = new Panel();
            PictureBox pScore = new PictureBox();
            PictureBox pName = new PictureBox();
            PictureBox pMode = new PictureBox();

            lblName.Text = name;
            lblName.Parent = pName;
            lblName.Location = new Point(15, 20);
            lblName.ForeColor = Color.White;
            lblName.Font = new Font("Azonix", 12);
            lblName.Size = new Size(260, 20);
            lblName.BackColor = Color.Transparent;


            lblScore.Text = score.ToString();
            lblScore.Parent = pScore;
            lblScore.Location = new Point(10, 20);
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
            lblScore.AutoSize = false;
            lblScore.Size = new Size(100, 20);
            lblScore.ForeColor = Color.Black;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Azonix", 12);

            container.Controls.Add(pScore);
            container.Controls.Add(pName);
            container.Size = new Size(400, 65);
            container.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            pScore.BackgroundImage = Image.FromFile($"Assets/score{fileNum}.png");
            pScore.BackgroundImageLayout = ImageLayout.Stretch;
            pScore.Location = new Point(0, 0);
            pScore.Size = new Size(120, 60);

            pName.BackgroundImage = Image.FromFile($"Assets/info{fileNum}.png");
            pName.BackgroundImageLayout = ImageLayout.Stretch;
            pName.Location = new Point(125, 0);
            pName.Size = new Size(280, 60);

            pMode.BackgroundImage = Image.FromFile($"Assets/{mode}.png");
            pMode.BackgroundImageLayout = ImageLayout.Stretch;
            pMode.Location = new Point(235, 12);
            pMode.Size = new Size(32, 32);
            pMode.Parent = pName;
            pMode.BringToFront();


            panelScores.Controls.Add(container);
        }

        /// <summary>
        /// Event handler for exiting the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCloseOnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSortOnClick(object sender, EventArgs e)
        {
            sort++;

            switch (sort)
            {
                case 1:
                    panelScores.Controls.Clear();
                    btnSort.Text = "Difficulty: Easy";
                    DisplayScores("Easy");
                    break;
                case 2:
                    panelScores.Controls.Clear();
                    btnSort.Text = "Difficulty: Medium";
                    DisplayScores("Medium");
                    break;
                case 3:
                    panelScores.Controls.Clear();
                    btnSort.Text = "Difficulty: Hard";
                    DisplayScores("Hard");
                    break;
                case 4:
                    panelScores.Controls.Clear();
                    btnSort.Text = "Difficulty: Custom";
                    DisplayScores("Custom");
                    break;
                default:
                    panelScores.Controls.Clear();
                    btnSort.Text = "Difficulty: All";
                    DisplayScores();
                    sort = 0;
                    break;
            }
        }
    }
}
