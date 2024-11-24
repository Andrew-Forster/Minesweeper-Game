namespace MinesweeperGUIApp
{
    partial class BoardGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoardGUI));
            lblTimer = new Label();
            panelSidebar = new FlowLayoutPanel();
            btnQuit = new PictureBox();
            lblScoreText = new Label();
            lblScore = new Label();
            lblRewardsText = new Label();
            panelRewards = new FlowLayoutPanel();
            tmrTimer = new System.Windows.Forms.Timer(components);
            panelBoard = new Panel();
            lblUsingReward = new Label();
            panelCenterBoard = new Panel();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnQuit).BeginInit();
            panelCenterBoard.SuspendLayout();
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.Font = new Font("Azonix", 12F);
            lblTimer.ForeColor = Color.FromArgb(192, 255, 192);
            lblTimer.Location = new Point(4, 78);
            lblTimer.Margin = new Padding(4, 0, 4, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(236, 44);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "00:00:00";
            lblTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSidebar
            // 
            panelSidebar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelSidebar.BackColor = Color.Transparent;
            panelSidebar.Controls.Add(btnQuit);
            panelSidebar.Controls.Add(lblTimer);
            panelSidebar.Controls.Add(lblScoreText);
            panelSidebar.Controls.Add(lblScore);
            panelSidebar.Controls.Add(lblRewardsText);
            panelSidebar.Controls.Add(panelRewards);
            panelSidebar.Location = new Point(7, 4);
            panelSidebar.Margin = new Padding(4, 2, 4, 2);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 508);
            panelSidebar.TabIndex = 2;
            // 
            // btnQuit
            // 
            btnQuit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnQuit.BackColor = Color.Transparent;
            btnQuit.Cursor = Cursors.Hand;
            btnQuit.Image = (Image)resources.GetObject("btnQuit.Image");
            btnQuit.Location = new Point(3, 3);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(237, 72);
            btnQuit.SizeMode = PictureBoxSizeMode.StretchImage;
            btnQuit.TabIndex = 17;
            btnQuit.TabStop = false;
            btnQuit.Click += BtnQuitOnClick;
            // 
            // lblScoreText
            // 
            lblScoreText.Font = new Font("Azonix", 12F);
            lblScoreText.ForeColor = Color.FromArgb(192, 192, 255);
            lblScoreText.Location = new Point(7, 122);
            lblScoreText.Margin = new Padding(7, 0, 4, 0);
            lblScoreText.Name = "lblScoreText";
            lblScoreText.Size = new Size(124, 38);
            lblScoreText.TabIndex = 2;
            lblScoreText.Text = "Score:";
            lblScoreText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            lblScore.Font = new Font("Azonix", 12F);
            lblScore.ForeColor = Color.FromArgb(128, 128, 255);
            lblScore.ImageAlign = ContentAlignment.MiddleLeft;
            lblScore.Location = new Point(139, 122);
            lblScore.Margin = new Padding(4, 0, 4, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(102, 38);
            lblScore.TabIndex = 3;
            lblScore.Text = "0";
            lblScore.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRewardsText
            // 
            lblRewardsText.Font = new Font("Azonix", 12F);
            lblRewardsText.ForeColor = Color.FromArgb(255, 255, 192);
            lblRewardsText.Location = new Point(7, 160);
            lblRewardsText.Margin = new Padding(7, 0, 4, 0);
            lblRewardsText.Name = "lblRewardsText";
            lblRewardsText.Size = new Size(198, 38);
            lblRewardsText.TabIndex = 5;
            lblRewardsText.Text = "Rewards:";
            lblRewardsText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelRewards
            // 
            panelRewards.Dock = DockStyle.Bottom;
            panelRewards.Location = new Point(3, 201);
            panelRewards.Name = "panelRewards";
            panelRewards.Size = new Size(237, 294);
            panelRewards.TabIndex = 18;
            // 
            // tmrTimer
            // 
            tmrTimer.Interval = 1000;
            tmrTimer.Tick += Timer_OnTick;
            // 
            // panelBoard
            // 
            panelBoard.Anchor = AnchorStyles.None;
            panelBoard.AutoSize = true;
            panelBoard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelBoard.BackColor = Color.Transparent;
            panelBoard.Location = new Point(208, 198);
            panelBoard.Margin = new Padding(4, 2, 4, 2);
            panelBoard.Name = "panelBoard";
            panelBoard.Size = new Size(0, 0);
            panelBoard.TabIndex = 3;
            // 
            // lblUsingReward
            // 
            lblUsingReward.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblUsingReward.BackColor = Color.Transparent;
            lblUsingReward.ForeColor = Color.FromArgb(255, 255, 192);
            lblUsingReward.Location = new Point(270, 490);
            lblUsingReward.Name = "lblUsingReward";
            lblUsingReward.Size = new Size(518, 22);
            lblUsingReward.TabIndex = 4;
            lblUsingReward.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCenterBoard
            // 
            panelCenterBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCenterBoard.BackColor = Color.Transparent;
            panelCenterBoard.Controls.Add(panelBoard);
            panelCenterBoard.Location = new Point(264, 7);
            panelCenterBoard.Name = "panelCenterBoard";
            panelCenterBoard.Size = new Size(524, 502);
            panelCenterBoard.TabIndex = 5;
            // 
            // BoardGUI
            // 
            AutoScaleDimensions = new SizeF(11F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 521);
            Controls.Add(panelCenterBoard);
            Controls.Add(lblUsingReward);
            Controls.Add(panelSidebar);
            Font = new Font("Azonix", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            Name = "BoardGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            ResizeEnd += FrmResizeEnd;
            Resize += FrmMaximizedCheck;
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnQuit).EndInit();
            panelCenterBoard.ResumeLayout(false);
            panelCenterBoard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblTimer;
        private FlowLayoutPanel panelSidebar;
        private System.Windows.Forms.Timer tmrTimer;
        private Label lblScoreText;
        private Panel panelBoard;
        private Label lblScore;
        private Label lblRewardsText;
        private PictureBox btnQuit;
        private FlowLayoutPanel panelRewards;
        private Label lblUsingReward;
        private Panel panelCenterBoard;
    }
}