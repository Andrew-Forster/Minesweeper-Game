﻿using System;
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
        public string RewardType { get; set; }
        public bool PointsGiven { get; set; }
        public bool RewardUsed { get; set; }
    

        /// <summary>
        /// Default Constructor for Cell
        /// </summary>
        public Cell()
        {
            IsMine = false;
            IsFlagged = false;
            IsRevealed = false;
            AdjacentMines = 0;
            Position = (0, 0);
            RewardType = "None";
            PointsGiven = false;
            RewardUsed = false;
        }

        /// <summary>
        /// Constructor for Cell
        /// </summary>
        /// <param name="isMine"></param>
        /// <param name="isFlagged"></param>
        /// <param name="isRevealed"></param>
        /// <param name="adjacentMines"></param>
        /// <param name="position"></param>
        public Cell(bool isMine, bool isFlagged, bool isRevealed, int adjacentMines, (int row, int col) position, string reward)
        {
            IsMine = isMine;
            IsFlagged = isFlagged;
            IsRevealed = isRevealed;
            AdjacentMines = adjacentMines;
            Position = position;
            RewardType = reward;
            PointsGiven = false;
            RewardUsed = false;
        }


    }
}
