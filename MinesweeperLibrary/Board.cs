using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperLibrary
{
    internal class Board
    {

        public int BoardSize { get; set; }
        public int BombCount { get; set; }
        public int Difficulty { get; set; }
        public Cell[,] Cells { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public Board()
        {
            BoardSize = 0;
            BombCount = 0;
            Difficulty = 0;
            Cells = new Cell[0, 0];
            StartTime = "";
            EndTime = "";
        }

        public Board(int boardSize, int bombCount, int difficulty, Cell[,] cells, string startTime, string endTime)
        {
            BoardSize = boardSize;
            BombCount = bombCount;
            Difficulty = difficulty;
            Cells = cells;
            StartTime = startTime;
            EndTime = endTime;
        }

        // Sets board size and bomb count based on difficulty,
        public void SetDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    BoardSize = 9;
                    BombCount = BoardSize * 2; // 18
                    break;
                case 2:
                    BoardSize = 16;
                    BombCount = BoardSize * 2; // 32
                    break;
                case 3:
                    BoardSize = 24;
                    BombCount = BoardSize * 2; // 48
                    break;
            }
        }

        // Initializes the board with cells & bombs, then shuffles the board to randomize bomb placement
        // Will then display the board
        public String InitBoard()
        {

            Cells = new Cell[BoardSize, BoardSize];

            int I = 0;
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    I++;
                    Cells[row, col] = new Cell(false, (BombCount <= I), false, 0, (row, col));
                }
            }

            ShuffleBoard();
            CalculateAdjacentMines();

            return "Board Initialized"; // Change to display board

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
            String board = "";
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (Cells[row, col].IsMine)
                    {
                        board += "X ";
                    }
                    else
                    {
                        board += Cells[row, col].AdjacentMines + " ";
                    }
                }
                board += "\n";
            }
            return board;
        }

    }
}
