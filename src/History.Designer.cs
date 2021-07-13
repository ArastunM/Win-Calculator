
namespace Calculator
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.slot1 = new System.Windows.Forms.Button();
            this.slot2 = new System.Windows.Forms.Button();
            this.slot3 = new System.Windows.Forms.Button();
            this.removeHistoryButton = new System.Windows.Forms.Button();
            this.topLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // slot1
            // 
            this.slot1.BackColor = System.Drawing.SystemColors.Control;
            this.slot1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.slot1.Location = new System.Drawing.Point(0, 56);
            this.slot1.Name = "slot1";
            this.slot1.Size = new System.Drawing.Size(452, 97);
            this.slot1.TabIndex = 0;
            this.slot1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.slot1.UseVisualStyleBackColor = false;
            this.slot1.Click += new System.EventHandler(this.slot1_Click);

            setTransparentBorder(this.slot1);
            // 
            // slot2
            // 
            this.slot2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.slot2.Location = new System.Drawing.Point(0, 192);
            this.slot2.Name = "slot2";
            this.slot2.Size = new System.Drawing.Size(452, 97);
            this.slot2.TabIndex = 1;
            this.slot2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.slot2.UseVisualStyleBackColor = true;
            this.slot2.Click += new System.EventHandler(this.slot2_Click);

            setTransparentBorder(this.slot2);
            // 
            // slot3
            // 
            this.slot3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.slot3.Location = new System.Drawing.Point(0, 331);
            this.slot3.Name = "slot3";
            this.slot3.Size = new System.Drawing.Size(452, 97);
            this.slot3.TabIndex = 2;
            this.slot3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.slot3.UseVisualStyleBackColor = true;
            this.slot3.Click += new System.EventHandler(this.slot3_Click);

            setTransparentBorder(this.slot3);
            // 
            // removeHistoryButton
            // 
            this.removeHistoryButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("removeHistoryButton.BackgroundImage")));
            this.removeHistoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.removeHistoryButton.Location = new System.Drawing.Point(386, 483);
            this.removeHistoryButton.Name = "removeHistoryButton";
            this.removeHistoryButton.Size = new System.Drawing.Size(53, 57);
            this.removeHistoryButton.TabIndex = 5;
            this.removeHistoryButton.UseVisualStyleBackColor = true;
            this.removeHistoryButton.Click += new System.EventHandler(this.removeHistoryButton_Click);

            setTransparentBorder(this.removeHistoryButton);
            // 
            // topLabel
            // 
            this.topLabel.AutoSize = true;
            this.topLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.topLabel.Location = new System.Drawing.Point(12, 12);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(198, 28);
            this.topLabel.TabIndex = 6;
            this.topLabel.Text = "There\'s no history yet";
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 549);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.removeHistoryButton);
            this.Controls.Add(this.slot3);
            this.Controls.Add(this.slot2);
            this.Controls.Add(this.slot1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "History";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // setting a transparent button border
        public void setTransparentBorder(System.Windows.Forms.Button button)
        {
            button.TabStop = false;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);
        }

        #endregion

        private System.Windows.Forms.Button slot1;
        private System.Windows.Forms.Button slot2;
        private System.Windows.Forms.Button slot3;
        private System.Windows.Forms.Button removeHistoryButton;
        private System.Windows.Forms.Label topLabel;
    }
}