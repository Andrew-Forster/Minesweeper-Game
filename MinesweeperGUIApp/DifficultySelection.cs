using MinesweeperLibrary;

namespace MinesweeperGUIApp
{
    public partial class Minesweeper : Form
    {
        private int boardSize;
        private int mineCount;
        public Minesweeper()
        {
            InitializeComponent();
            panelCustom.Visible = false;
            this.MaximumSize = new Size(panelMain.Width + panelCustom.Width + 50, panelMain.Height + panelCustom.Height + 80);
            boardSize = 0;
            mineCount = 0;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            tipCustom.SetToolTip(rbCustom, "Allows you to set your own board size and mine count.");

            tipEasy.SetToolTip(rbEasy, "9x9 board with 10 mines.");
            tipMedium.SetToolTip(rbMedium, "16x16 board with 40 mines.");
            tipHard.SetToolTip(rbHard, "24x24 board with 99 mines.");
        }

        /// <summary>
        /// Event handler for when a difficulty is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DifficultySelected(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Text == "Custom")
            {
                panelCustom.Visible = true;
                this.Height = this.MaximumSize.Height;
                boardSize = 5;
                mineCount = 5;
            }
            else
            {
                switch (rb.Text)
                {
                    case "Easy":
                        boardSize = 9;
                        mineCount = 10;
                        break;
                    case "Medium":
                        boardSize = 16;
                        mineCount = 40;
                        break;
                    case "Hard":
                        boardSize = 24;
                        mineCount = 99;
                        break;
                }

                panelCustom.Visible = false;
                this.Height = panelMain.Height + 10;
            }
        }

        /// <summary>
        /// Starts the game with the selected difficulty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGame_OnClick(object sender, EventArgs e)
        {
            Board board = new Board(boardSize, mineCount);
            BoardGUI boardGUI = new BoardGUI(board, this);
            boardGUI.Text = $"Minesweeper - {boardSize}x{boardSize}";
            boardGUI.Size = new Size(
                50 * boardSize + 250, // 185 for sidebar
                50 * boardSize + 100);
            boardGUI.Show();

            //boardGUI.MinimumSize = boardGUI.Size; // Uncomment this line to lock the window size

            if (boardSize >= 18)
            {
                boardGUI.WindowState = FormWindowState.Maximized;
            }

            this.Hide();
        }

        /// <summary>
        /// Event handler for when the mine count is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MineCount_OnChanged(object sender, EventArgs e)
        {
            lblMineCount.Text = "Mine Count: " + tbMineCount.Value.ToString();
            mineCount = tbMineCount.Value;


        }

        /// <summary>
        /// Event handler for when the board size is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoardSize_OnChanged(object sender, EventArgs e)
        {
            lblBoardSize.Text = "Board Size: " + tbBoardSize.Value.ToString();

            tbMineCount.Maximum = (tbBoardSize.Value * tbBoardSize.Value) / 4;
            tbMineCount.Value = !((tbMineCount.Maximum / 2) > 5) ? 5 : (tbMineCount.Maximum / 2);
            lblMineCount.Text = "Mine Count: " + tbMineCount.Value.ToString();
            boardSize = tbBoardSize.Value;
            mineCount = tbMineCount.Value;
        }


    }
}
