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

        /// <summary>
        /// Saves the high score
        /// </summary>
        /// <param name="score"></param>
        public void SaveHighScore(HighScore score) => dao.SaveHighScore(score);

        /// <summary>
        /// Saves the game data
        /// </summary>
        /// <param name="data"></param>
        public void SaveGameData(SaveData data) => dao.SaveGameData(data);

        /// <summary>
        /// Sets the game data to be null
        /// </summary>
        public void NoGameData() => dao.NoGameData();

        /// <summary>
        /// Gets the game data
        /// </summary>
        /// <returns></returns>
        public SaveData? GetGameData() => dao.GetGameData();
    }
}
