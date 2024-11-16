using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace MinesweeperGUIApp.Models
{
    internal class HighScore
    {
        public string name {  get; set; }  
        public int score { get; set; } 
        public DateTime date { get; set; }

        /// <summary>
        /// For creating a new high score
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <param name="date"></param>
        public HighScore (string name, int score, DateTime date)
        {
            this.name = name;   
            this.score = score;
            this.date = date;
        }

        /// <summary>
        /// For reading from file
        /// </summary>
        /// <param name="line"></param>
        public HighScore(string v, string[] line)
        {
            name = line[0];
            score = Convert.ToInt32(line[1]);
            date = Convert.ToDateTime(line[2]);
        }
        
        /// <summary>
        /// To String override 
        /// Formats for the file
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"\n{name},{score},{date}";
        }

       

    }
}
