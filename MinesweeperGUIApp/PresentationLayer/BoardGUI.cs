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

        // Triggers re-opening of the main form if true
        public bool openSelector = true;
        public int score { get; set; }
        public string difficulty { get; set; }

        public TimeSpan timeElapsed;
        private MinesweeperBusiness business = new();
        private CancellationTokenSource cancelAnimations;

        public int tileSize = 50;

        List<HighScore> HighScores = new List<HighScore>();



        /// <summary>
        /// Constructor for the BoardGUI
        /// </summary>
        /// <param name="board"></param>
        /// <param name="m"></param>
        public BoardGUI(Board board, DifficultySelection m, string difficulty, Size s)
        {
            InitializeComponent();
            this.board = board;
            this.difficulty = difficulty;
            boardSize = board.BoardSize;
            minesweeper = m;
            timeElapsed = new TimeSpan(0, 0, 0);
            tileSize = utils.DetermineTileSize(boardSize, s.Height);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            m.Hide();
            GenerateUI();

            panelBoard.Left = (panelCenterBoard.Width - panelBoard.Width) / 2;
            panelBoard.Top = (panelCenterBoard.Height - panelBoard.Height) / 2;

            Label quit = utils.CreateLabel("Quit Game", Color.FromArgb(222, 183, 180), 16F);
            quit.Click += BtnQuitOnClick;
            btnQuit.Controls.Add(quit);
            quit.BringToFront();

            HighScores = business.GetHighScores("All");
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
        /// Saves the game data to be resumed later
        /// </summary>
        public void SaveData()
        {
            if (board.CheckGameState() != "Continue")
            {
                business.NoGameData();
                return;
            }

            string[] activeRewards = new string[panelRewards.Controls.Count];
            foreach (Control control in panelRewards.Controls)
            {
                PictureBox btn = (PictureBox)control;
                activeRewards[panelRewards.Controls.IndexOf(control)] = (string)btn.Tag;
            }

            SaveData saveData = new SaveData(board, activeRewards, timeElapsed, score, difficulty);
            business.SaveGameData(saveData);
        }

        /// <summary>
        /// Resumes the game from the saved data
        /// </summary>
        /// <param name="rewards">Any picked up rewards</param>
        public void ResumeGame(string[] rewards)
        {
            tmrTimer.Enabled = true;
            TimerOnTick(this, EventArgs.Empty);

            foreach (string reward in rewards)
            {
                PictureBox btn = utils.CreateButton($"Use {reward}");
                btn.Tag = reward;
                panelRewards.Controls.Add(btn);

                Label btnLbl = (Label)btn.Controls[0];

                btnLbl.Click += (s, ev) =>
                {
                    if ((string)btn.Tag == "Detector")
                    {
                        lblUsingReward.Text = "Using Detector, If you click a mine you won't lose.";
                        lblUsingReward.Tag = "Detector";
                    }
                    else
                    {
                        UseRewardFunction(0, 0, (string)btn.Tag);

                    }
                    panelRewards.Controls.Remove(btn);
                };
            }
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
                    button = utils.MakeTile(i, j, tileSize);

                    Point point = (Point)button.Tag;
                    button.Click += ButtonClick;
                    button.MouseEnter += TileHover;
                    button.MouseLeave += TileLeave;
                    panelBoard.Controls.Add(button);
                    UpdateButton(i, j, false);
                }
            }

        }

        public void ResizeUI()
        {
            tileSize = utils.DetermineTileSize(boardSize, this.Height);
            foreach (Control control in panelBoard.Controls)
            {
                try
                {
                    PictureBox button = (PictureBox)control;
                    Point p = (Point)button.Tag;
                    button.Size = new Size(tileSize, tileSize);
                    button.Location = new Point(p.Y * tileSize, p.X * tileSize);
                }
                catch { }
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
        private void ButtonClick(object sender, EventArgs e)
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

                // SFX: Flag sound

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


            if (lblUsingReward.Text != "" && lblUsingReward.Tag != null)
            {
                UseRewardFunction(row, col, lblUsingReward.Tag.ToString());

                lblUsingReward.Text = "";
                lblUsingReward.Tag = "";

            }


            if (cell.RewardType != "None" && !cell.RewardUsed)
            {
                // if sidebar has 3 reward buttons already, don't add more
                if (panelRewards.Controls.Count >= 3)
                {
                    MessageBox.Show("Please use a reward before claiming more.");
                    return;
                }

                // SFX: Reward found sound

                PictureBox btn = utils.CreateButton($"Use {cell.RewardType}");
                btn.Tag = cell.RewardType;
                panelRewards.Controls.Add(btn);

                Label btnLbl = (Label)btn.Controls[0];

                btnLbl.Click += (s, ev) =>
                {
                    // SFX: Main Button Sound

                    if ((string)btn.Tag == "Detector")
                    {
                        lblUsingReward.Text = "Using Detector, If you click a mine you won't lose.";
                        lblUsingReward.Tag = "Detector";
                    }
                    else
                    {
                        UseRewardFunction(row, col, (string)btn.Tag);
                    }
                    panelRewards.Controls.Remove(btn);
                };

                cell.RewardUsed = true;
                cell.RewardType = "None";
            }


            // SFX: Tile click sound

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

                    // SFX: Lost sound
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

                    // SFX: Win sound
                    result = MessageBox.Show("You won! Play again?", "Game Over", MessageBoxButtons.YesNo);
                    business.SaveHighScore(new HighScore(business.GetUserName(), score, DateTime.Now, difficulty));

                }

                if (result == DialogResult.Yes)
                {
                    BoardGUI newBoard = new BoardGUI(new Board(boardSize, board.BombCount), minesweeper, difficulty, this.Size);
                    newBoard.Size = this.Size;
                    newBoard.Text = this.Text;
                    openSelector = false;
                    newBoard.WindowState = this.WindowState;
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
        private void UseRewardFunction(int row, int col, string reward)
        {
            switch (reward)
            {
                case "Detector":
                    UpdateButton(row, col, true);
                    board.Cells[row, col].IsRevealed = true;
                    break;
                // For Sweep, Scavenge
                default:
                    board.UseReward(reward, row, col);
                    UpdateUI(false);
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
            Point cursorPosition = this.PointToClient(Cursor.Position);
            PictureBox button = utils.FindPictureBoxWithTag(panelBoard, new Point(row, col));
            Cell cell = board.Cells[row, col];

            if (!cell.IsFlagged && (cell.RewardType == "None") && cell.IsRevealed)
            {
                button.Cursor = Cursors.Default;
            }

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
                    try
                    {
                        lblScoreIncrement.Text = $"+{(int.Parse(lblScoreIncrement.Text.Replace("+", "")) + (cell.AdjacentMines * 100))}";
                    }
                    catch
                    {
                        lblScoreIncrement.Text = $"+{(cell.AdjacentMines * 100)}";
                    }
                    lblScoreIncrement.Visible = true;
                    lblScoreIncrement.Location = new Point(cursorPosition.X, cursorPosition.Y - 2);
                    lblScoreIncrement.BringToFront();

                    Task.Delay(500).ContinueWith(t =>
                    {
                        lblScoreIncrement.Invoke(new Action(() =>
                        {
                            lblScoreIncrement.Text = "+0";
                            lblScoreIncrement.Visible = false;
                        }));
                    });

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
        private void TimerOnTick(object sender, EventArgs e)
        {
            timeElapsed = timeElapsed.Add(new TimeSpan(0, 0, 1));
            lblTimer.Text = timeElapsed.ToString(@"hh\:mm\:ss");

            if (score >= 30)
            {
                score -= 30;
            }

            int placement = 1;

            foreach (HighScore highScore in HighScores)
            {
                if (score < highScore.score)
                {
                    placement++;
                }
            }

            switch (placement)
            {
                case 1:
                    lblScore.Text = $"1. {score.ToString()}";
                    panelScoreHolder.BackgroundImage = Image.FromFile("Assets/score1.png");
                    break;
                case 2:
                    lblScore.Text = $"2. {score.ToString()}";
                    panelScoreHolder.BackgroundImage = Image.FromFile("Assets/score2.png");
                    break;
                case 3:
                    lblScore.Text = $"3. {score.ToString()}";
                    panelScoreHolder.BackgroundImage = Image.FromFile("Assets/score3.png");
                    break;
                default:
                    lblScore.Text = $"{score.ToString()}";
                    panelScoreHolder.BackgroundImage = Image.FromFile("Assets/score4.png");
                    break;
            }

        }

        /// <summary>
        /// Quit button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuitOnClick(object sender, EventArgs e)
        {
            // SFX: Main Button Sound
            SaveData();
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
                SaveData();
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

            if (fileName == "Explode")
            {
                // SFX: Explosion sound
            }
            else
            {
                // SFX: Defuse sound
            }


            // Check the total number of frames in the GIF
            int totalFrames = 6;
            int currentFrame = 0;

            // Create a PictureBox to display the GIF animation
            PictureBox animation = new PictureBox
            {
                Dock = DockStyle.None,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(tileSize, tileSize),
                Image = img
            };

            // Find the corresponding button (cell) in the game board where the animation should be displayed
            PictureBox button = utils.FindPictureBoxWithTag(panelBoard, mineLocation);
            button.Controls.Add(animation);
            button.Image = imageCache["Exploded"];
            animation.BringToFront();

            // Use a Timer to step through the frames
            Timer animationTimer = new Timer { Interval = 30 };
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

        private void FrmResizeEnd(object sender, EventArgs e)
        {
            if (this.Width > this.Height)
            {
                ResizeUI();
                panelBoard.Left = (panelCenterBoard.Width - panelBoard.Width) / 2;
                panelBoard.Top = (panelCenterBoard.Height - panelBoard.Height) / 2;
            }

        }

        private void FrmMaximizedCheck(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                ResizeUI();
            }
            panelBoard.Left = (panelCenterBoard.Width - panelBoard.Width) / 2;
            panelBoard.Top = (panelCenterBoard.Height - panelBoard.Height) / 2;

        }
    } // End of BoardGUI
}
