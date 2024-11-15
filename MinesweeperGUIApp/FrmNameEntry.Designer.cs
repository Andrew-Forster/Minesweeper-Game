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
            label1 = new Label();
            panel1 = new Panel();
            btnCancel = new Button();
            btnEnter = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.BackColor = Color.FromArgb(224, 224, 224);
            tbName.Location = new Point(9, 36);
            tbName.Margin = new Padding(4, 2, 4, 2);
            tbName.Name = "tbName";
            tbName.Size = new Size(204, 23);
            tbName.TabIndex = 0;
            tbName.KeyPress += FormOnKeyPress;
            // 
            // label1
            // 
            label1.Font = new Font("Azonix", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 192, 255);
            label1.Location = new Point(9, 7);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(204, 19);
            label1.TabIndex = 1;
            label1.Text = "Enter Name:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnEnter);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(tbName);
            panel1.Location = new Point(167, 183);
            panel1.Margin = new Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 170);
            panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Azonix", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(9, 116);
            btnCancel.Margin = new Padding(4, 2, 4, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(204, 36);
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
            btnEnter.ForeColor = Color.White;
            btnEnter.Location = new Point(9, 76);
            btnEnter.Margin = new Padding(4, 2, 4, 2);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(204, 36);
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
            ClientSize = new Size(557, 528);
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
        private Label label1;
        private Panel panel1;
        private Button btnEnter;
        private Button btnCancel;
    }
}