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

namespace MinesweeperGUIApp.PresentationLayer
{
    public partial class Loader : Form
    {
        DifficultySelection ds;
        public Loader()
        {
            InitializeComponent();
            this.TopMost = true;
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

            ds = new DifficultySelection(this);
        }

        /// <summary>
        /// Gives time for main form to load in
        /// Helps to prevent flickering on the main forms load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLoaded(object sender, EventArgs e)
        {
            ds.Show();
            Thread.Sleep(2000);
            this.Hide();
        }
    }
}
