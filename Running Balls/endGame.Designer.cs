namespace Running_Balls
{
    partial class EndGame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.endScreenLabel = new System.Windows.Forms.Label();
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.timerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // endScreenLabel
            // 
            this.endScreenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endScreenLabel.ForeColor = System.Drawing.Color.Yellow;
            this.endScreenLabel.Location = new System.Drawing.Point(-10, 0);
            this.endScreenLabel.Name = "endScreenLabel";
            this.endScreenLabel.Size = new System.Drawing.Size(826, 98);
            this.endScreenLabel.TabIndex = 0;
            this.endScreenLabel.Text = "Oh no! The Witch Caught The Saint!";
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.mainMenuButton.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.mainMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuButton.Location = new System.Drawing.Point(338, 204);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(101, 35);
            this.mainMenuButton.TabIndex = 1;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = false;
            this.mainMenuButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.Yellow;
            this.timerLabel.Location = new System.Drawing.Point(108, 87);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(580, 68);
            this.timerLabel.TabIndex = 2;
            // 
            // EndGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.mainMenuButton);
            this.Controls.Add(this.endScreenLabel);
            this.Name = "EndGame";
            this.Size = new System.Drawing.Size(816, 489);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label endScreenLabel;
        private System.Windows.Forms.Button mainMenuButton;
        private System.Windows.Forms.Label timerLabel;
    }
}
