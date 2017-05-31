using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Excel
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBoxName.Visible = false;
                textBoxCode.Visible = false;
                comboBoxUnit.Visible = false;
                numericUpDown.Visible = false;
                button.Visible = false;
                labelConfirmN.Text = textBoxName.Text + "  " + numericUpDown.Value + " " + comboBoxUnit.Text;
                labelConfirmT.Visible = true;
                labelConfirmN.Visible = true;
                btnNo.Visible = true;
                btnYes.Visible = true;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void numericUpDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown.Value == Convert.ToDecimal(0))
                    numericUpDown.Text = "";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void comboBoxUnit_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxUnit.Text = "";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBoxName.Visible = true;
                textBoxCode.Visible = true;
                comboBoxUnit.Visible = true;
                numericUpDown.Visible = true;
                button.Visible = true;
                labelConfirmT.Visible = false;
                labelConfirmN.Visible = false;
                btnNo.Visible = false;
                btnYes.Visible = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                                                               "DFI.xlsx" +
                                                                               ";Extended Properties='Excel 12.0 XML;HDR=NO;';");
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "Insert into [Лист1$] (F1,F2 , F3, F4, F5) values('" +
                                                                               textBoxCode.Text +
                                                                               "','" +
                                                                               textBoxName.Text +
                                                                               "','" +
                                                                               numericUpDown.Value +
                                                                               "','" +
                                                                               comboBoxUnit.Text +
                                                                               "','" +
                                                                               numericUpDown.Value +
                                                                               "')";
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBoxName.Visible = true;
                textBoxCode.Visible = true;
                comboBoxUnit.Visible = true;
                numericUpDown.Visible = true;
                button.Visible = true;
                labelConfirmT.Visible = false;
                labelConfirmN.Visible = false;
                btnNo.Visible = false;
                btnYes.Visible = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}