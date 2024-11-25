using MinesweeperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGUIApp.Models
{
    public class SaveData
    {
        public Board Board { get; set; }
        public string[] ActiveRewards { get; set; }
        public TimeSpan Time { get; set; }
        public int Score { get; set; }
        public string Difficulty { get; set; }

        public SaveData(Board board, string[] activeRewards, TimeSpan time, int score, string difficulty)
        {
            Board = board;
            ActiveRewards = activeRewards;
            Time = time;
            Score = score;
            Difficulty = difficulty;
        }
    }

}
