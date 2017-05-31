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
    public partial class AmmountForm : Form
    {
        public int i;
        public string cell;
        public string unit;
        public AmmountForm()
        {
            InitializeComponent();
        }

        private void AmmountForm_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                                                                       "DFI.xlsx" +
                                                                                       ";Extended Properties='Excel 12.0 XML;HDR=NO;';");
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "Select * from [Лист1$A1:E50000] where F2 = '" + cell + "';";
                command.ExecuteNonQuery();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    unit = reader.GetString(3);
                }
                reader.Close();
                connection.Close();
                label.Text = "Введите количество  "+ unit + "\n " +
                         cell;
                label1.Visible = false;
                btnYes.Visible = false;
                btnNo.Visible = false;
                label2.Visible = false;
                label.Visible = true;
                numericUpDown.Visible = true;
                button.Visible = true;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            { 
                label.Visible = false;
                button.Visible = false;
                numericUpDown.Visible = false;
                label2.Text = cell + " : " + numericUpDown.Value + " " + unit;
                label1.Visible = true;
                label2.Visible = true;
                btnYes.Visible = true;
                btnNo.Visible = true;
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
                command.CommandText = "UPDATE[Лист1$A1:E50000] SET F5 = '" + numericUpDown.Value + "' where F2 = '" + cell + "';";
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
                label.Visible = true;
                button.Visible = true;
                numericUpDown.Value = 0;
                numericUpDown.Visible = true;
                label2.Visible = false;
                label1.Visible = false;
                btnYes.Visible = false;
                btnNo.Visible = false;
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

    }
}
