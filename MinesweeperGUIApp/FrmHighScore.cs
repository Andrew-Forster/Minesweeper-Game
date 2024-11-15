using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUIApp
{
    public partial class FrmHighScore : Form
    {
        public FrmHighScore()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InputScore1("John", 100);
            InputScore2("Jane", 200);
            InputScore3("Jack12345678910123456789", 3000);
            InputScore("Andrew F", 40000);
            InputScore("Anonymous", 400);
            InputScore("Jill", 400);
            InputScore("Jill", 400);
        }









        public void InputScore1(string name, int score) => GenerateScoreTag(name, score, 1);
        public void InputScore2(string name, int score) => GenerateScoreTag(name, score, 2);
        public void InputScore3(string name, int score) => GenerateScoreTag(name, score, 3);
        public void InputScore(string name, int score) => GenerateScoreTag(name, score, 4);

        public void GenerateScoreTag(string name, int score, int fileNum)
        {
            Label lblName = new Label();
            Label lblScore = new Label();
            Panel container = new Panel();
            PictureBox pScore = new PictureBox();
            PictureBox pName = new PictureBox();

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


            panelScores.Controls.Add(container);
        }

        private void FormOnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void BtnCloseOnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
