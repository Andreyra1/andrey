using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
namespace MainMenu
{
    public partial class FormPause : ParentForm
    {
        Form original;
        public FormPause(Form incoming)
        {
            InitializeComponent();
            original = incoming;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            Form1 form = new Form1();
            form.Show();
            this.Close();
            original.Hide();
        }

        private void FormPause_Load(object sender, EventArgs e)
        {
            brokenChalk = new Font(fonts.Families[0], 21.75F);
            btnContinue.Font = brokenChalk;
            btnExit.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 36.00F);
            label1.Font = brokenChalk;
        }
    }
}
