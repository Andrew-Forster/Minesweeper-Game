using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MinesweeperGUIApp.Models;
using MinesweeperLibrary;
using System.Text.Json;
using Newtonsoft.Json;

namespace MinesweeperGUIApp.Data_Access
{
    internal class AppDAO
    {
        private static string baseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Minesweeper");
        private string usernameFile = Path.Combine(baseDirectory, "Data/Username.txt");
        private string highscoresFile = Path.Combine(baseDirectory, "Data/HighScores.txt");
        private string saveFile = Path.Combine(baseDirectory, "Data/SavedGame.txt");


        /// <summary>
        /// Gets the username from the file.
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            if (!CheckDataFiles())
            {
                return "Could not create data files!";
            }

            try { return File.ReadAllText(usernameFile); }
            catch (Exception e) { return $"Error reading username: {e}"; }
        }


        /// <summary>
        /// Saves the username to the file.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string SaveUserName(string username)
        {
            if (!CheckDataFiles())
            {
                return "Could not create data files!";
            }

            try
            {
                File.WriteAllText(usernameFile, username);
                return "Success";
            }
            catch (Exception e)
            {
                return $"Error saving username: {e}";
            }
        }

        /// <summary>
        /// Indicates whether the username has ever been set.
        /// </summary>
        /// <returns></returns>
        public bool UsernameIsNotSet()
        {
            if (!CheckDataFiles())
            {
                return true;
            }

            return File.ReadAllText(usernameFile).Trim() == "";
        }

        /// <summary>
        /// Returns the high scores from the file.
        /// </summary>
        /// <returns></returns>
        public List<HighScore> GetHighScores(string sort)
        {

            if (CheckDataFiles() == false)
            {
                return new List<HighScore>();
            }

            List<HighScore> scores = new List<HighScore>();

            string[] lines = File.ReadAllLines(highscoresFile);
            if (lines.Length == 0)
            {
                return scores;
            }

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length != 4)
                {
                    continue;
                }
                try
                {
                    HighScore highScore = new HighScore(parts[0], int.Parse(parts[1]), DateTime.Parse(parts[2]), parts[3].Trim());
                    scores.Add(highScore);
                }
                catch (Exception e) { }
            }


            scores = scores.OrderByDescending(x => x.score).ToList();
            scores = sort == "All" ? scores : scores.Where(x => x.mode == sort).ToList();



            return scores;
        }


        /// <summary>
        /// Saves the high score to the file.
        /// </summary>
        /// <param name="highScore"></param>
        public void SaveHighScore(HighScore highScore) => File.AppendAllText(highscoresFile, highScore.ToString());


        /// <summary>
        /// Ensures that the data files exist.
        /// </summary>
        /// <returns></returns>
        public bool CheckDataFiles()
        {
            try
            {

                if (!Directory.Exists(baseDirectory))
                {
                    Directory.CreateDirectory(baseDirectory);
                }

                if (!Directory.Exists(Path.Combine(baseDirectory, "Data")))
                {
                    Directory.CreateDirectory(Path.Combine(baseDirectory, "Data"));
                }

                if (!File.Exists(usernameFile))
                {
                    File.Create(usernameFile).Close();
                }

                if (!File.Exists(highscoresFile))
                {
                    File.Create(highscoresFile).Close();
                }

                if (!File.Exists(saveFile))
                {
                    File.Create(saveFile).Close();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Saves the game data to a file.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="activeRewards"></param>
        /// <param name="time"></param>
        /// <param name="score"></param>
        public void SaveGameData(SaveData saveData)
        {
            if (!CheckDataFiles())
            {
                return;
            }

            string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);

            File.WriteAllText(saveFile, json);
        }

        public void NoGameData()
        {
            if (!CheckDataFiles())
            {
                return;
            }

            File.WriteAllText(saveFile, "");
        }

        /// <summary>
        /// Retrieves the game data from the file.
        /// </summary>
        /// <returns></returns>
        public SaveData? GetGameData()
        {
            if (!CheckDataFiles())
            {
                return null;
            }

            string json = File.ReadAllText(saveFile);

            if (json == "")
            {
                return null;
            }

            SaveData saveData = JsonConvert.DeserializeObject<SaveData>(json);

            return saveData;
        }

    }

}
