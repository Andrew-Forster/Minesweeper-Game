using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinesweeperLibrary;

namespace MinesweeperGUIApp
{
    public partial class BoardGUI : Form
    {
        private Board board;
        int boardSize;
        private Dictionary<string, Image> imageCache = new Dictionary<string, Image>();



        public BoardGUI()
        {
            InitializeComponent();
        }

        public BoardGUI(Board board)
        {
            InitializeComponent();
            this.board = board;
            boardSize = board.BoardSize;
            GenerateUI();

        }

        private void LoadImages()
        {
            // Load each image once and store it in the dictionary
            imageCache["Bomb"] = Image.FromFile("Assets/Bomb.png");
            imageCache["Gold"] = Image.FromFile("Assets/Gold.png");
            imageCache["TileFlat"] = Image.FromFile("Assets/Tile Flat.png");
            imageCache["Tile1"] = Image.FromFile("Assets/Tile 1.png");
            imageCache["Tile2"] = Image.FromFile("Assets/Tile 2.png");

            for (int i = 1; i <= 8; i++)
            {
                string numberImagePath = $"Assets/Number {i}.png";
                if (File.Exists(numberImagePath))
                {
                    imageCache[$"Number{i}"] = Image.FromFile(numberImagePath);
                }
            }

            imageCache["Skull"] = Image.FromFile("Assets/Skull.png");
        }


        public void GenerateUI()
        {
            LoadImages();
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    PictureBox button = new PictureBox();
                    button.SizeMode = PictureBoxSizeMode.StretchImage;
                    button.Size = new Size(50, 50);
                    button.Location = new Point(50 * j, 50 * i);
                    button.Click += Button_Click;
                    button.Tag = new Point(i, j);
                    panelBoard.Controls.Add(button);
                    UpdateButton(i, j);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            Point point = (Point)button.Tag;
            int row = point.X;
            int col = point.Y;

            board.Reveal(row + 1, col + 1);

            UpdateUI();
        }

        private void UpdateUI()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    UpdateButton(i, j);
                }
            }
        }

        private void UpdateButton(int row, int col)
        {
            PictureBox button = (PictureBox)panelBoard.Controls[row * boardSize + col];
            Cell cell = board.Cells[row, col];

            if (cell.IsRevealed)
            {
                button.Image =
                    cell.IsMine ? imageCache["Bomb"]
                    : (cell.RewardType != "None") ? imageCache["Gold"]
                    : cell.AdjacentMines == 0 ? imageCache["TileFlat"]
                    : imageCache[$"Number{cell.AdjacentMines}"];
            }
            else
            {
                button.Image =
                    cell.IsFlagged ? imageCache["Skull"]
                        : (row % 2 == 0 ? imageCache["Tile1"] : imageCache["Tile2"]);
            }
        }



    }
}
