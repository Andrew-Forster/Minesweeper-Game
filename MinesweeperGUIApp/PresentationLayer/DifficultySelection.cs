using MinesweeperGUIApp.BusinessLayer;
using MinesweeperGUIApp.Models;
using MinesweeperLibrary;
using Utils = MinesweeperGUIApp.BusinessLayer.Utils;

namespace MinesweeperGUIApp
{
    public partial class DifficultySelection : Form
    {
        public int boardSize;
        public int mineCount;
        MinesweeperBusiness business = new MinesweeperBusiness();
        Utils utils = new Utils();
        FrmNameEntry frmNameEntry = new FrmNameEntry();
        public string difficulty { get; set; }
        PictureBox selectBtn;
        PictureBox hoverBtn;
        int soundMode = 0;

        public DifficultySelection()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            tipCustom.SetToolTip(btnCustom, "Allows you to set your own board size and mine count.");

            tipEasy.SetToolTip(btnEasy, "9x9 board with 10 mines.");
            tipMedium.SetToolTip(btnMedium, "16x16 board with 40 mines.");
            tipHard.SetToolTip(btnHard, "24x24 board with 99 mines.");
            tipSound.SetToolTip(btnSound, "Music & Sound are currently on.");

            if (business.UsernameIsNotSet())
            {
                frmNameEntry.ShowDialog();
            }

            // Select Button
            selectBtn = new PictureBox();
            selectBtn.Image = Image.FromFile("Assets/BtnSelect.png");
            selectBtn.Size = new Size(207, 67);
            selectBtn.SizeMode = PictureBoxSizeMode.StretchImage;

            // Hover Button
            hoverBtn = new PictureBox();
            hoverBtn.Image = Image.FromFile("Assets/BtnHover.png");
            hoverBtn.Size = new Size(207, 67);
            hoverBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            hoverBtn.Click += CustomHoverClick;

            // Initially Select Easy
            boardSize = 9;
            mineCount = 10;
            difficulty = "Easy";
            btnEasy.Controls.Add(selectBtn);

            Label ResumeLabel = utils.CreateLabel("Resume Game", 14F);
            ResumeLabel.Click += BtnResumeGameClick;
            btnResume.Controls.Add(ResumeLabel);

        }

        /// <summary>
        /// Event handler for when a difficulty is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DifficultySelected(object sender, EventArgs e)
        {
            // SFX: Main Button Sound

            PictureBox rb = (PictureBox)sender;

            btnCustom.Controls.Remove(selectBtn);
            btnEasy.Controls.Remove(selectBtn);
            btnMedium.Controls.Remove(selectBtn);
            btnHard.Controls.Remove(selectBtn);

            rb.Controls.Add(selectBtn);


            if (rb.Name == "btnCustom")
            {
                EnableCustomPanel(true);
                boardSize = 5;
                mineCount = 5;
                difficulty = "Custom";
            }
            else
            {
                switch (rb.Name)
                {
                    case "btnEasy":
                        boardSize = 9;
                        mineCount = 10;
                        difficulty = "Easy";
                        break;
                    case "btnMedium":
                        boardSize = 16;
                        mineCount = 40;
                        difficulty = "Medium";
                        break;
                    case "btnHard":
                        boardSize = 24;
                        mineCount = 99;
                        difficulty = "Hard";
                        break;
                }
                EnableCustomPanel(false);

            }
        }

