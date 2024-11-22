namespace MinesweeperGUIApp
{
    partial class DifficultySelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DifficultySelection));
            panelMain = new Panel();
            btnCustom = new PictureBox();
            btnEasy = new PictureBox();
            btnMedium = new PictureBox();
            btnHard = new PictureBox();
            tipCustom = new ToolTip(components);
            tipEasy = new ToolTip(components);
            tipMedium = new ToolTip(components);
            tipHard = new ToolTip(components);
            panelCustom = new Panel();
            tbMineCount = new TrackBar();
            lblMineCount = new Label();
            tbBoardSize = new TrackBar();
            lblBoardSize = new Label();
            Btn = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCustom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEasy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMedium).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnHard).BeginInit();
            panelCustom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbMineCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbBoardSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Btn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.Transparent;
            panelMain.Controls.Add(btnCustom);
            panelMain.Controls.Add(btnEasy);
            panelMain.Controls.Add(btnMedium);
            panelMain.Controls.Add(btnHard);
            panelMain.ForeColor = Color.White;
            panelMain.Location = new Point(244, 191);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(438, 160);
            panelMain.TabIndex = 0;
            // 
            // btnCustom
            // 
            btnCustom.BackColor = Color.Transparent;
            btnCustom.Cursor = Cursors.Hand;
            btnCustom.Image = (Image)resources.GetObject("btnCustom.Image");
            btnCustom.Location = new Point(216, 81);
            btnCustom.Name = "btnCustom";
            btnCustom.Size = new Size(207, 72);
            btnCustom.SizeMode = PictureBoxSizeMode.StretchImage;
            btnCustom.TabIndex = 13;
            btnCustom.TabStop = false;
            btnCustom.Click += DifficultySelected;
            btnCustom.MouseEnter += BtnCustomHoverEnter;
            // 
            // btnEasy
            // 
            btnEasy.BackColor = Color.Transparent;
            btnEasy.Cursor = Cursors.Hand;
            btnEasy.Image = (Image)resources.GetObject("btnEasy.Image");
            btnEasy.Location = new Point(5, 3);
            btnEasy.Name = "btnEasy";
            btnEasy.Size = new Size(207, 72);
            btnEasy.SizeMode = PictureBoxSizeMode.StretchImage;
            btnEasy.TabIndex = 12;
            btnEasy.TabStop = false;
            btnEasy.Click += DifficultySelected;
            btnEasy.MouseEnter += BtnCustomHoverEnter;
            // 
            // btnMedium
            // 
            btnMedium.BackColor = Color.Transparent;
            btnMedium.Cursor = Cursors.Hand;
            btnMedium.Image = (Image)resources.GetObject("btnMedium.Image");
            btnMedium.Location = new Point(216, 3);
            btnMedium.Name = "btnMedium";
            btnMedium.Size = new Size(207, 72);
            btnMedium.SizeMode = PictureBoxSizeMode.StretchImage;
            btnMedium.TabIndex = 11;
            btnMedium.TabStop = false;
            btnMedium.Click += DifficultySelected;
            btnMedium.MouseEnter += BtnCustomHoverEnter;
            // 
            // btnHard
            // 
            btnHard.BackColor = Color.Transparent;
            btnHard.Cursor = Cursors.Hand;
            btnHard.Image = (Image)resources.GetObject("btnHard.Image");
            btnHard.Location = new Point(5, 81);
            btnHard.Name = "btnHard";
            btnHard.Size = new Size(207, 72);
            btnHard.SizeMode = PictureBoxSizeMode.StretchImage;
            btnHard.TabIndex = 10;
            btnHard.TabStop = false;
            btnHard.Click += DifficultySelected;
            btnHard.MouseEnter += BtnCustomHoverEnter;
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
            panelCustom.BackColor = Color.Gray;
            panelCustom.BorderStyle = BorderStyle.FixedSingle;
            panelCustom.Controls.Add(tbMineCount);
            panelCustom.Controls.Add(lblMineCount);
            panelCustom.Controls.Add(tbBoardSize);
            panelCustom.Controls.Add(lblBoardSize);
            panelCustom.ForeColor = Color.White;
            panelCustom.Location = new Point(717, 223);
            panelCustom.Name = "panelCustom";
            panelCustom.Size = new Size(182, 206);
            panelCustom.TabIndex = 1;
            // 
            // tbMineCount
            // 
            tbMineCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbMineCount.AutoSize = false;
            tbMineCount.BackColor = Color.Gray;
            tbMineCount.Enabled = false;
            tbMineCount.Location = new Point(3, 105);
            tbMineCount.Maximum = 6;
            tbMineCount.Minimum = 5;
            tbMineCount.Name = "tbMineCount";
            tbMineCount.Size = new Size(171, 38);
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
            tbBoardSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbBoardSize.AutoSize = false;
            tbBoardSize.BackColor = Color.Gray;
            tbBoardSize.Enabled = false;
            tbBoardSize.Location = new Point(3, 38);
            tbBoardSize.Maximum = 24;
            tbBoardSize.Minimum = 5;
            tbBoardSize.Name = "tbBoardSize";
            tbBoardSize.Size = new Size(171, 39);
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
            // Btn
            // 
            Btn.BackColor = Color.Transparent;
            Btn.Cursor = Cursors.Hand;
            Btn.Image = (Image)resources.GetObject("Btn.Image");
            Btn.Location = new Point(261, 357);
            Btn.Name = "Btn";
            Btn.Size = new Size(393, 72);
            Btn.SizeMode = PictureBoxSizeMode.StretchImage;
            Btn.TabIndex = 14;
            Btn.TabStop = false;
            Btn.Click += StartGameOnClick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 239);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += BtnChangeNameOnClick;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 329);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(207, 72);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            pictureBox2.Click += BtnHighScoresOnClick;
            // 
            // DifficultySelection
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(911, 556);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Btn);
            Controls.Add(panelCustom);
            Controls.Add(panelMain);
            Font = new Font("Azonix", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(300, 270);
            Name = "DifficultySelection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            MouseEnter += BtnEnteredForm;
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnCustom).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEasy).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMedium).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnHard).EndInit();
            panelCustom.ResumeLayout(false);
            panelCustom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbMineCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbBoardSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)Btn).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private ToolTip tipCustom;
        private ToolTip tipEasy;
        private ToolTip tipMedium;
        private ToolTip tipHard;
        private Panel panelCustom;
        private Label lblBoardSize;
        private TrackBar tbBoardSize;
        private Label lblMineCount;
        private TrackBar tbMineCount;
        private PictureBox btnHard;
        private PictureBox btnCustom;
        private PictureBox btnEasy;
        private PictureBox btnMedium;
        private PictureBox Btn;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
