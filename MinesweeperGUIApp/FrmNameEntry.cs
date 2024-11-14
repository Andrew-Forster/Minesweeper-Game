using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MinesweeperLibrary;

namespace MinesweeperGUIApp
{
    public partial class FrmNameEntry : Form
    {
        public string playerName = "";
        public FrmNameEntry()
        {
            InitializeComponent();
        }

        private void BtnEnterNameClickEH(object sender, EventArgs e)
        {
            // Set the player name variable to the netered text
            playerName = tbNameEntry.Text;
            // Set the DialogResults property to ok
            this.DialogResult = DialogResult.OK;
        }
    }
}
