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
            lblTimer = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnQuit = new Button();
            lblScoreText = new Label();
            lblScore = new Label();
            tmrTimer = new System.Windows.Forms.Timer(components);
            panelBoard = new Panel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.Font = new Font("Azonix", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.ForeColor = Color.FromArgb(192, 255, 192);
            lblTimer.Location = new Point(3, 58);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(172, 58);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "00:00:00";
            lblTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(btnQuit);
            flowLayoutPanel1.Controls.Add(lblTimer);
            flowLayoutPanel1.Controls.Add(lblScoreText);
            flowLayoutPanel1.Controls.Add(lblScore);
            flowLayoutPanel1.Location = new Point(808, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(183, 540);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // btnQuit
            // 
            btnQuit.BackColor = Color.Maroon;
            btnQuit.FlatStyle = FlatStyle.Popup;
            btnQuit.Location = new Point(3, 3);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(172, 52);
            btnQuit.TabIndex = 0;
            btnQuit.Text = "Quit Game";
            btnQuit.UseVisualStyleBackColor = false;
            btnQuit.Click += BtnQuit_OnClick;
            // 
            // lblScoreText
            // 
            lblScoreText.Font = new Font("Azonix", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScoreText.ForeColor = Color.FromArgb(192, 192, 255);
            lblScoreText.Location = new Point(5, 116);
            lblScoreText.Margin = new Padding(5, 0, 3, 0);
            lblScoreText.Name = "lblScoreText";
            lblScoreText.Size = new Size(90, 51);
            lblScoreText.TabIndex = 2;
            lblScoreText.Text = "Score:";
            lblScoreText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            lblScore.Font = new Font("Azonix", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.FromArgb(128, 128, 255);
            lblScore.ImageAlign = ContentAlignment.MiddleLeft;
            lblScore.Location = new Point(101, 116);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(74, 51);
            lblScore.TabIndex = 3;
            lblScore.Text = "0";
            lblScore.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tmrTimer
            // 
            tmrTimer.Interval = 1000;
            tmrTimer.Tick += Timer_OnTick;
            // 
            // panelBoard
            // 
            panelBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBoard.AutoScroll = true;
            panelBoard.Location = new Point(4, 5);
            panelBoard.Name = "panelBoard";
            panelBoard.Size = new Size(798, 540);
            panelBoard.TabIndex = 3;
            // 
            // BoardGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(995, 557);
            Controls.Add(panelBoard);
            Controls.Add(flowLayoutPanel1);
            ForeColor = Color.White;
            MinimumSize = new Size(1013, 604);
            Name = "BoardGUI";
            Text = "Board";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lblTimer;
        private FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer tmrTimer;
        private Label lblScoreText;
        private Button btnQuit;
        private Panel panelBoard;
        private Label lblScore;
    }
}