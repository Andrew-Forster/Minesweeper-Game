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
        // Implement Later
        //public string StartTime { get; set; }
        //public string EndTime { get; set; }

        public Board()
        {

            Difficulty = 1;
            SetDifficulty(Difficulty);// Sets Board Size And Bomb Count
            InitBoard();// Sets Cells



        }

        public Board(int difficulty)
        {
            Difficulty = difficulty;
            SetDifficulty(difficulty); // Sets Board Size And Bomb Count
            InitBoard(); // Sets Cells




        }

        // Sets board size and bomb count based on difficulty,
        public void SetDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                case 1: // Easy
                    BoardSize = 9;
                    BombCount = BoardSize * 2; // 18
                    break;
                case 2: // Medium
                    BoardSize = 16;
                    BombCount = BoardSize * 2; // 32
                    break;
                case 3: // Hard
                    BoardSize = 24;
                    BombCount = BoardSize * 2; // 48
                    break;
                default: // Easy
                    BoardSize = 9;
                    BombCount = BoardSize * 2; // 18
                    break;
            }
        }

        // Initializes the board with cells & bombs, then shuffles the board to randomize bomb placement
        // Will then display the board
        public void InitBoard()
        {

            Cells = new Cell[BoardSize, BoardSize];

            int I = 0;
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    I++;
                    Cells[row, col] = new Cell((BombCount >= I), false, false, 0, (row, col));
                }
            }

            ShuffleBoard();
            CalculateAdjacentMines();

        }

        public void ShuffleBoard()
        {
            ShuffleBoard(5);
        }
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

        public String DisplayBoard()
        {
            String line = string.Concat(Enumerable.Repeat("+---", BoardSize)) + "+";
            String board = " ";
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
                    if (Cells[row, col].IsMine)
                    {
                        board += "| \u001B[31mX\u001B[0m ";
                    }
                    else
                    {
                        switch (Cells[row, col].AdjacentMines)
                        {
                            case 0:
                                board += "| . ";
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


    }
}
