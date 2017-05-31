namespace Excel
{
    partial class AddForm
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
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button = new System.Windows.Forms.Button();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.labelConfirmT = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.labelConfirmN = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCode
            // 
            this.textBoxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCode.Location = new System.Drawing.Point(224, 6);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(300, 38);
            this.textBoxCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Код";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ед. Измерения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Количество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = "Название";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(224, 50);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(300, 38);
            this.textBoxName.TabIndex = 6;
            // 
            // numericUpDown
            // 
            this.numericUpDown.DecimalPlaces = 2;
            this.numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown.Location = new System.Drawing.Point(224, 94);
            this.numericUpDown.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(300, 38);
            this.numericUpDown.TabIndex = 8;
            this.numericUpDown.Click += new System.EventHandler(this.numericUpDown_Click);
            // 
            // button
            // 
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button.Location = new System.Drawing.Point(18, 186);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(506, 50);
            this.button.TabIndex = 9;
            this.button.Text = "Добавить";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Items.AddRange(new object[] {
            "шт.",
            "комплект",
            "л.",
            "упак."});
            this.comboBoxUnit.Location = new System.Drawing.Point(224, 141);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(300, 39);
            this.comboBoxUnit.TabIndex = 10;
            this.comboBoxUnit.Text = "шт.";
            this.comboBoxUnit.Click += new System.EventHandler(this.comboBoxUnit_Click);
            // 
            // labelConfirmT
            // 
            this.labelConfirmT.AutoSize = true;
            this.labelConfirmT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfirmT.Location = new System.Drawing.Point(12, 9);
            this.labelConfirmT.Name = "labelConfirmT";
            this.labelConfirmT.Size = new System.Drawing.Size(292, 31);
            this.labelConfirmT.TabIndex = 11;
            this.labelConfirmT.Text = "Вы подтвержаете, что";
            // 
            // btnYes
            // 
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(18, 186);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(243, 50);
            this.btnYes.TabIndex = 12;
            this.btnYes.Text = "Да";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Location = new System.Drawing.Point(281, 186);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(243, 50);
            this.btnNo.TabIndex = 13;
            this.btnNo.Text = "Нет";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // labelConfirmN
            // 
            this.labelConfirmN.AutoSize = true;
            this.labelConfirmN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfirmN.Location = new System.Drawing.Point(12, 53);
            this.labelConfirmN.MaximumSize = new System.Drawing.Size(500, 31);
            this.labelConfirmN.Name = "labelConfirmN";
            this.labelConfirmN.Size = new System.Drawing.Size(33, 31);
            this.labelConfirmN.TabIndex = 14;
            this.labelConfirmN.Text = "X";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 286);
            this.Controls.Add(this.labelConfirmN);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.labelConfirmT);
            this.Controls.Add(this.comboBoxUnit);
            this.Controls.Add(this.button);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.ShowIcon = false;
            this.Text = "Добавление объекта";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.Label labelConfirmT;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label labelConfirmN;
    }
}