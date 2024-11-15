using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            this.FormBorderStyle = FormBorderStyle.None;

            int radius = 30;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90); // Top-left corner
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), 270, 90); // Top-right corner
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90); // Bottom-right corner
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90); // Bottom-left corner
            path.CloseFigure();

            this.Region = new Region(path);
        }

        private void BtnEnterNameOnClick(object sender, EventArgs e)
        {
            // Set the player name variable to the netered text
            playerName = tbNameEntry.Text;
            // Set the DialogResults property to ok
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnEnterNameOnClick(sender, e);
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                BtnCancelClick(sender, e);
            }
        }
    }
}
