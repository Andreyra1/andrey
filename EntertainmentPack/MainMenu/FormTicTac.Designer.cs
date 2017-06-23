namespace MainMenu
{
    partial class FormTicTac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTicTac));
            this.labelP1 = new System.Windows.Forms.Label();
            this.labelP2 = new System.Windows.Forms.Label();
            this.labelCountD = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCount1 = new System.Windows.Forms.Label();
            this.labelCount2 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // labelP1
            // 
            this.labelP1.AutoSize = true;
            this.labelP1.BackColor = System.Drawing.Color.Transparent;
            this.labelP1.Font = new System.Drawing.Font("Broken Chalk", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP1.ForeColor = System.Drawing.Color.Blue;
            this.labelP1.Location = new System.Drawing.Point(271, 31);
            this.labelP1.Name = "labelP1";
            this.labelP1.Size = new System.Drawing.Size(198, 38);
            this.labelP1.TabIndex = 0;
            this.labelP1.Text = "PLAYER 1";
            // 
            // labelP2
            // 
            this.labelP2.AutoSize = true;
            this.labelP2.BackColor = System.Drawing.Color.Transparent;
            this.labelP2.Font = new System.Drawing.Font("Broken Chalk", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP2.ForeColor = System.Drawing.Color.Blue;
            this.labelP2.Location = new System.Drawing.Point(643, 31);
            this.labelP2.Name = "labelP2";
            this.labelP2.Size = new System.Drawing.Size(205, 38);
            this.labelP2.TabIndex = 1;
            this.labelP2.Text = "PLAYER 2";
            // 
            // labelCountD
            // 
            this.labelCountD.AutoSize = true;
            this.labelCountD.BackColor = System.Drawing.Color.Transparent;
            this.labelCountD.Font = new System.Drawing.Font("Broken Chalk", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountD.ForeColor = System.Drawing.Color.Blue;
            this.labelCountD.Location = new System.Drawing.Point(529, 83);
            this.labelCountD.Name = "labelCountD";
            this.labelCountD.Size = new System.Drawing.Size(39, 38);
            this.labelCountD.TabIndex = 2;
            this.labelCountD.Text = "0";
            this.labelCountD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Broken Chalk", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(486, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "DRAW";
            // 
            // labelCount1
            // 
            this.labelCount1.AutoSize = true;
            this.labelCount1.BackColor = System.Drawing.Color.Transparent;
            this.labelCount1.Font = new System.Drawing.Font("Broken Chalk", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCount1.ForeColor = System.Drawing.Color.Blue;
            this.labelCount1.Location = new System.Drawing.Point(340, 83);
            this.labelCount1.Name = "labelCount1";
            this.labelCount1.Size = new System.Drawing.Size(39, 38);
            this.labelCount1.TabIndex = 5;
            this.labelCount1.Text = "0";
            this.labelCount1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCount2
            // 
            this.labelCount2.AutoSize = true;
            this.labelCount2.BackColor = System.Drawing.Color.Transparent;
            this.labelCount2.Font = new System.Drawing.Font("Broken Chalk", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCount2.ForeColor = System.Drawing.Color.Blue;
            this.labelCount2.Location = new System.Drawing.Point(727, 83);
            this.labelCount2.Name = "labelCount2";
            this.labelCount2.Size = new System.Drawing.Size(39, 38);
            this.labelCount2.TabIndex = 6;
            this.labelCount2.Text = "0";
            this.labelCount2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.Lavender;
            this.comboBox.Font = new System.Drawing.Font("Broken Chalk", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.ForeColor = System.Drawing.Color.Blue;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "EASY",
            "NORMAL",
            "IMPOSSIBLE",
            "PLAYER VS PLAYER"});
            this.comboBox.Location = new System.Drawing.Point(12, 283);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(247, 31);
            this.comboBox.TabIndex = 8;
            this.comboBox.Text = "IMPOSSIBLE";
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Broken Chalk", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "CHOOSE GAME MODE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MainMenu.Properties.Resources._65f57a9589caf275a846c71b4eb1f812;
            this.pictureBox1.Location = new System.Drawing.Point(30, 337);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 244);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MainMenu.Properties.Resources.doodle_1388118_960_720;
            this.pictureBox2.Location = new System.Drawing.Point(831, 135);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(237, 319);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::MainMenu.Properties.Resources.doodles_41_512;
            this.pictureBox3.Location = new System.Drawing.Point(810, 460);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(258, 197);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // FormTicTac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MainMenu.Properties.Resources.Background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.labelCount2);
            this.Controls.Add(this.labelCount1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCountD);
            this.Controls.Add(this.labelP2);
            this.Controls.Add(this.labelP1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormTicTac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic Tac Toe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTicTac_FormClosed);
            this.Load += new System.EventHandler(this.FormTicTac_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormTicTac_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelP1;
        private System.Windows.Forms.Label labelP2;
        private System.Windows.Forms.Label labelCountD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCount1;
        private System.Windows.Forms.Label labelCount2;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}