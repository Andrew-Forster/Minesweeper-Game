using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperLibrary
{
    public class Cell
    {

        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsRevealed { get; set; }
        public int AdjacentMines { get; set; }
        public (int row, int col) Position { get; set; }

        public Cell()
        {
            IsMine = false;
            IsFlagged = false;
            IsRevealed = false;
            AdjacentMines = 0;
            Position = (0, 0);
        }

        public Cell(bool isMine, bool isFlagged, bool isRevealed, int adjacentMines, (int row, int col) position)
        {
            IsMine = isMine;
            IsFlagged = isFlagged;
            IsRevealed = isRevealed;
            AdjacentMines = adjacentMines;
            Position = position;
        }


    }
}
