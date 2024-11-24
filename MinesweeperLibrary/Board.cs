using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperLibrary
{
    public class Board
    {

        public int BoardSize { get; set; }
        public int BombCount { get; set; }
        public int Difficulty { get; set; }
        public int RewardCount { get; set; }
        public Cell[,] Cells { get; set; }
        public bool GameOver { get; set; }
        public List<string> RewardsInventory { get; set; }
        public bool Shuffled { get; set; } = false;

        // Implement Later
        //public string StartTime { get; set; }
        //public string EndTime { get; set; }

        /// <summary>
        /// Default Constructor for Board
        /// Sets Difficulty to 1 (Easy)
        /// Initializes Board
        /// </summary>
        public Board()
        {
            Difficulty = 1;
            SetDifficulty(Difficulty); // Sets Board Size And Bomb Count
            GameOver = false;
            RewardsInventory = new List<string>();
            RewardCount = 0;
            InitBoard();
        }

        /// <summary>
        /// Sets up game board based on difficulty
        /// </summary>
        /// <param name="difficulty"></param>
        public Board(int difficulty)
        {
            Difficulty = difficulty;
            SetDifficulty(difficulty); // Sets Board Size And Bomb Count
            GameOver = false;
            RewardsInventory = new List<string>();
            RewardCount = difficulty;
            InitBoard();
        }

        public Board(int boardSize, int bombCount)
        {
            BombCount = bombCount;
            BoardSize = boardSize;
            GameOver = false;
            RewardsInventory = new List<string>();
            RewardCount = (BombCount / BoardSize) + 1;
            InitBoard();
        }





        /// <summary>
        /// Sets the Board Size and Bomb Count based on difficulty
        /// </summary>
        /// <param name="difficulty"></param>
        public void SetDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                case 1: // Easy
                    BoardSize = 4;
                    BombCount = 4;
                    break;
                case 2: // Medium
                    BoardSize = 9;
                    BombCount = 10;
                    break;
                case 3: // Hard
                    BoardSize = 14;
                    BombCount = 20;
                    break;
                default: // Easy
                    BoardSize = 4;
                    BombCount = 4;
                    break;
            }
        }

        /// <summary>
        /// Initializes the game board with cells and bombs, 
        /// then shuffles the board to randomize bomb placement
        /// </summary>
        public void InitBoard()
        {

            Cells = new Cell[BoardSize, BoardSize];

            int i = 0;
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Cells[row, col] = new Cell(false, false, false, 0, (row, col), "None");
                }
            }

            Random random = new Random();

            while (i < BombCount)
            {
                int row = random.Next(BoardSize);
                int col = random.Next(BoardSize);

                if (!Cells[row, col].IsMine)
                {
                    Cells[row, col] = new Cell(true, false, false, 0, (row, col), "None");
                    i++;
                }
            }

        }

        /// <summary>
        /// Overloaded Shuffle Board method to shuffle board 5 times by default
        /// </summary>
        public void ShuffleBoard(Point startClick = new Point())
        {
            ShuffleBoard(10, startClick);
        }

        /// <summary>
        /// Shuffles Game Board to randomize bomb placement
        /// Ensures that the start click will never be a mine
        /// if a point is passed in
        /// * MUST CALL THIS METHOD *
        /// </summary>
        /// <param name="num"></param>
        public void ShuffleBoard(int num, Point startClick = new Point())
        {
            int distance = 3;

            if (BoardSize < 10)
            {
                distance = 2;
            }

            Random random = new Random();
            Shuffled = true;

            // Shuffle board num times
            for (int i = 0; i < num; i++)
            {
                var cellList = Cells.Cast<Cell>().ToList();

                for (int currentIndex = cellList.Count - 1; currentIndex > 0; currentIndex--)
                {
                    int randomIndex = random.Next(currentIndex + 1);
                    if (startClick != new Point() &&
                        Math.Abs(randomIndex / BoardSize - startClick.X) < distance &&
                        Math.Abs(randomIndex % BoardSize - startClick.Y) < distance &&
                        !Cells[currentIndex / BoardSize, currentIndex % BoardSize].IsMine &&
                        !Cells[randomIndex / BoardSize, currentIndex % BoardSize].IsMine)
                    {
                        (cellList[currentIndex], cellList[randomIndex]) = (cellList[randomIndex], cellList[currentIndex]);
                    }
                }
                // Reassign shuffled board back to Cells
                for (int row = 0; row < BoardSize; row++)
                {
                    for (int col = 0; col < BoardSize; col++)
                    {
                        Cells[row, col] = cellList[row * BoardSize + col];
                    }
                }
            }


            CalculateAdjacentMines();
            SetRewards(RewardCount + 1);
        }

        /// <summary>
        /// Calculates the number of adjacent mines for each cell 
        /// and sets the AdjacentMines property of each cell
        /// </summary>
        public void CalculateAdjacentMines()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (Cells[row, col].IsMine)
                    {
                        Cells[row, col].AdjacentMines = -1;
                    }
                    else
                    {
                        int count = 0;
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if (row + i >= 0 && row + i < BoardSize && col + j >= 0 && col + j < BoardSize)
                                {
                                    if (Cells[row + i, col + j].IsMine)
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                        Cells[row, col].AdjacentMines = count;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the rewards on the board
        /// Only on cells that do not have a number
        /// </summary>
        /// <param name="count"></param>
        public void SetRewards(int count)
        {
            Random random = new Random();
            int maxSpots = 0;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (Cells[i, j].AdjacentMines == 0 && !Cells[i, j].IsMine)
                    {
                        maxSpots++;
                    }
                }
            }
            count = maxSpots < count ? maxSpots : count;

            for (int i = 0; i < count; i++)
            {
                while (true)
                {
                    int row = random.Next(BoardSize);
                    int col = random.Next(BoardSize);

                    if (Cells[row, col].AdjacentMines == 0 && !Cells[row, col].IsMine)
                    {
                        string[] rewards = { "Detector", "Detector", "Scavenge", "Scavenge", "Sweep" };
                        int rewardIndex = random.Next(rewards.Length);
                        Cells[row, col] = new Cell(false, false, false, 0, (row, col), rewards[rewardIndex]);
                        break;
                    }
                }
            }

        }

        public String GetBoard()
        {
            return GetBoard(false);
        }

        /// <summary>
        /// Returns a string representation of the game board
        /// </summary>
        /// <returns></returns>
        public String GetBoard(bool answerKey)
        {
            // Creates border for board
            String line = " " + string.Concat(Enumerable.Repeat("+---", BoardSize)) + "+";
            String board = "  ";
            // Prints index of columns
            for (int col = 0; col < BoardSize; col++)
            {
                if (col < 9)
                {
                    board += " ";
                }
                board += "  " + (col + 1);
            }
            board += ("\n  " + line + "\n");

            for (int row = 0; row < BoardSize; row++)
            {
                board += (row + 1) + " ";
                if (row < 9)
                {
                    board += " ";
                }

                for (int col = 0; col < BoardSize; col++)
                {
                    if (Cells[row, col].IsFlagged)
                    {
                        board += "| \u001B[33mX\u001B[0m ";
                    }
                    else
                    if (!Cells[row, col].IsRevealed && !answerKey)
                    {
                        board += "| ? ";
                    }
                    else

                    if (Cells[row, col].IsMine)
                    {
                        board += "| \u001B[31m*\u001B[0m ";
                    }
                    else

                    if (Cells[row, col].RewardType == "Detector")
                    {
                        board += "| \u001B[39mR\u001B[0m ";

                    }
                    else
                    {
                        // Colors numbers based on adjacent mines
                        switch (Cells[row, col].AdjacentMines)
                        {
                            case 0:
                                board += "|   ";
                                break;
                            case 1:
                                board += "| \u001B[34m1\u001B[0m ";
                                break;
                            case 2:
                                board += "| \u001B[32m2\u001B[0m ";
                                break;
                            case 3:
                                board += "| \u001B[33m3\u001B[0m ";
                                break;
                            case 4:
                                board += "| \u001B[35m4\u001B[0m ";
                                break;
                            case 5:
                                board += "| \u001B[36m5\u001B[0m ";
                                break;
                            case 6:
                                board += "| \u001B[37m6\u001B[0m ";
                                break;
                            case 7:
                                board += "| \u001B[31m7\u001B[0m ";
                                break;
                            case 8:
                                board += "| \u001B[31m8\u001B[0m ";
                                break;
                            default:
                                board += "| " + Cells[row, col].AdjacentMines + " ";
                                break;
                        }
                    }
                    board += (col == BoardSize - 1) ? "|" : "";
                }

                board += ("\n  " + line + "\n");
            }
            return board;
        }

        /// <summary>
        /// Reveals cell
        /// If cell is a mine, game is over
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public void Reveal(int row, int col)
        {
            Cell cell = Cells[row - 1, col - 1];
            if (cell.IsRevealed)
            {
                return;
            }

            if (cell.IsMine)
            {
                cell.IsRevealed = true;
                GameOver = true;
                return;
            }

            if (cell.RewardType != "None" && !cell.RewardUsed)
            {
                RewardsInventory.Add(cell.RewardType);
                Utils.RewardFound(cell.RewardType);
            }
            FloodFill(row - 1, col - 1);
            cell.IsRevealed = true;


        }

        /// <summary>
        /// Flags a cell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void Flag(int row, int col)
        {
            Cell cell = Cells[row - 1, col - 1];
            if (cell.IsRevealed)
            {
                return;
            }

            cell.IsFlagged = !cell.IsFlagged;
        }

        /// <summary>
        /// Uses a detector to check if a cell is a mine
        /// For use in the console app only
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool UseDetector(int row, int col)
        {
            Cell cell = Cells[row - 1, col - 1];

            if (cell.IsMine)
            {
                cell.IsRevealed = true;
                return true;
            }

            return false;
        }

        public void UseReward(string reward, int row, int col)
        {
            switch (reward)
            {
                case "Detector":
                    Cells[row, col].IsRevealed = true;
                    break;
                case "Scavenge":
                    // Reveals a random mine
                    while (true)
                    {
                        Random random = new Random();
                        int newRow = random.Next(BoardSize);
                        int newCol = random.Next(BoardSize);

                        if (Cells[newRow, newCol].IsMine && !Cells[newRow, newCol].IsRevealed && !Cells[newRow, newCol].IsFlagged)
                        {
                            Cells[newRow, newCol].IsRevealed = true;
                            break;
                        }
                    }
                    break;
                case "Sweep":
                    // Reveals all open caverns
                    for (int i = 0; i < BoardSize; i++)
                    {
                        for (int j = 0; j < BoardSize; j++)
                        {
                            if (!Cells[i, j].IsMine && Cells[i, j].IsRevealed == false && Cells[i, j].AdjacentMines == 0)
                            {
                                FloodFill(i, j);
                            }
                        }
                    }

                    break;
                default:
                    break;
            }

        }



        /// <summary>
        /// Checks if the game is over
        /// Returns 
        /// </summary>
        /// <returns></returns>
        public string CheckGameState()
        {
            int count = 0;
            int flagged = 0;
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (Cells[row, col].IsRevealed && !Cells[row, col].IsMine)
                    {
                        count++;
                    }
                    if (Cells[row, col].IsFlagged && Cells[row, col].IsMine || Cells[row, col].IsMine && Cells[row, col].IsRevealed)
                    {
                        flagged++;
                    }
                    if (Cells[row, col].IsFlagged && !Cells[row, col].IsMine)
                    {
                        flagged--;
                    }
                }
            }
            if (flagged == BombCount)
            {
                return "Won";
            }
            if (count >= (BoardSize * BoardSize) - BombCount)
            {
                return "Won";
            }
            if (GameOver)
            {
                return "Lost";
            }
            return "Continue";
        }

        /// <summary>
        /// Flood Fill Algorithm to reveal all adjacent cells
        /// </summary>
        /// <param name="c"></param>
        public void FloodFill(int row, int col)
        {
            if (row < 0 || row >= BoardSize || col < 0 || col >= BoardSize || Cells[row, col].IsMine)
            {
                return;
            }
            Cell c = Cells[row, col];
            c.IsFlagged = false;

            if (c.IsRevealed || c.AdjacentMines != 0)
            {
                // Reveals the edges of the flood fill
                c.IsRevealed = true;
                return;
            }


            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {

                    if (row + i >= 0 && row + i < BoardSize && col + j >= 0 && col + j < BoardSize)
                    {
                        c.IsRevealed = true;
                        FloodFill(row + i, col + j);
                    }
                }
            }
        }
    }
}