        /// <summary>
        /// Starts the game with the selected difficulty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGameOnClick(object sender, EventArgs e)
        {
            // SFX: Main Button Sound
            if (business.GetGameData() != null)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to start a new game? Your current game will be lost.", "New Game", MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                {
                    return;
                }
            }

                Size s = new Size(800, 500);
            if (boardSize > 16)
            {
                s = new Size(
                    Screen.PrimaryScreen.WorkingArea.Width,
                    Screen.PrimaryScreen.WorkingArea.Height);

                //s = new Size(
                //    boardSize * 40 + 200,
                //    boardSize * 30 + 100**
                //);
            }


            Board board = new Board(boardSize, mineCount);
            BoardGUI boardGUI = new BoardGUI(board, this, difficulty, s);
            boardGUI.Text = $"Minesweeper - {boardSize}x{boardSize}";
            boardGUI.Size = s;

            if (boardSize > 16)
            {
                boardGUI.MaximizeBox = false;
                boardGUI.WindowState = FormWindowState.Maximized;
            }
            boardGUI.Show();

        }
        private void BtnResumeGameClick(object sender, EventArgs e)
        {

            SaveData data = business.GetGameData();
            if (data == null)
            {
                MessageBox.Show("No game data found. Please start a new game.");
                btnResume.Visible = false;
                return;
            }

            Board board = data.Board;

            Size s = new Size(800, 500);
            if (board.BoardSize > 16)
            {
                s = new Size(
                    Screen.PrimaryScreen.WorkingArea.Width,
                    Screen.PrimaryScreen.WorkingArea.Height);

                //s = new Size(
                //    boardSize * 40 + 200,
                //    boardSize * 30 + 100**
                //);
            }


            try
            {
                BoardGUI boardGUI = new BoardGUI(board, this, data.Difficulty, s);
                boardGUI.Text = $"Minesweeper - {board.BoardSize}x{board.BoardSize}";
                boardGUI.Size = s;
                boardGUI.score = data.Score;
                boardGUI.timeElapsed = data.Time;

                if (board.BoardSize > 16)
                {
                    boardGUI.MaximizeBox = false;
                    boardGUI.WindowState = FormWindowState.Maximized;
                }
                boardGUI.Show();
                boardGUI.ResumeGame(data.ActiveRewards);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to resume the game. Please start a new game: " + ex);
            }
        }


        /// <summary>
        /// Event handler for when the mine count is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MineCountOnChanged(object sender, EventArgs e)
        {
            lblMineCount.Text = "Mine Count: " + tbMineCount.Value.ToString();
            mineCount = tbMineCount.Value;


        }

        /// <summary>
        /// Event handler for when the board size is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoardSizeOnChanged(object sender, EventArgs e)
        {
            EnableCustomPanel(true);

            tbMineCount.Maximum = (tbBoardSize.Value * tbBoardSize.Value) / 4;
            tbMineCount.Value = !((tbMineCount.Maximum / 2) > 5) ? 5 : (tbMineCount.Maximum / 2);
            boardSize = tbBoardSize.Value;
            mineCount = tbMineCount.Value;
        }

        /// <summary>
        /// For enabling or disabling the custom panel.
        /// </summary>
        /// <param name="enable"></param>
        private void EnableCustomPanel(bool enable)
        {
            tbBoardSize.Enabled = enable;
            tbMineCount.Enabled = enable;

            if (enable)
            {
                lblBoardSize.Text = "Board Size: " + tbBoardSize.Value.ToString();
                lblMineCount.Text = "Mine Count: " + tbMineCount.Value.ToString();
            }
            else
            {
                lblBoardSize.Text = "Board Size: " + boardSize.ToString();
                lblMineCount.Text = "Mine Count: " + mineCount.ToString();
            }
        }

        private void BtnChangeNameOnClick(object sender, EventArgs e)
        {
            // SFX: Main Button Sound
            frmNameEntry.ShowDialog();

        }

        private void BtnHighScoresOnClick(object sender, EventArgs e)
        {
            // SFX: Main Button Sound
            FrmHighScore frmHighScore = new FrmHighScore();
            frmHighScore.ShowDialog();
        }

        private void BtnCustomHoverEnter(object sender, EventArgs e)
        {
            PictureBox b = (PictureBox)sender;
            b.Controls.Add(hoverBtn);
        }

        private void BtnEnteredForm(object sender, EventArgs e)
        {
            btnCustom.Controls.Remove(hoverBtn);
            btnEasy.Controls.Remove(hoverBtn);
            btnMedium.Controls.Remove(hoverBtn);
            btnHard.Controls.Remove(hoverBtn);
        }

        private void CustomHoverClick(object sender, EventArgs e)
        {
            PictureBox b = (PictureBox)sender.GetType().GetProperty("Parent").GetValue(sender, null);
            DifficultySelected(b, e);
            selectBtn.BringToFront();

        }

        private void BtnSoundClick(object sender, EventArgs e)
        {
            switch (soundMode)
            {
                case 0:
                    btnSound.Image = Image.FromFile("Assets/Mute.png");
                    soundMode = 1;
                    tipSound.ToolTipTitle = "Music is off";
                    tipSound.SetToolTip(btnSound, "Sound effects will continue to play");
                    break;
                case 1:
                    btnSound.Image = Image.FromFile("Assets/MuteAll.png");
                    soundMode = 2;
                    tipSound.ToolTipTitle = "All Sounds Muted";
                    tipSound.SetToolTip(btnSound, "No music and no sound effects will continue to play");
                    break;
                default:
                    btnSound.Image = Image.FromFile("Assets/Sound.png");
                    soundMode = 0;
                    tipSound.ToolTipTitle = "Music & Sound on";
                    tipSound.SetToolTip(btnSound, "Music & Sound are currently on");
                    break;
            }
        }

        private void FrmShown(object sender, EventArgs e)
        {
            if (business.GetGameData() == null)
            {
                btnResume.Visible = false;
            }
            else
            {
                btnResume.Visible = true;
            }
        }
    }
}
