using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MinesweeperGUIApp.Models
{
    internal class HighScore
    {
        public string name {  get; set; }  
        public int score { get; set; } 
        public DateTime date { get; set; }

        public HighScore (string name, int score, DateTime date)
        {
            this.name = name;   
            this.score = score;
            this.date = date;
        }

        public HighScore(string[] line)
        {
            name = line[0];
            score = Convert.ToInt32(line[1]);
            date = Convert.ToDateTime(line[2]);
        }
        
        /// <summary>
        /// To String override 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Return the string forateed for the text file
            return System.String.Format("{0}, {1}, {2}", name, score, date);
        }

       

    }
}
