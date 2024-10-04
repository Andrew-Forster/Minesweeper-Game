using System;
using System.Collections.Generic;
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
        public Cell[,] Cells { get; set; }
        public bool GameOver { get; set; }
        public List<string> RewardsInventory { get; set; }

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
            InitBoard(); // Sets Cells
            GameOver = false;
            RewardsInventory = new List<string>();



        }

        /// <summary>
        /// Sets up game board based on difficulty
        /// </summary>
        /// <param name="difficulty"></param>
        public Board(int difficulty)
        {
            Difficulty = difficulty;
            SetDifficulty(difficulty); // Sets Board Size And Bomb Count
            InitBoard(); // Sets Cells
            GameOver = false;
            RewardsInventory = new List<string>();
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
                    BombCount = BoardSize * 2; // 18`
                    break;
                case 3: // Hard
                    BoardSize = 24;
                    BombCount = BoardSize * 2; // 48
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
                    i++;
                    Cells[row, col] = new Cell((BombCount >= i), false, false, 0, (row, col), "None");

                    if (i > BombCount && i < (BombCount + Difficulty + 1))
                    {
                        Cells[row, col] = new Cell(false, false, false, 0, (row, col), "Detector");
                        continue;
                    }


                }
            }

            ShuffleBoard();
            CalculateAdjacentMines();

        }

        /// <summary>
        /// Overloaded ShuffleBoard method to shuffle board 5 times by default
        /// </summary>
        public void ShuffleBoard()
        {
            ShuffleBoard(5);
        }

        /// <summary>
        /// Shuffles Game Board to randomize bomb placement
        /// </summary>
        /// <param name="num"></param>
        public void ShuffleBoard(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Random random = new Random();
                for (int row = 0; row < BoardSize; row++)
                {
                    for (int col = 0; col < BoardSize; col++)
                    {
                        int newRow = random.Next(BoardSize);
                        int newCol = random.Next(BoardSize);

                        Cell temp = Cells[row, col];
                        Cells[row, col] = Cells[newRow, newCol];
                        Cells[newRow, newCol] = temp;
                    }
                }
            }
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
        /// Returns a string representation of the game board
        /// </summary>
        /// <returns></returns>
        public String GetBoard()
        {
            // Creates border for board
            String line = string.Concat(Enumerable.Repeat("+---", BoardSize)) + "+";
            String board = " ";
            // Prints index of columns
            for (int col = 0; col < BoardSize; col++)
            {
                board += "   " + (col + 1);
            }
            board += ("\n  " + line + "\n");

            for (int row = 0; row < BoardSize; row++)
            {
                board += (row + 1) + " ";

                for (int col = 0; col < BoardSize; col++)
                {
                    if (Cells[row, col].IsFlagged)
                    {
                        board += "| \u001B[33mX\u001B[0m ";
                    }
                    else
                    if (!Cells[row, col].IsRevealed)
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

            if (cell.RewardType != "None" && cell.RewardType != "")
            {
                RewardsInventory.Add(cell.RewardType);
                Utils.RewardFound(cell.RewardType);
            }

            cell.IsRevealed = true;
        }

        public void Flag(int row, int col)
        {
            Cell cell = Cells[row - 1, col - 1];
            if (cell.IsRevealed)
            {
                return;
            }

            cell.IsFlagged = !cell.IsFlagged;
        }

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
                    if (Cells[row, col].IsRevealed)
                    {
                        count++;
                    }
                    if (Cells[row, col].IsFlagged && Cells[row, col].IsMine)
                    {
                        flagged++;
                    }
                }
            }
            if (flagged == BombCount)
            {
                return "Won";
            }
            if (count == (BoardSize * BoardSize) - BombCount)
            {
                return "Won";
            }
            if (GameOver)
            {
                return "Lost";
            }
            return "Continue";
        }

    }
}
