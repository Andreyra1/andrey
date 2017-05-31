namespace GameOfLife
{
    partial class FormSettings
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
            this.numUDHeight = new System.Windows.Forms.NumericUpDown();
            this.numUDWidth = new System.Windows.Forms.NumericUpDown();
            this.numUDPercentage = new System.Windows.Forms.NumericUpDown();
            this.numUDSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUDHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numUDHeight
            // 
            this.numUDHeight.Location = new System.Drawing.Point(141, 28);
            this.numUDHeight.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.numUDHeight.Name = "numUDHeight";
            this.numUDHeight.Size = new System.Drawing.Size(110, 20);
            this.numUDHeight.TabIndex = 0;
            // 
            // numUDWidth
            // 
            this.numUDWidth.Location = new System.Drawing.Point(141, 54);
            this.numUDWidth.Maximum = new decimal(new int[] {
            280,
            0,
            0,
            0});
            this.numUDWidth.Name = "numUDWidth";
            this.numUDWidth.Size = new System.Drawing.Size(110, 20);
            this.numUDWidth.TabIndex = 1;
            // 
            // numUDPercentage
            // 
            this.numUDPercentage.Location = new System.Drawing.Point(141, 91);
            this.numUDPercentage.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUDPercentage.Name = "numUDPercentage";
            this.numUDPercentage.Size = new System.Drawing.Size(110, 20);
            this.numUDPercentage.TabIndex = 2;
            // 
            // numUDSpeed
            // 
            this.numUDSpeed.DecimalPlaces = 2;
            this.numUDSpeed.Location = new System.Drawing.Point(141, 117);
            this.numUDSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDSpeed.Name = "numUDSpeed";
            this.numUDSpeed.Size = new System.Drawing.Size(110, 20);
            this.numUDSpeed.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Percentage of alive cells";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rendering speed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Field";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "s.";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(141, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 74);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Conway\'s";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Andrey\'s";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Mode";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 280);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numUDSpeed);
            this.Controls.Add(this.numUDPercentage);
            this.Controls.Add(this.numUDWidth);
            this.Controls.Add(this.numUDHeight);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.Text = "FormSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUDHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numUDHeight;
        private System.Windows.Forms.NumericUpDown numUDWidth;
        private System.Windows.Forms.NumericUpDown numUDPercentage;
        private System.Windows.Forms.NumericUpDown numUDSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}