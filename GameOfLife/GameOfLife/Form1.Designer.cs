namespace GameOfLife
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContinue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.gliderGunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox65 = new System.Windows.Forms.CheckBox();
            this.checkBox114 = new System.Windows.Forms.CheckBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStart,
            this.tsmiStop,
            this.tsmiContinue,
            this.tsmiSettings,
            this.gliderGunToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiStart
            // 
            this.tsmiStart.BackColor = System.Drawing.SystemColors.Control;
            this.tsmiStart.Name = "tsmiStart";
            this.tsmiStart.Size = new System.Drawing.Size(43, 20);
            this.tsmiStart.Text = "Start";
            this.tsmiStart.Click += new System.EventHandler(this.tsmiStart_Click);
            // 
            // tsmiStop
            // 
            this.tsmiStop.Name = "tsmiStop";
            this.tsmiStop.Size = new System.Drawing.Size(43, 20);
            this.tsmiStop.Text = "Stop";
            this.tsmiStop.Click += new System.EventHandler(this.tsmiStop_Click);
            // 
            // tsmiContinue
            // 
            this.tsmiContinue.Name = "tsmiContinue";
            this.tsmiContinue.Size = new System.Drawing.Size(68, 20);
            this.tsmiContinue.Text = "Continue";
            this.tsmiContinue.Click += new System.EventHandler(this.tsmiContinue_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(61, 20);
            this.tsmiSettings.Text = "Settings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // gliderGunToolStripMenuItem
            // 
            this.gliderGunToolStripMenuItem.Name = "gliderGunToolStripMenuItem";
            this.gliderGunToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.gliderGunToolStripMenuItem.Text = "DANCE";
            this.gliderGunToolStripMenuItem.Click += new System.EventHandler(this.gliderGunToolStripMenuItem_Click);
            // 
            // checkBox65
            // 
            this.checkBox65.AutoSize = true;
            this.checkBox65.Location = new System.Drawing.Point(1419, 27);
            this.checkBox65.Name = "checkBox65";
            this.checkBox65.Size = new System.Drawing.Size(15, 14);
            this.checkBox65.TabIndex = 70;
            this.checkBox65.UseVisualStyleBackColor = true;
            // 
            // checkBox114
            // 
            this.checkBox114.AutoSize = true;
            this.checkBox114.Location = new System.Drawing.Point(1419, 47);
            this.checkBox114.Name = "checkBox114";
            this.checkBox114.Size = new System.Drawing.Size(15, 14);
            this.checkBox114.TabIndex = 138;
            this.checkBox114.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Enabled = false;
            this.textBox.Font = new System.Drawing.Font("Courier New", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox.Location = new System.Drawing.Point(0, 24);
            this.textBox.MaxLength = 999999999;
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(682, 303);
            this.textBox.TabIndex = 139;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(363, 27);
            this.textBox1.MaxLength = 999999999;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(307, 295);
            this.textBox1.TabIndex = 140;
            this.textBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(682, 327);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.checkBox114);
            this.Controls.Add(this.checkBox65);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Blue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Game of Life";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStart;
        private System.Windows.Forms.CheckBox checkBox65;
        private System.Windows.Forms.CheckBox checkBox114;
        public System.Windows.Forms.TextBox textBox;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiStop;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem tsmiContinue;
        private System.Windows.Forms.ToolStripMenuItem gliderGunToolStripMenuItem;
    }
}

