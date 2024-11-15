namespace MinesweeperGUIApp
{
    partial class FrmHighScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHighScore));
            panelScores = new FlowLayoutPanel();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // panelScores
            // 
            panelScores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelScores.AutoScroll = true;
            panelScores.BackColor = Color.Gray;
            panelScores.BorderStyle = BorderStyle.FixedSingle;
            panelScores.Location = new Point(32, 197);
            panelScores.Name = "panelScores";
            panelScores.Size = new Size(442, 226);
            panelScores.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Azonix", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.FromArgb(34, 34, 34);
            btnCancel.Location = new Point(15, 458);
            btnCancel.Margin = new Padding(4, 2, 4, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(474, 66);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCloseOnClick;
            // 
            // FrmHighScore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(502, 535);
            Controls.Add(btnCancel);
            Controls.Add(panelScores);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ActiveCaption;
            KeyPreview = true;
            Name = "FrmHighScore";
            Text = "FrmHighScore";
            KeyPress += FormOnKeyPress;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel panelScores;
        private Button btnCancel;
    }
}