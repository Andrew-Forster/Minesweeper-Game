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
using MinesweeperGUIApp.BusinessLayer;
using MinesweeperLibrary;
using Utils = MinesweeperGUIApp.BusinessLayer.Utils;

namespace MinesweeperGUIApp
{
    public partial class FrmNameEntry : Form
    {
        MinesweeperBusiness business = new MinesweeperBusiness();
        Utils utils = new Utils();

        public FrmNameEntry()
        {
            InitializeComponent();

            tbName.Text = business.GetUserName();
            AddLabels();


            this.FormBorderStyle = FormBorderStyle.None;

            // Makes form rounded
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
        private void AddLabels()
        {
            Label enter = utils.CreateLabel("Enter");
            enter.Click += BtnEnterNameOnClick;

            Label cancel = utils.CreateLabel("Cancel");
            cancel.Click += BtnCancelClick;



            btnEnter.Controls.Add(enter);
            btnCancel.Controls.Add(cancel);

            cancel.BringToFront();
            enter.BringToFront();
        }





        /// <summary>
        /// Check if the name is empty and save it to the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnterNameOnClick(object sender, EventArgs e)
        {
            // SFX: Main Button Sound

            if (tbName.Text.Trim() == "")
            {
                tbName.Text = "Anonymous";
            }

            string res = business.SaveUserName(tbName.Text);
            if (res == "Success")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(res);
            }

        }

        /// <summary>
        /// Cancel the name entry and close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelClick(object sender, EventArgs e)
        {
            // SFX: Main Button Sound
            this.Close();
        }

        /// <summary>
        /// Exit the form when the Escape key is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // SFX: Main Button Sound
                BtnEnterNameOnClick(sender, e);
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                // SFX: Main Button Sound
                BtnCancelClick(sender, e);
            }
        }
    }
}
