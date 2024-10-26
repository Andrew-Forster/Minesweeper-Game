namespace MinesweeperGUIApp
{
    public partial class Minesweeper : Form
    {
        public Minesweeper()
        {
            InitializeComponent();
            panelCustom.Visible = false;
            this.MaximumSize = new Size(300, 270);
            this.Height = 270;


            tipCustom.SetToolTip(rbCustom, "Allows you to set your own board size and mine count.");

            tipEasy.SetToolTip(rbEasy, "9x9 board with 10 mines.");
            tipMedium.SetToolTip(rbMedium, "16x16 board with 40 mines.");
            tipHard.SetToolTip(rbHard, "16x30 board with 99 mines.");
        }

        private void DifficultySelected(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Text == "Custom")
            {
                panelCustom.Visible = true;
                this.MaximumSize = new Size(300, 413);
                this.Height = 413;
            }
            else
            {
                panelCustom.Visible = false;
                this.MaximumSize = new Size(300, 270);
                this.Height = 270;
            }

        }
    }
}
