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
            btnSort = new Button();
            SuspendLayout();
            // 
            // panelScores
            // 
            panelScores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelScores.AutoScroll = true;
            panelScores.BackColor = Color.Transparent;
            panelScores.BorderStyle = BorderStyle.FixedSingle;
            panelScores.Location = new Point(47, 198);
            panelScores.Name = "panelScores";
            panelScores.Size = new Size(447, 209);
            panelScores.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Azonix", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.FromArgb(34, 34, 34);
            btnCancel.Location = new Point(15, 441);
            btnCancel.Margin = new Padding(4, 2, 4, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(243, 66);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCloseOnClick;
            // 
            // btnSort
            // 
            btnSort.BackColor = Color.FromArgb(128, 128, 255);
            btnSort.FlatStyle = FlatStyle.Popup;
            btnSort.Font = new Font("Azonix", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSort.ForeColor = Color.FromArgb(34, 34, 34);
            btnSort.Location = new Point(266, 441);
            btnSort.Margin = new Padding(4, 2, 4, 2);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(263, 66);
            btnSort.TabIndex = 5;
            btnSort.Text = "Difficulty: All";
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += BtnSortOnClick;
            // 
            // FrmHighScore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(542, 518);
            Controls.Add(btnSort);
            Controls.Add(btnCancel);
            Controls.Add(panelScores);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ActiveCaption;
            KeyPreview = true;
            Name = "FrmHighScore";
            StartPosition = FormStartPosition.CenterScreen;
            KeyPress += FormOnKeyPress;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel panelScores;
        private Button btnCancel;
        private Button btnSort;
    }
}