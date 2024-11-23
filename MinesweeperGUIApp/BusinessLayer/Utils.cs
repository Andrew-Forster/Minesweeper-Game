using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGUIApp.BusinessLayer
{
    internal class Utils
    {
        Image tile = Image.FromFile("Assets/Tile.png");
        /// <summary>
        /// Creates a tile for the board
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PictureBox MakeTile(int x, int y)
        {
            PictureBox button = new PictureBox();
            button.Location = new Point(y * 50, x * 50);

            button.SizeMode = PictureBoxSizeMode.StretchImage;
            button.Size = new Size(50, 50);
            button.Tag = new Point(x, y);
            button.Cursor = Cursors.Hand;
            button.Image = tile;

            return button;
        }



    }
}