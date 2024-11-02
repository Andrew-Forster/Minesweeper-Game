using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinesweeperLibrary;

namespace MinesweeperGUIApp
{
    public partial class BoardGUI : Form
    {
        private Board board;
        int boardSize;
        private Dictionary<string, Image> imageCache = new Dictionary<string, Image>();
        private Minesweeper minesweeper;
        private bool openSelector = true;
        public int Score { get; set; }

        TimeSpan timeElapsed;


        /// <summary>
        /// Constructor for the BoardGUI
        /// </summary>
        /// <param name="board"></param>
        /// <param name="m"></param>
        public BoardGUI(Board board, Minesweeper m)
        {
            InitializeComponent();
            this.board = board;
            boardSize = board.BoardSize;
            GenerateUI();
            minesweeper = m;
            timeElapsed = new TimeSpan(0, 0, 0);

        }

        /// <summary>
        /// Important to ensure that images are quickly loaded and not loaded again and again from the disk
        /// </summary>
        private void LoadImages()
        {
            // Load each image once and store it in the dictionary
            imageCache["Bomb"] = Image.FromFile("Assets/Bomb.png");
            imageCache["Gold"] = Image.FromFile("Assets/Gold.png");
            imageCache["TileFlat"] = Image.FromFile("Assets/Tile Flat.png");
            imageCache["Tile1"] = Image.FromFile("Assets/Tile 1.png");
            imageCache["Tile2"] = Image.FromFile("Assets/Tile 2.png");

            for (int i = 1; i <= 8; i++)
            {
                string numberImagePath = $"Assets/Number {i}.png";
                if (File.Exists(numberImagePath))
                {
                    imageCache[$"Number{i}"] = Image.FromFile(numberImagePath);
                }
            }

            imageCache["Skull"] = Image.FromFile("Assets/Skull.png");
        }

        /// <summary>
        /// Generates the UI for the board and adds the buttons to the panel
        /// </summary>
        public void GenerateUI()
        {
            LoadImages();
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    PictureBox button = new PictureBox();
                    button.SizeMode = PictureBoxSizeMode.StretchImage;
                    button.Size = new Size(50, 50);
                    button.Location = new Point(50 * j, 50 * i);
                    button.Click += Button_Click;
                    button.Tag = new Point(i, j);
                    panelBoard.Controls.Add(button);
                    UpdateButton(i, j, false);
                }
            }
        }

        /// <summary>
        /// Event handler for when a button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            Point point = (Point)button.Tag;
            int row = point.X;
            int col = point.Y;
            Cell cell = board.Cells[row, col];

            if (board.GameOver)
            {
                return;
            }

            // Flag Right Click
            if (e is MouseEventArgs mouseEventArgs && mouseEventArgs.Button == MouseButtons.Right)
            {
                if (cell.IsRevealed)
                {
                    return;
                }
                board.Flag(row + 1, col + 1);
                UpdateButton(row, col, false);
                return;
            }

            if (cell.IsFlagged || (cell.IsRevealed && cell.RewardType == "None"))
            {
                return;
            }

            // Rewards Usage
            if (lblRewards.Text != "")
            {
                UseRewardFunction(row, col);
                return;
            }


            if (cell.RewardType != "None" && !cell.RewardUsed && lblRewards.Text == "")
            {
                lblRewards.Text += $"{cell.RewardType}, This will be use on your next click!\n\n";
                cell.RewardUsed = true;
                cell.RewardType = "None";
            }

            tmrTimer.Enabled = true;
            board.Reveal(row + 1, col + 1);
            UpdateUI(false);


            // Checks game state
            if (board.CheckGameState() != "Continue")
            {
                tmrTimer.Enabled = false;
                UpdateUI(true);


                if (board.CheckGameState() == "Lost")
                {
                    // Show play again yes or no
                    DialogResult result = MessageBox.Show("You lost! Play again?", "Game Over", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        BoardGUI newBoard = new BoardGUI(new Board(boardSize, board.BombCount), minesweeper);
                        newBoard.Show();
                        newBoard.Size = this.Size;
                        openSelector = false;
                        this.Close();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("You won! Play again?", "Game Over", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        BoardGUI newBoard = new BoardGUI(new Board(boardSize, board.BombCount), minesweeper);
                        newBoard.Show();
                        newBoard.Size = this.Size;
                        openSelector = false;
                        this.Close();
                    }
                }

            }
        }

        /// <summary>
        /// Updates the UI for the entire board
        /// </summary>
        /// <param name="force"></param>
        private void UpdateUI(bool force)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    UpdateButton(i, j, force);
                }
            }
        }

        /// <summary>
        /// Rewards function to be used when a reward is selected
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void UseRewardFunction(int row, int col)
        {
            string reward = lblRewards.Text.Split(',')[0];
            switch (reward)
            {
                case "Detector":
                    UpdateButton(row, col, true);
                    board.Cells[row, col].IsRevealed = true;
                    lblRewards.Text = "";
                    break;
                // For Sweep, Scavenge
                default:
                    board.UseReward(reward, row, col);
                    UpdateUI(false);
                    lblRewards.Text = "";
                    break;
            }
        }

        /// <summary>
        /// Updates the button image state at the given row and column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="force"></param>
        private void UpdateButton(int row, int col, bool force)
        {
            PictureBox button = (PictureBox)panelBoard.Controls[row * boardSize + col];
            Cell cell = board.Cells[row, col];


            if (cell.IsRevealed || force)
            {
                button.Image =
                    cell.IsMine ? imageCache["Bomb"]
                    : (cell.RewardType != "None") ? imageCache["Gold"]
                    : cell.AdjacentMines == 0 ? imageCache["TileFlat"]
                    : imageCache[$"Number{cell.AdjacentMines}"];


                if (cell.IsMine)
                {
                    if (board.CheckGameState() == "Lost")
                    {
                        button.BackColor = Color.Red;
                    }
                    else if (board.CheckGameState() == "Won")
                    {
                        button.BackColor = Color.Green;
                    }
                }


                if (!cell.PointsGiven && board.CheckGameState() != "Lost")
                {
                    Score += cell.AdjacentMines * 100;
                    cell.PointsGiven = true;
                    lblScore.Text = Score.ToString();
                }
            }
            else
            {
                button.Image =
                    cell.IsFlagged ? imageCache["Skull"]
                        : (row % 2 == 0 ? imageCache["Tile1"] : imageCache["Tile2"]);
            }
        }

        /// <summary>
        /// Timer tick event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_OnTick(object sender, EventArgs e)
        {
            timeElapsed = timeElapsed.Add(new TimeSpan(0, 0, 1));
            lblTimer.Text = timeElapsed.ToString(@"hh\:mm\:ss");

            Score -= 10;
            lblScore.Text = Score.ToString();

        }

        /// <summary>
        /// Quit button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuit_OnClick(object sender, EventArgs e)
        {
            this.Close();
            minesweeper.Show();

        }


        /// <summary>
        /// Used to Open up the main Form on close or else the program hangs
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_CLOSE = 0x0010;

            if (m.Msg == WM_CLOSE && openSelector)
            {
                minesweeper.Show();
            }

            // Call the base class method for other messages
            base.WndProc(ref m);
        }

    }
}
