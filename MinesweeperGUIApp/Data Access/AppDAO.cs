using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MinesweeperGUIApp.Models;

namespace MinesweeperGUIApp.Data_Access
{
    internal class AppDAO
    {
        private string usernameFile = "Data/Username.txt";
        private string highscoresFile = "Data/Highscores.txt";


        /// <summary>
        /// Gets the username from the file.
        /// </summary>
        /// <returns></returns>
        public string GetUserName() => File.ReadLines(usernameFile).FirstOrDefault() ?? "Anonymous";


        /// <summary>
        /// Saves the username to the file.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string SaveUserName(string username)
        {
            try
            {
                File.WriteAllText(usernameFile, username);
                return "Username saved successfully!";
            }
            catch (Exception)
            {
                return "Error saving username!";
            }
        }

        /// <summary>
        /// Indicates whether the username has ever been set.
        /// </summary>
        /// <returns></returns>
        public bool UsernameIsNotSet()
        {
            if (!File.Exists(usernameFile))
            {
                return true;
            }
            else
            {
                return File.ReadAllText(usernameFile).Trim() == "";
            }
        }

        /// <summary>
        /// Returns the high scores from the file.
        /// </summary>
        /// <returns></returns>
        public List<HighScore> GetHighScores()
        {
            List<HighScore> scores = new List<HighScore>();


            if (File.Exists(highscoresFile))
            {
                string[] lines = File.ReadAllLines(highscoresFile);
                if (lines.Length == 0)
                {
                    return scores;
                }

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length != 3)
                    {
                        continue;
                    }
                    try
                    {
                        HighScore highScore = new HighScore(parts[0], int.Parse(parts[1]), DateTime.Now);
                        scores.Add(highScore);
                    }
                    catch (Exception e) {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            scores = scores.OrderByDescending(x => x.score).ToList();
            return scores;
        }


        /// <summary>
        /// Saves the high score to the file.
        /// </summary>
        /// <param name="highScore"></param>
        public void SaveHighScore(HighScore highScore) => File.AppendAllText(highscoresFile, highScore.ToString());

    }

}
