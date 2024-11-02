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
            label3 = new Label();
            label2 = new Label();
            btnStart = new Button();
            rbCustom = new RadioButton();
            rbHard = new RadioButton();
            rbMedium = new RadioButton();
            rbEasy = new RadioButton();
            label1 = new Label();
            tipCustom = new ToolTip(components);
            tipEasy = new ToolTip(components);
            tipMedium = new ToolTip(components);
            tipHard = new ToolTip(components);
            panelCustom = new Panel();
            tbMineCount = new TrackBar();
            lblMineCount = new Label();
            tbBoardSize = new TrackBar();
            lblBoardSize = new Label();
            panelMain.SuspendLayout();
            panelCustom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbMineCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbBoardSize).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(label3);
            panelMain.Controls.Add(label2);
            panelMain.Controls.Add(btnStart);
            panelMain.Controls.Add(rbCustom);
            panelMain.Controls.Add(rbHard);
            panelMain.Controls.Add(rbMedium);
            panelMain.Controls.Add(rbEasy);
            panelMain.Controls.Add(label1);
            panelMain.ForeColor = Color.White;
            panelMain.Location = new Point(17, 12);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(250, 194);
            panelMain.TabIndex = 0;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(0, 110);
            label3.Name = "label3";
            label3.Size = new Size(250, 2);
            label3.TabIndex = 7;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(0, 142);
            label2.Name = "label2";
            label2.Size = new Size(250, 2);
            label2.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.LimeGreen;
            btnStart.FlatStyle = FlatStyle.Popup;
            btnStart.Location = new Point(3, 147);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(242, 41);
            btnStart.TabIndex = 6;
            btnStart.Text = "Start Game";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += StartGame_OnClick;
            // 
            // rbCustom
            // 
            rbCustom.AutoSize = true;
            rbCustom.Location = new Point(3, 115);
            rbCustom.Name = "rbCustom";
            rbCustom.Size = new Size(80, 24);
            rbCustom.TabIndex = 5;
            rbCustom.TabStop = true;
            rbCustom.Text = "Custom";
            rbCustom.UseVisualStyleBackColor = true;
            rbCustom.CheckedChanged += DifficultySelected;
            // 
            // rbHard
            // 
            rbHard.AutoSize = true;
            rbHard.Location = new Point(3, 83);
            rbHard.Name = "rbHard";
            rbHard.Size = new Size(63, 24);
            rbHard.TabIndex = 4;
            rbHard.TabStop = true;
            rbHard.Text = "Hard";
            rbHard.UseVisualStyleBackColor = true;
            rbHard.CheckedChanged += DifficultySelected;
            // 
            // rbMedium
            // 
            rbMedium.AutoSize = true;
            rbMedium.Location = new Point(3, 53);
            rbMedium.Name = "rbMedium";
            rbMedium.Size = new Size(85, 24);
            rbMedium.TabIndex = 3;
            rbMedium.TabStop = true;
            rbMedium.Text = "Medium";
            rbMedium.UseVisualStyleBackColor = true;
            rbMedium.CheckedChanged += DifficultySelected;
            // 
            // rbEasy
            // 
            rbEasy.AutoSize = true;
            rbEasy.Location = new Point(3, 23);
            rbEasy.Name = "rbEasy";
            rbEasy.Size = new Size(59, 24);
            rbEasy.TabIndex = 2;
            rbEasy.TabStop = true;
            rbEasy.Text = "Easy";
            rbEasy.UseVisualStyleBackColor = true;
            rbEasy.CheckedChanged += DifficultySelected;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 1;
            label1.Text = "Choose a Difficulty:";
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
            panelCustom.BorderStyle = BorderStyle.FixedSingle;
            panelCustom.Controls.Add(tbMineCount);
            panelCustom.Controls.Add(lblMineCount);
            panelCustom.Controls.Add(tbBoardSize);
            panelCustom.Controls.Add(lblBoardSize);
            panelCustom.ForeColor = Color.White;
            panelCustom.Location = new Point(17, 212);
            panelCustom.Name = "panelCustom";
            panelCustom.Size = new Size(250, 138);
            panelCustom.TabIndex = 1;
            // 
            // tbMineCount
            // 
            tbMineCount.AutoSize = false;
            tbMineCount.Location = new Point(-1, 89);
            tbMineCount.Maximum = 6;
            tbMineCount.Minimum = 5;
            tbMineCount.Name = "tbMineCount";
            tbMineCount.Size = new Size(242, 40);
            tbMineCount.TabIndex = 10;
            tbMineCount.TickStyle = TickStyle.Both;
            tbMineCount.Value = 5;
            tbMineCount.Scroll += MineCount_OnChanged;
            // 
            // lblMineCount
            // 
            lblMineCount.AutoSize = true;
            lblMineCount.Location = new Point(-2, 66);
            lblMineCount.Name = "lblMineCount";
            lblMineCount.Size = new Size(100, 20);
            lblMineCount.TabIndex = 9;
            lblMineCount.Text = "Mine Count: 5";
            // 
            // tbBoardSize
            // 
            tbBoardSize.AutoSize = false;
            tbBoardSize.Location = new Point(0, 23);
            tbBoardSize.Maximum = 32;
            tbBoardSize.Minimum = 5;
            tbBoardSize.Name = "tbBoardSize";
            tbBoardSize.Size = new Size(242, 40);
            tbBoardSize.TabIndex = 2;
            tbBoardSize.TickStyle = TickStyle.Both;
            tbBoardSize.Value = 5;
            tbBoardSize.Scroll += BoardSize_OnChanged;
            // 
            // lblBoardSize
            // 
            lblBoardSize.AutoSize = true;
            lblBoardSize.Location = new Point(0, 0);
            lblBoardSize.Name = "lblBoardSize";
            lblBoardSize.Size = new Size(95, 20);
            lblBoardSize.TabIndex = 8;
            lblBoardSize.Text = "Board Size: 5";
            // 
            // Minesweeper
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(282, 366);
            Controls.Add(panelCustom);
            Controls.Add(panelMain);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(300, 413);
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
        private Label label2;
        private Label label3;
        private Panel panelCustom;
        private Label lblBoardSize;
        private TrackBar tbBoardSize;
        private Label lblMineCount;
        private TrackBar tbMineCount;
    }
}
