using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class FormSettings : Form
    {
        Form1 original;
        public FormSettings(Form1 incoming)
        {
            original = incoming;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            original.x = Convert.ToInt32(numUDHeight.Value);
            original.y = Convert.ToInt32(numUDWidth.Value);
            original.speed = Convert.ToInt32(numUDSpeed.Value*1000);
            original.percentage = Convert.ToInt32(numUDPercentage.Value);
            if (radioButton2.Checked == true)
                original.mode = false;
            else
            {
                original.mode = true;
            }
            this.Close();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            numUDHeight.Value = original.x;
            numUDWidth.Value = original.y;
            numUDSpeed.Value = Convert.ToDecimal(original.speed)/1000;
            numUDPercentage.Value = original.percentage;
            if (original.mode == true)
                radioButton1.Checked = true;
            else
            {
                radioButton2.Checked = true;
            }
        }
    }
}