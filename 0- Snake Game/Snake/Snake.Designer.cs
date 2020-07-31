namespace Snake
{
    partial class Snake
    {
       
        private System.ComponentModel.IContainer components = null;

        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer 

       
        private void InitializeComponent()
        {
            this.Score = new System.Windows.Forms.Label();
            this.Food = new System.Windows.Forms.Label();
            this.SuspendLayout();

            //Snake

            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.Food);
            this.Controls.Add(this.Score);
            this.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Snake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();
            
            // Score
           
            this.Score.AutoSize = true;
            this.Score.Location = new System.Drawing.Point(12, 9);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(98, 21);
            this.Score.TabIndex = 0;
            this.Score.Text = "Score: 1";
             
            // Food
            
            this.Food.AutoSize = true;
            this.Food.BackColor = System.Drawing.Color.Brown;
            this.Food.Location = new System.Drawing.Point(402, 172);
            this.Food.Name = "Food";
            this.Food.Size = new System.Drawing.Size(21, 21);
            this.Food.TabIndex = 1;
            this.Food.Text = " ";
            
        }

        #endregion

        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label Food;
    }
}

