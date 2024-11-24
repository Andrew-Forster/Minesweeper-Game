using MinesweeperGUIApp.Data_Access;
using MinesweeperGUIApp.Models;

namespace MinesweeperGUIApp.BusinessLayer
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
        /// Sort = the difficulty of the game
        /// </summary>
        /// <returns></returns>
        public List<HighScore> GetHighScores(string sort) => dao.GetHighScores(sort);

        public void SaveHighScore(HighScore score) => dao.SaveHighScore(score);
    }
}
