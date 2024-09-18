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

        public void SetDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    BoardSize = 9;
                    BombCount = BoardSize * 2;
                    break;
                case 2:
                    BoardSize = 16;
                    BombCount = BoardSize * 2;
                    break;
                case 3:
                    BoardSize = 24;
                    BombCount = BoardSize * 2;
                    break;
            }
        }


    }
}
