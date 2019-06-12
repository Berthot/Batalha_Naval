namespace naval_batalha
{
    partial class batalhas_navais
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(batalhas_navais));
            this.b_flip = new System.Windows.Forms.Button();
            this.l_test = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_flip
            // 
            this.b_flip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.b_flip.BackColor = System.Drawing.Color.Transparent;
            this.b_flip.FlatAppearance.BorderSize = 0;
            this.b_flip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.b_flip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.b_flip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_flip.ForeColor = System.Drawing.Color.Transparent;
            this.b_flip.Location = new System.Drawing.Point(342, 12);
            this.b_flip.Name = "b_flip";
            this.b_flip.Size = new System.Drawing.Size(75, 75);
            this.b_flip.TabIndex = 0;
            this.b_flip.UseVisualStyleBackColor = false;
            this.b_flip.Click += new System.EventHandler(this.B_flip_Click);
            // 
            // l_test
            // 
            this.l_test.AutoSize = true;
            this.l_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_test.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.l_test.Location = new System.Drawing.Point(351, 102);
            this.l_test.Name = "l_test";
            this.l_test.Size = new System.Drawing.Size(50, 25);
            this.l_test.TabIndex = 1;
            this.l_test.Text = "B00";
            this.l_test.Visible = false;
            this.l_test.Click += new System.EventHandler(this.L_test_Click);
            // 
            // batalhas_navais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.b_flip);
            this.Controls.Add(this.l_test);
            this.Name = "batalhas_navais";
            this.Text = "Battleship";
            this.Load += new System.EventHandler(this.Batalhas_navais_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_flip;
        private System.Windows.Forms.Label l_test;
    }
}

