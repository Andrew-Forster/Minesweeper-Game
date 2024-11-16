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
            btnCancel = new Button();
            btnEnter = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.BackColor = Color.FromArgb(224, 224, 224);
            tbName.Font = new Font("Azonix", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbName.ForeColor = Color.FromArgb(34, 34, 34);
            tbName.Location = new Point(9, 24);
            tbName.Margin = new Padding(4, 2, 4, 2);
            tbName.Name = "tbName";
            tbName.Size = new Size(459, 48);
            tbName.TabIndex = 0;
            tbName.KeyPress += FormOnKeyPress;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnEnter);
            panel1.Controls.Add(tbName);
            panel1.Location = new Point(36, 193);
            panel1.Margin = new Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(486, 224);
            panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Azonix", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.FromArgb(34, 34, 34);
            btnCancel.Location = new Point(9, 138);
            btnCancel.Margin = new Padding(4, 2, 4, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(459, 58);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancelClick;
            // 
            // btnEnter
            // 
            btnEnter.BackColor = Color.FromArgb(0, 192, 0);
            btnEnter.FlatStyle = FlatStyle.Popup;
            btnEnter.Font = new Font("Azonix", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnter.ForeColor = Color.FromArgb(34, 34, 34);
            btnEnter.Location = new Point(9, 76);
            btnEnter.Margin = new Padding(4, 2, 4, 2);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(459, 58);
            btnEnter.TabIndex = 2;
            btnEnter.Text = "Enter";
            btnEnter.UseVisualStyleBackColor = false;
            btnEnter.Click += BtnEnterNameOnClick;
            // 
            // FrmNameEntry
            // 
            AutoScaleDimensions = new SizeF(11F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(557, 530);
            Controls.Add(panel1);
            Font = new Font("Azonix", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 2, 4, 2);
            Name = "FrmNameEntry";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            KeyPress += FormOnKeyPress;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbName;
        private Panel panel1;
        private Button btnEnter;
        private Button btnCancel;
    }
}