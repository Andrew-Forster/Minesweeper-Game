using MinesweeperGUIApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinesweeperGUIApp.Data_Access;
using MinesweeperGUIApp.Models;


namespace MinesweeperLibrary.BussinessLayer
{
    internal class MinesweeperBusiness
    {
        AppDAO dao = new AppDAO();

        /// <summary>
        /// Gets the username from the file.
        /// </summary>
        /// <returns></returns>
        public string GetUserName() => dao.GetUserName();


        /// <summary>
        /// Saves the username to the file.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string SaveUserName(string u) => dao.SaveUserName(u);

        /// <summary>
        /// Returns whether the username is set.
        /// </summary>
        /// <returns></returns>
        public bool UsernameIsNotSet() => dao.UsernameIsNotSet();
        /// <summary>
        /// Retuns the High Score
        /// </summary>
        /// <returns></returns>
        public List<HighScore> GetHighScore() => dao.GetHighScore();
    }
}
