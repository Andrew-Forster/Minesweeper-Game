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
            label2 = new Label();
            btnReset = new Button();
            tmrTimer = new System.Windows.Forms.Timer(components);
            panelBoard = new Panel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.Location = new Point(3, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(161, 58);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "00:00:00";
            lblTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(lblTimer);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(btnReset);
            flowLayoutPanel1.Location = new Point(820, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(164, 540);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.Location = new Point(3, 58);
            label2.Name = "label2";
            label2.Size = new Size(161, 94);
            label2.TabIndex = 2;
            label2.Text = "Score";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Maroon;
            btnReset.FlatStyle = FlatStyle.Popup;
            btnReset.Location = new Point(3, 155);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(161, 29);
            btnReset.TabIndex = 3;
            btnReset.Text = "Return";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // tmrTimer
            // 
            tmrTimer.Enabled = true;
            tmrTimer.Interval = 1000;
            // 
            // panelBoard
            // 
            panelBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBoard.AutoScroll = true;
            panelBoard.Location = new Point(4, 5);
            panelBoard.Name = "panelBoard";
            panelBoard.Size = new Size(813, 540);
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
            Name = "BoardGUI";
            Text = "Board";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lblTimer;
        private FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer tmrTimer;
        private Label label2;
        private Button btnReset;
        private Panel panelBoard;
    }
}