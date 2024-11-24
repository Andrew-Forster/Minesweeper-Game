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




        public PictureBox MakeTile(int x, int y, int boardSize, int windowHeight) => MakeTile(x, y, DetermineTileSize(boardSize, windowHeight));
        /// <summary>
        /// Creates a tile for the board
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PictureBox MakeTile(int x, int y, int size)
        {
            PictureBox button = new PictureBox();

            button.Location = new Point(y * size, x * size);

            button.SizeMode = PictureBoxSizeMode.StretchImage;
            button.Size = new Size(size, size);
            button.Tag = new Point(x, y);
            button.Cursor = Cursors.Hand;
            button.Image = tile;

            return button;
        }

        public int DetermineTileSize(int boardSize, int windowHeight)
        {
            windowHeight -= 100;
            int size = windowHeight / boardSize;
            return size;
        }



        public Label CreateLabel(string text) => CreateLabel(text, Color.FromArgb(48, 33, 33), 22F);
        public Label CreateLabel(string text, float fontSize) => CreateLabel(text, Color.FromArgb(48, 33, 33), fontSize);

        /// <summary>
        /// Creates a label with the specified text, color, and font size
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="fontSize"></param>
        /// <returns></returns>
        public Label CreateLabel(string text, Color color, float fontSize)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Azonix", fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.ForeColor = color;
            label.BackColor = Color.Transparent;
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;

            return label;

        }

        public PictureBox CreateButton(string text)
        {
            PictureBox btn = new PictureBox();
            btn.SizeMode = PictureBoxSizeMode.StretchImage;
            btn.Size = new Size(175, 72);
            btn.Cursor = Cursors.Hand;
            btn.Image = Image.FromFile("Assets/BtnYellow.png");

            Label label = CreateLabel(text, Color.White, 12F);
            btn.Controls.Add(label);
            label.BringToFront();

            return btn;
        }

        public PictureBox FindPictureBoxWithTag(Control parent, object tag)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is PictureBox pictureBox && Equals(pictureBox.Tag, tag))
                {
                    return pictureBox;
                }
            }
            return null;
        }



    }
}