using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinesweeperGUIApp.BusinessLayer;
using MinesweeperGUIApp.Models;
using MinesweeperLibrary;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using Timer = System.Windows.Forms.Timer;
using Utils = MinesweeperGUIApp.BusinessLayer.Utils;

namespace MinesweeperGUIApp
{
    public partial class BoardGUI : Form
    {
        public Board board;
        int boardSize;
        public Dictionary<string, Image> imageCache = new Dictionary<string, Image>();
        public DifficultySelection minesweeper;
        Utils utils = new Utils();

        // Triggers reopeneing of the main form if true
        public bool openSelector = true;
        public int score { get; set; }
        public string difficulty { get; set; }

        TimeSpan timeElapsed;
        private MinesweeperBusiness business = new();
        private CancellationTokenSource cancelAnimations;



        /// <summary>
        /// Constructor for the BoardGUI
        /// </summary>
        /// <param name="board"></param>
        /// <param name="m"></param>
        public BoardGUI(Board board, DifficultySelection m, string difficulty)
        {
            InitializeComponent();
            this.board = board;
            this.difficulty = difficulty;
            boardSize = board.BoardSize;
            minesweeper = m;
            timeElapsed = new TimeSpan(0, 0, 0);
            m.Hide();
            GenerateUI();
        }

