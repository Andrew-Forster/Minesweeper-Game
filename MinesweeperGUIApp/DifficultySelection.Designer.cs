namespace MinesweeperGUIApp
{
    partial class Minesweeper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Minesweeper));
            panelMain = new Panel();
            rbCustom = new RadioButton();
            rbHard = new RadioButton();
            rbMedium = new RadioButton();
            label1 = new Label();
            rbEasy = new RadioButton();
            btnStart = new Button();
            tipCustom = new ToolTip(components);
            tipEasy = new ToolTip(components);
            tipMedium = new ToolTip(components);
            tipHard = new ToolTip(components);
            panelCustom = new Panel();
            tbMineCount = new TrackBar();
            lblMineCount = new Label();
            tbBoardSize = new TrackBar();
            lblBoardSize = new Label();
            pictureBox1 = new PictureBox();
            BtnHighScores = new Button();
            btnChangeName = new Button();
            panelMain.SuspendLayout();
            panelCustom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbMineCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbBoardSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.Transparent;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(rbCustom);
            panelMain.Controls.Add(rbHard);
            panelMain.Controls.Add(rbMedium);
            panelMain.Controls.Add(label1);
            panelMain.Controls.Add(rbEasy);
            panelMain.ForeColor = Color.White;
            panelMain.Location = new Point(12, 158);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(309, 196);
            panelMain.TabIndex = 0;
            // 
            // rbCustom
            // 
            rbCustom.Cursor = Cursors.Hand;
            rbCustom.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            rbCustom.FlatAppearance.CheckedBackColor = Color.Red;
            rbCustom.FlatStyle = FlatStyle.Popup;
            rbCustom.ForeColor = Color.FromArgb(255, 128, 255);
            rbCustom.Location = new Point(3, 150);
            rbCustom.Name = "rbCustom";
            rbCustom.Size = new Size(295, 27);
            rbCustom.TabIndex = 5;
            rbCustom.TabStop = true;
            rbCustom.Text = "Custom";
            rbCustom.TextAlign = ContentAlignment.MiddleCenter;
            rbCustom.UseVisualStyleBackColor = true;
            rbCustom.CheckedChanged += DifficultySelected;
            // 
            // rbHard
            // 
            rbHard.Cursor = Cursors.Hand;
            rbHard.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            rbHard.FlatAppearance.CheckedBackColor = Color.Red;
            rbHard.FlatStyle = FlatStyle.Popup;
            rbHard.ForeColor = Color.FromArgb(255, 128, 128);
            rbHard.Location = new Point(3, 117);
            rbHard.Name = "rbHard";
            rbHard.Size = new Size(301, 27);
            rbHard.TabIndex = 4;
            rbHard.TabStop = true;
            rbHard.Text = "Hard";
            rbHard.TextAlign = ContentAlignment.MiddleCenter;
            rbHard.UseVisualStyleBackColor = true;
            rbHard.CheckedChanged += DifficultySelected;
            // 
            // rbMedium
            // 
            rbMedium.Cursor = Cursors.Hand;
            rbMedium.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            rbMedium.FlatAppearance.CheckedBackColor = Color.Red;
            rbMedium.FlatStyle = FlatStyle.Popup;
            rbMedium.ForeColor = Color.Yellow;
            rbMedium.Location = new Point(3, 84);
            rbMedium.Name = "rbMedium";
            rbMedium.Size = new Size(301, 27);
            rbMedium.TabIndex = 3;
            rbMedium.TabStop = true;
            rbMedium.Text = "Medium";
            rbMedium.TextAlign = ContentAlignment.MiddleCenter;
            rbMedium.UseVisualStyleBackColor = true;
            rbMedium.CheckedChanged += DifficultySelected;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 15);
            label1.Name = "label1";
            label1.Size = new Size(303, 23);
            label1.TabIndex = 1;
            label1.Text = "Choose a Difficulty";
            // 
            // rbEasy
            // 
            rbEasy.Cursor = Cursors.Hand;
            rbEasy.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            rbEasy.FlatAppearance.CheckedBackColor = Color.Red;
            rbEasy.FlatStyle = FlatStyle.Popup;
            rbEasy.ForeColor = Color.Lime;
            rbEasy.Location = new Point(3, 51);
            rbEasy.Name = "rbEasy";
            rbEasy.Size = new Size(301, 27);
            rbEasy.TabIndex = 2;
            rbEasy.TabStop = true;
            rbEasy.Text = "Easy";
            rbEasy.TextAlign = ContentAlignment.MiddleCenter;
            rbEasy.UseVisualStyleBackColor = true;
            rbEasy.CheckedChanged += DifficultySelected;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.LimeGreen;
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatStyle = FlatStyle.Popup;
            btnStart.Location = new Point(12, 360);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(508, 41);
            btnStart.TabIndex = 6;
            btnStart.Text = "Start Game";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += StartGameOnClick;
            // 
            // tipCustom
            // 
            tipCustom.ToolTipTitle = "Customize your difficulty";
            // 
            // tipEasy
            // 
            tipEasy.ToolTipTitle = "Easy Difficulty";
            // 
            // tipMedium
            // 
            tipMedium.ToolTipTitle = "Medium Difficulty";
            // 
            // tipHard
            // 
            tipHard.ToolTipTitle = "Hard Difficulty";
            // 
            // panelCustom
            // 
            panelCustom.BackColor = Color.Transparent;
            panelCustom.BorderStyle = BorderStyle.FixedSingle;
            panelCustom.Controls.Add(tbMineCount);
            panelCustom.Controls.Add(lblMineCount);
            panelCustom.Controls.Add(tbBoardSize);
            panelCustom.Controls.Add(lblBoardSize);
            panelCustom.ForeColor = Color.White;
            panelCustom.Location = new Point(327, 159);
            panelCustom.Name = "panelCustom";
            panelCustom.Size = new Size(193, 196);
            panelCustom.TabIndex = 1;
            // 
            // tbMineCount
            // 
            tbMineCount.AutoSize = false;
            tbMineCount.BackColor = Color.Gray;
            tbMineCount.Location = new Point(3, 105);
            tbMineCount.Maximum = 6;
            tbMineCount.Minimum = 5;
            tbMineCount.Name = "tbMineCount";
            tbMineCount.Size = new Size(185, 38);
            tbMineCount.TabIndex = 10;
            tbMineCount.TickStyle = TickStyle.Both;
            tbMineCount.Value = 5;
            tbMineCount.Scroll += MineCountOnChanged;
            // 
            // lblMineCount
            // 
            lblMineCount.AutoSize = true;
            lblMineCount.Font = new Font("Azonix", 10.8F);
            lblMineCount.Location = new Point(3, 84);
            lblMineCount.Name = "lblMineCount";
            lblMineCount.Size = new Size(159, 18);
            lblMineCount.TabIndex = 9;
            lblMineCount.Text = "Mine Count: 5";
            // 
            // tbBoardSize
            // 
            tbBoardSize.AutoSize = false;
            tbBoardSize.BackColor = Color.Gray;
            tbBoardSize.Enabled = false;
            tbBoardSize.Location = new Point(3, 38);
            tbBoardSize.Maximum = 32;
            tbBoardSize.Minimum = 5;
            tbBoardSize.Name = "tbBoardSize";
            tbBoardSize.Size = new Size(185, 39);
            tbBoardSize.TabIndex = 2;
            tbBoardSize.TickStyle = TickStyle.Both;
            tbBoardSize.Value = 5;
            tbBoardSize.Scroll += BoardSizeOnChanged;
            // 
            // lblBoardSize
            // 
            lblBoardSize.AutoSize = true;
            lblBoardSize.Font = new Font("Azonix", 10.8F);
            lblBoardSize.Location = new Point(3, 15);
            lblBoardSize.Name = "lblBoardSize";
            lblBoardSize.Size = new Size(156, 18);
            lblBoardSize.TabIndex = 8;
            lblBoardSize.Text = "Board Size: 5";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(508, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // BtnHighScores
            // 
            BtnHighScores.BackColor = Color.FromArgb(0, 192, 192);
            BtnHighScores.Cursor = Cursors.Hand;
            BtnHighScores.FlatStyle = FlatStyle.Popup;
            BtnHighScores.Font = new Font("Azonix", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnHighScores.Location = new Point(12, 408);
            BtnHighScores.Margin = new Padding(4, 2, 4, 2);
            BtnHighScores.Name = "BtnHighScores";
            BtnHighScores.Size = new Size(252, 41);
            BtnHighScores.TabIndex = 8;
            BtnHighScores.Text = "High Scores";
            BtnHighScores.UseVisualStyleBackColor = false;
            // 
            // btnChangeName
            // 
            btnChangeName.BackColor = Color.SteelBlue;
            btnChangeName.Cursor = Cursors.Hand;
            btnChangeName.FlatStyle = FlatStyle.Popup;
            btnChangeName.Font = new Font("Azonix", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangeName.Location = new Point(269, 408);
            btnChangeName.Margin = new Padding(4, 2, 4, 2);
            btnChangeName.Name = "btnChangeName";
            btnChangeName.Size = new Size(251, 41);
            btnChangeName.TabIndex = 9;
            btnChangeName.Text = "Change Name";
            btnChangeName.UseVisualStyleBackColor = false;
            btnChangeName.Click += BtnChangeNameOnClick;
            // 
            // Minesweeper
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(534, 460);
            Controls.Add(btnChangeName);
            Controls.Add(BtnHighScores);
            Controls.Add(pictureBox1);
            Controls.Add(panelCustom);
            Controls.Add(btnStart);
            Controls.Add(panelMain);
            Font = new Font("Azonix", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(300, 270);
            Name = "Minesweeper";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelCustom.ResumeLayout(false);
            panelCustom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbMineCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbBoardSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Label label1;
        private RadioButton rbCustom;
        private RadioButton rbHard;
        private RadioButton rbMedium;
        private RadioButton rbEasy;
        private ToolTip tipCustom;
        private ToolTip tipEasy;
        private ToolTip tipMedium;
        private ToolTip tipHard;
        private Button btnStart;
        private Panel panelCustom;
        private Label lblBoardSize;
        private TrackBar tbBoardSize;
        private Label lblMineCount;
        private TrackBar tbMineCount;
        private PictureBox pictureBox1;
        private Button BtnHighScores;
        private Button btnChangeName;
    }
}
