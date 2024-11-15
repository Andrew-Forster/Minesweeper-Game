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
using MinesweeperLibrary.BussinessLayer;

namespace MinesweeperGUIApp
{
    public partial class FrmNameEntry : Form
    {
        MinesweeperBusiness business = new MinesweeperBusiness();
        public FrmNameEntry()
        {
            InitializeComponent();

            tbName.Text = business.GetUserName();


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

        private void BtnEnterNameOnClick(object sender, EventArgs e)
        {
            if (tbName.Text.Trim(' ') == "")
            {
                tbName.Text = "Anonymous";
            }

            MessageBox.Show(business.SaveUserName(tbName.Text));
            this.Close();

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