        /// <summary>
        /// Important to ensure that images are quickly loaded and not loaded again and again from the disk
        /// </summary>
        private void LoadImages()
        {
            // Load each image once and store it in the dictionary
            imageCache["Bomb"] = Image.FromFile("Assets/Mine.png");
            imageCache["Gold"] = Image.FromFile("Assets/Reward.png");
            imageCache["TileFlat"] = Image.FromFile("Assets/Tile Revealed.png");
            imageCache["Tile1"] = Image.FromFile("Assets/Tile.png");
            imageCache["Tile2"] = Image.FromFile("Assets/Tile.png");
            imageCache["Explode"] = Image.FromFile("Assets/Explode.gif");
            imageCache["Defuse"] = Image.FromFile("Assets/Defuse.gif");
            imageCache["Hover"] = Image.FromFile("Assets/Tile Hover.png");
            imageCache["Exploded"] = Image.FromFile("Assets/Exploded.png");

            for (int i = 1; i <= 8; i++)
            {
                string numberImagePath = $"Assets/Num {i}.png";
                if (File.Exists(numberImagePath))
                {
                    imageCache[$"Num{i}"] = Image.FromFile(numberImagePath);
                }
            }

            imageCache["Skull"] = Image.FromFile("Assets/Flag.png");
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
                    button = utils.MakeTile(i, j);
                    Point point = (Point)button.Tag;
                    button.Click += Button_Click;
                    button.MouseEnter += TileHover;
                    button.MouseLeave += TileLeave;
                    panelBoard.Controls.Add(button);
                    UpdateButton(i, j, false);
                }
            }
        }

        public void TileHover(object sender, EventArgs e)
        {
            if (board.CheckGameState() != "Continue")
            {
                return;
            }

            PictureBox button = (PictureBox)sender;
            Point point = (Point)button.Tag;
            int row = point.X;
            int col = point.Y;
            Cell cell = board.Cells[row, col];

            if (cell.IsRevealed || cell.IsFlagged)
            {
                return;
            }

            button.Image = imageCache["Hover"];
        }

        public void TileLeave(object sender, EventArgs e)
        {
            if (board.CheckGameState() != "Continue")
            {
                return;
            }
            PictureBox button = (PictureBox)sender;
            Point point = (Point)button.Tag;
            int row = point.X;
            int col = point.Y;
            Cell cell = board.Cells[row, col];

            if (cell.IsRevealed || cell.IsFlagged)
            {
                return;
            }

            button.Image = (row % 2 == 0 ? imageCache["Tile1"] : imageCache["Tile2"]);
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

            if (board.Shuffled == false)
            {
                board.ShuffleBoard(point);
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
                TestGameState();
                return;
            }

            if (cell.IsFlagged || (cell.IsRevealed && cell.RewardType == "None"))
            {
                return;
            }

            if (board.GameOver)
            {
                return;
            }

            // Rewards Usage
            if (lblRewards.Text != "")
            {
                UseRewardFunction(row, col);
                TestGameState();
                return;
            }


            if (cell.RewardType != "None" && !cell.RewardUsed && lblRewards.Text == "")
            {
                lblRewards.Text += $"{cell.RewardType}, This will be used on your next click!\n\n";
                cell.RewardUsed = true;
                cell.RewardType = "None";
            }

            tmrTimer.Enabled = true;
            board.Reveal(row + 1, col + 1);
            UpdateUI(false);
            TestGameState();
        }

        public async void TestGameState()
        {
            if (board.CheckGameState() != "Continue")
            {
                tmrTimer.Enabled = false;
                UpdateUI(true);

                DialogResult result;

                if (board.CheckGameState() == "Lost")
                {
                    try
                    {
                        await RunEndAnimationsAsync("Explode");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }


                    result = MessageBox.Show("You lost! Play again?", "Game Over", MessageBoxButtons.YesNo);
                }
                else // won
                {
                    try
                    {
                        await RunEndAnimationsAsync("Defuse");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    result = MessageBox.Show("You won! Play again?", "Game Over", MessageBoxButtons.YesNo);
                    business.SaveHighScore(new HighScore(business.GetUserName(), score, DateTime.Now, difficulty));
                }

                if (result == DialogResult.Yes)
                {
                    BoardGUI newBoard = new BoardGUI(new Board(boardSize, board.BombCount), minesweeper, difficulty);
                    newBoard.Size = this.Size;
                    newBoard.Text = this.Text;
                    openSelector = false;

                    if (boardSize >= 18)
                    {
                        newBoard.WindowState = FormWindowState.Maximized;
                    }
                    newBoard.Show();
                    this.Close();
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
        /// <param name="force"></param> Forces to show the image even if it is not revealed

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
                    : imageCache[$"Num{cell.AdjacentMines}"];



                if (!cell.PointsGiven && board.CheckGameState() != "Lost")
                {
                    score += cell.AdjacentMines * 100;
                    cell.PointsGiven = true;
                    lblScore.Text = score.ToString();
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

            score -= 10;
            lblScore.Text = score.ToString();

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
                cancelAnimations?.Cancel();
            }

            // Call the base class method for other messages
            base.WndProc(ref m);
        }


        protected Task RunEndAnimationsAsync(string fileName)
        {
            cancelAnimations = new CancellationTokenSource();
            var tcs = new TaskCompletionSource();
            List<Point> mineLocations = new List<Point>();
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (board.Cells[i, j].IsMine)
                    {
                        mineLocations.Add(new Point(i, j));
                    }
                }
            }

            Random random = new Random();
            int delayBetweenExplosions = 400;
            int counter = 0;

            Timer explosionTimer = new Timer { Interval = delayBetweenExplosions };
            explosionTimer.Tick += (sender, e) =>
            {


                counter++;
                if (counter > 3) { delayBetweenExplosions = 200; }
                if (counter > 6) { delayBetweenExplosions = 50; }
                if (counter > 9) { delayBetweenExplosions = 25; }
                if (counter > 20) { delayBetweenExplosions = 10; }
                explosionTimer.Interval = delayBetweenExplosions;

                if (cancelAnimations.Token.IsCancellationRequested)
                {
                    explosionTimer.Stop();
                    explosionTimer.Dispose();
                    tcs.SetResult();
                    return;
                }

                if (mineLocations.Count > 0)
                {
                    int index = random.Next(mineLocations.Count);
                    Point mineLocation = mineLocations[index];
                    mineLocations.RemoveAt(index);

                    AnimateBombs(mineLocation, fileName);
                }
                else
                {
                    explosionTimer.Stop();
                    explosionTimer.Dispose();
                    tcs.SetResult(); // Signal completion
                }
            };

            explosionTimer.Start();
            return tcs.Task;
        }

        /// <summary>
        /// Animate an explosion at the given mine location
        /// </summary>
        /// <param name="mineLocation"></param>
        private void AnimateBombs(Point mineLocation, string fileName)
        {
            // Get the GIF image from the cache and clone it to prevent modifying the original
            Image img = (Image)imageCache[fileName].Clone();


            // Check the total number of frames in the GIF
            int totalFrames = 6;
            int currentFrame = 0;

            // Create a PictureBox to display the GIF animation
            PictureBox animation = new PictureBox
            {
                Dock = DockStyle.None,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(50, 50),
                Image = img
            };

            // Find the corresponding button (cell) in the game board where the animation should be displayed
            PictureBox button = (PictureBox)panelBoard.Controls[mineLocation.X * boardSize + mineLocation.Y];
            button.Controls.Add(animation);
            button.Image = imageCache["Exploded"];
            animation.BringToFront();

            // Use a Timer to step through the frames
            Timer animationTimer = new Timer { Interval = 100 }; // Adjust frame speed as needed
            animationTimer.Tick += (sender, e) =>
            {
                // Check if the animation was cancelled
                if (cancelAnimations.Token.IsCancellationRequested)
                {
                    animationTimer.Stop();
                    animationTimer.Dispose();
                    button.Controls.Remove(animation);
                    return;
                }

                // Increase the current frame number
                currentFrame++;
                if (currentFrame >= totalFrames)
                {
                    // Stop the animation after the last frame
                    animationTimer.Stop();
                    animationTimer.Dispose();

                    // Optionally, remove the animation from the control
                    button.Controls.Remove(animation);
                }
                else
                {
                    // Select and display the next frame in the GIF
                    img.SelectActiveFrame(FrameDimension.Time, currentFrame);
                    animation.Image = img;
                }
            };

            // Start the animation timer
            animationTimer.Start();
        }




    } // End of BoardGUI
}
