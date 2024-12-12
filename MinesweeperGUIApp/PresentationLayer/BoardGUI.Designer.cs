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
            panelScoreHolder = new Panel();
            lblScore = new Label();
            panelTimerHolder = new Panel();
            panelRewards = new FlowLayoutPanel();
            btnQuit = new PictureBox();
            tmrTimer = new System.Windows.Forms.Timer(components);
            panelBoard = new Panel();
            lblUsingReward = new Label();
            panelCenterBoard = new Panel();
            lblScoreIncrement = new Label();
            panelSidebar.SuspendLayout();
            panelScoreHolder.SuspendLayout();
            panelTimerHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnQuit).BeginInit();
            panelCenterBoard.SuspendLayout();
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.Font = new Font("Azonix", 12F);
            lblTimer.ForeColor = Color.Silver;
            lblTimer.Location = new Point(3, 7);
            lblTimer.Margin = new Padding(4, 0, 4, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(168, 44);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "00:00:00";
            lblTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSidebar
            // 
            panelSidebar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelSidebar.BackColor = Color.Transparent;
            panelSidebar.Controls.Add(panelScoreHolder);
            panelSidebar.Controls.Add(panelTimerHolder);
            panelSidebar.Controls.Add(panelRewards);
            panelSidebar.Location = new Point(7, 4);
            panelSidebar.Margin = new Padding(4, 2, 4, 2);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 421);
            panelSidebar.TabIndex = 2;
            // 
            // panelScoreHolder
            // 
            panelScoreHolder.BackgroundImage = (Image)resources.GetObject("panelScoreHolder.BackgroundImage");
            panelScoreHolder.BackgroundImageLayout = ImageLayout.Stretch;
            panelScoreHolder.Controls.Add(lblScore);
            panelScoreHolder.Location = new Point(3, 3);
            panelScoreHolder.Name = "panelScoreHolder";
            panelScoreHolder.Size = new Size(175, 60);
            panelScoreHolder.TabIndex = 5;
            // 
            // lblScore
            // 
            lblScore.Font = new Font("Azonix", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.Black;
            lblScore.ImageAlign = ContentAlignment.MiddleLeft;
            lblScore.Location = new Point(17, 9);
            lblScore.Margin = new Padding(4, 0, 4, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(154, 38);
            lblScore.TabIndex = 3;
            lblScore.Text = "0";
            lblScore.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelTimerHolder
            // 
            panelTimerHolder.BackgroundImage = (Image)resources.GetObject("panelTimerHolder.BackgroundImage");
            panelTimerHolder.BackgroundImageLayout = ImageLayout.Stretch;
            panelTimerHolder.Controls.Add(lblTimer);
            panelTimerHolder.Location = new Point(3, 69);
            panelTimerHolder.Name = "panelTimerHolder";
            panelTimerHolder.Size = new Size(175, 60);
            panelTimerHolder.TabIndex = 4;
            // 
            // panelRewards
            // 
            panelRewards.Dock = DockStyle.Bottom;
            panelRewards.Location = new Point(3, 135);
            panelRewards.Name = "panelRewards";
            panelRewards.Size = new Size(237, 315);
            panelRewards.TabIndex = 18;
            // 
            // btnQuit
            // 
            btnQuit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnQuit.BackColor = Color.Transparent;
            btnQuit.Cursor = Cursors.Hand;
            btnQuit.Image = (Image)resources.GetObject("btnQuit.Image");
            btnQuit.Location = new Point(7, 432);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(237, 72);
            btnQuit.SizeMode = PictureBoxSizeMode.StretchImage;
            btnQuit.TabIndex = 17;
            btnQuit.TabStop = false;
            btnQuit.Click += BtnQuitOnClick;
            // 
            // tmrTimer
            // 
            tmrTimer.Interval = 1000;
            tmrTimer.Tick += TimerOnTick;
            // 
            // panelBoard
            // 
            panelBoard.Anchor = AnchorStyles.None;
            panelBoard.AutoSize = true;
            panelBoard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelBoard.BackColor = Color.Transparent;
            panelBoard.Font = new Font("Azonix", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBoard.Location = new Point(208, 186);
            panelBoard.Margin = new Padding(4, 2, 4, 20);
            panelBoard.Name = "panelBoard";
            panelBoard.Size = new Size(0, 0);
            panelBoard.TabIndex = 3;
            // 
            // lblUsingReward
            // 
            lblUsingReward.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblUsingReward.BackColor = Color.Transparent;
            lblUsingReward.ForeColor = Color.FromArgb(255, 255, 192);
            lblUsingReward.Location = new Point(264, 464);
            lblUsingReward.Name = "lblUsingReward";
            lblUsingReward.Size = new Size(518, 34);
            lblUsingReward.TabIndex = 4;
            lblUsingReward.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCenterBoard
            // 
            panelCenterBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCenterBoard.AutoScroll = true;
            panelCenterBoard.BackColor = Color.Transparent;
            panelCenterBoard.Controls.Add(panelBoard);
            panelCenterBoard.Location = new Point(264, 7);
            panelCenterBoard.Name = "panelCenterBoard";
            panelCenterBoard.Size = new Size(524, 479);
            panelCenterBoard.TabIndex = 5;
            // 
            // lblScoreIncrement
            // 
            lblScoreIncrement.AutoSize = true;
            lblScoreIncrement.BackColor = Color.Gray;
            lblScoreIncrement.ForeColor = Color.FromArgb(128, 255, 128);
            lblScoreIncrement.Location = new Point(264, 503);
            lblScoreIncrement.Name = "lblScoreIncrement";
            lblScoreIncrement.Size = new Size(32, 18);
            lblScoreIncrement.TabIndex = 18;
            lblScoreIncrement.Text = "+0";
            // 
            // BoardGUI
            // 
            AutoScaleDimensions = new SizeF(14F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 507);
            Controls.Add(lblUsingReward);
            Controls.Add(lblScoreIncrement);
            Controls.Add(btnQuit);
            Controls.Add(panelCenterBoard);
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
            panelScoreHolder.ResumeLayout(false);
            panelTimerHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnQuit).EndInit();
            panelCenterBoard.ResumeLayout(false);
            panelCenterBoard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTimer;
        private FlowLayoutPanel panelSidebar;
        private System.Windows.Forms.Timer tmrTimer;
        private Panel panelBoard;
        private PictureBox btnQuit;
        private FlowLayoutPanel panelRewards;
        private Label lblUsingReward;
        private Panel panelCenterBoard;
        private Panel panelTimerHolder;
        private Label lblScoreIncrement;
        private Panel panelScoreHolder;
        private Label lblScore;
    }
}