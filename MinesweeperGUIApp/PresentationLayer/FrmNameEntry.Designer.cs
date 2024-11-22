namespace MinesweeperGUIApp
{
    partial class FrmNameEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNameEntry));
            tbName = new TextBox();
            panel1 = new Panel();
            btnCancel = new PictureBox();
            btnEnter = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCancel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEnter).BeginInit();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbName.BackColor = Color.FromArgb(224, 224, 224);
            tbName.Font = new Font("Azonix", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbName.ForeColor = Color.FromArgb(34, 34, 34);
            tbName.Location = new Point(9, 24);
            tbName.Margin = new Padding(4, 2, 4, 2);
            tbName.Name = "tbName";
            tbName.Size = new Size(498, 48);
            tbName.TabIndex = 0;
            tbName.KeyPress += FormOnKeyPress;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnEnter);
            panel1.Controls.Add(tbName);
            panel1.Location = new Point(37, 166);
            panel1.Margin = new Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(525, 187);
            panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            btnCancel.Location = new Point(270, 86);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(237, 72);
            btnCancel.SizeMode = PictureBoxSizeMode.StretchImage;
            btnCancel.TabIndex = 16;
            btnCancel.TabStop = false;
            btnCancel.Click += BtnCancelClick;
            // 
            // btnEnter
            // 
            btnEnter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnEnter.BackColor = Color.Transparent;
            btnEnter.Cursor = Cursors.Hand;
            btnEnter.Image = (Image)resources.GetObject("btnEnter.Image");
            btnEnter.Location = new Point(9, 86);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(255, 72);
            btnEnter.SizeMode = PictureBoxSizeMode.StretchImage;
            btnEnter.TabIndex = 15;
            btnEnter.TabStop = false;
            btnEnter.Click += BtnEnterNameOnClick;
            // 
            // FrmNameEntry
            // 
            AutoScaleDimensions = new SizeF(11F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(593, 448);
            Controls.Add(panel1);
            Font = new Font("Azonix", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 2, 4, 2);
            Name = "FrmNameEntry";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            KeyPress += FormOnKeyPress;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnCancel).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEnter).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbName;
        private Panel panel1;
        private PictureBox btnEnter;
        private PictureBox btnCancel;
    }
}