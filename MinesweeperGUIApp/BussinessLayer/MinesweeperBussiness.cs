using MinesweeperGUIApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MinesweeperLibrary.BussinessLayer
{
    internal class MinesweeperBussiness
    {
        
        public string GetPlayersName()
        {
            // Dealre and Initalize 
            string playerName = "";

            // Show the Name entry form 
            using (FrmNameEntry frmNameEntry = new FrmNameEntry())
            {
                // Chekc to make sure we recived input from the form 
                if (frmNameEntry.ShowDialog() == DialogResult.OK)
                {
                    // Get the players name from frmNameEntry
                    playerName = frmNameEntry.playerName;
                }
            }
            return playerName;
        }//End of Get Players Name
    }
}
