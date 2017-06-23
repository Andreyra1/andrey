namespace MainMenu
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnTetris = new System.Windows.Forms.Button();
            this.labelText = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.btnBattleships = new System.Windows.Forms.Button();
            this.btnTicTac = new System.Windows.Forms.Button();
            this.smallSquare = new System.Windows.Forms.PictureBox();
            this.bigSquare = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigSquare)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTetris
            // 
            this.btnTetris.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTetris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.btnTetris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTetris.BackgroundImage")));
            this.btnTetris.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTetris.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MintCream;
            this.btnTetris.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.btnTetris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTetris.Font = new System.Drawing.Font("Broken Chalk", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTetris.ForeColor = System.Drawing.Color.Blue;
            this.btnTetris.Image = ((System.Drawing.Image)(resources.GetObject("btnTetris.Image")));
            this.btnTetris.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTetris.Location = new System.Drawing.Point(12, 250);
            this.btnTetris.Name = "btnTetris";
            this.btnTetris.Size = new System.Drawing.Size(421, 125);
            this.btnTetris.TabIndex = 3;
            this.btnTetris.Text = "TETRIS";
            this.btnTetris.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTetris.UseVisualStyleBackColor = false;
            this.btnTetris.Click += new System.EventHandler(this.btnTetris_Click);
            this.btnTetris.MouseEnter += new System.EventHandler(this.btnTetris_MouseEnter);
            // 
            // labelText
            // 
            this.labelText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelText.AutoSize = true;
            this.labelText.BackColor = System.Drawing.Color.Transparent;
            this.labelText.Font = new System.Drawing.Font("Broken Chalk", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.ForeColor = System.Drawing.Color.Blue;
            this.labelText.Location = new System.Drawing.Point(479, 456);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(0, 23);
            this.labelText.TabIndex = 22;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(532, 100);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(451, 316);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 19;
            this.pictureBox.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Broken Chalk", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.Blue;
            this.labelName.Location = new System.Drawing.Point(501, 36);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 40);
            this.labelName.TabIndex = 18;
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MintCream;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Broken Chalk", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Blue;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(11, 588);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(421, 100);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Broken Chalk", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Blue;
            this.label.Location = new System.Drawing.Point(6, 32);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(449, 29);
            this.label.TabIndex = 6;
            this.label.Text = "ENTERTAIN YOURSELF WITH";
            // 
            // btnBattleships
            // 
            this.btnBattleships.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBattleships.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.btnBattleships.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBattleships.BackgroundImage")));
            this.btnBattleships.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBattleships.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MintCream;
            this.btnBattleships.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.btnBattleships.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBattleships.Font = new System.Drawing.Font("Broken Chalk", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBattleships.ForeColor = System.Drawing.Color.Blue;
            this.btnBattleships.Image = ((System.Drawing.Image)(resources.GetObject("btnBattleships.Image")));
            this.btnBattleships.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBattleships.Location = new System.Drawing.Point(12, 100);
            this.btnBattleships.Name = "btnBattleships";
            this.btnBattleships.Size = new System.Drawing.Size(421, 125);
            this.btnBattleships.TabIndex = 4;
            this.btnBattleships.Text = "BATTLESHIPS";
            this.btnBattleships.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBattleships.UseVisualStyleBackColor = false;
            this.btnBattleships.Click += new System.EventHandler(this.btnBattleships_Click);
            this.btnBattleships.MouseEnter += new System.EventHandler(this.btnBattleships_MouseEnter);
            // 
            // btnTicTac
            // 
            this.btnTicTac.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTicTac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.btnTicTac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTicTac.BackgroundImage")));
            this.btnTicTac.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTicTac.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MintCream;
            this.btnTicTac.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.btnTicTac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTicTac.Font = new System.Drawing.Font("Broken Chalk", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicTac.ForeColor = System.Drawing.Color.Blue;
            this.btnTicTac.Image = ((System.Drawing.Image)(resources.GetObject("btnTicTac.Image")));
            this.btnTicTac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTicTac.Location = new System.Drawing.Point(12, 400);
            this.btnTicTac.Name = "btnTicTac";
            this.btnTicTac.Size = new System.Drawing.Size(421, 125);
            this.btnTicTac.TabIndex = 1;
            this.btnTicTac.Text = "TIC-TAC-TOE";
            this.btnTicTac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTicTac.UseVisualStyleBackColor = false;
            this.btnTicTac.Click += new System.EventHandler(this.btnTicTac_Click);
            this.btnTicTac.MouseEnter += new System.EventHandler(this.btnTicTac_MouseEnter);
            // 
            // smallSquare
            // 
            this.smallSquare.BackColor = System.Drawing.Color.Transparent;
            this.smallSquare.Image = ((System.Drawing.Image)(resources.GetObject("smallSquare.Image")));
            this.smallSquare.Location = new System.Drawing.Point(469, 80);
            this.smallSquare.Name = "smallSquare";
            this.smallSquare.Size = new System.Drawing.Size(571, 349);
            this.smallSquare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.smallSquare.TabIndex = 21;
            this.smallSquare.TabStop = false;
            // 
            // bigSquare
            // 
            this.bigSquare.BackColor = System.Drawing.Color.Transparent;
            this.bigSquare.Image = ((System.Drawing.Image)(resources.GetObject("bigSquare.Image")));
            this.bigSquare.Location = new System.Drawing.Point(401, 3);
            this.bigSquare.Name = "bigSquare";
            this.bigSquare.Size = new System.Drawing.Size(703, 666);
            this.bigSquare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bigSquare.TabIndex = 20;
            this.bigSquare.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.btnTetris);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnBattleships);
            this.Controls.Add(this.btnTicTac);
            this.Controls.Add(this.smallSquare);
            this.Controls.Add(this.bigSquare);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entertainment Pack";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigSquare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTicTac;
        private System.Windows.Forms.Button btnTetris;
        private System.Windows.Forms.Button btnBattleships;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox smallSquare;
        private System.Windows.Forms.PictureBox bigSquare;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label;
    }
}

