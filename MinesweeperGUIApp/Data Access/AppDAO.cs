﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MinesweeperGUIApp.Data_Access
{
    internal class AppDAO
    {
        private string usernameFile = "Data/Username.txt";
        private string highscoresFile = "Highscores.txt";

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
    }
}
