using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Data.OleDb;

namespace Excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSearch.Text == "FOOUT")
                { Application.Exit(); }
                else
                {
                    if (textBoxSearch.Text == "")
                    {
                        dataGridView.Visible = false;
                        buttonAdd.Visible = false;
                        label.Visible = false;
                    }
                    else
                    {
                        String connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        "DFI.xlsx" +
                                        ";Extended Properties='Excel 12.0 XML;HDR=NO;';";

                        OleDbConnection connection = new OleDbConnection(connectionString);
                        OleDbCommand commandCount = new OleDbCommand("select count(*) from [Лист1$A1:E50000] where F1 like '%" +
                                                                textBoxSearch.Text +
                                                                "%' or F2 like '%" +
                                                                textBoxSearch.Text +
                                                                "%'", connection);
                        connection.Open();
                        int i = (int)commandCount.ExecuteScalar();
                        if (i > 0)
                        {
                            dataGridView.Visible = true;
                            buttonAdd.Visible = false;
                            label.Visible = false;
                            OleDbCommand commandRead = new OleDbCommand("select F2 as Название from [Лист1$A2:E50000] where F1 like '%" +
                                                             textBoxSearch.Text +
                                                             "%' or F2 like '%" +
                                                             textBoxSearch.Text +
                                                             "%'", connection);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(commandRead);
                            DataTable data = new DataTable();
                            adapter.Fill(data);
                            dataGridView.DataSource = data;
                        }
                        else
                        {
                            buttonAdd.Visible = true;
                            label.Visible = true;
                            dataGridView.Visible = false;
                        }
                    }
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddForm form = new AddForm();
                form.ShowDialog();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AmmountForm form = new AmmountForm();
                form.i = dataGridView.CurrentCell.RowIndex;
                form.cell = Convert.ToString(dataGridView.CurrentCell.Value);
                form.ShowDialog();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.PerformClick();
                }
                if (textBoxSearch.Text != "")
                {
                    String connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                            "DFI.xlsx" +
                                            ";Extended Properties='Excel 12.0 XML;HDR=NO;';";

                    OleDbConnection connection = new OleDbConnection(connectionString);
                    OleDbCommand commandCount = new OleDbCommand("select count(*) from [Лист1$A1:E50000] where F1 like '%" +
                                                            textBoxSearch.Text +
                                                            "%' or F2 like '%" +
                                                            textBoxSearch.Text +
                                                            "%'", connection);
                    connection.Open();
                    int i = (int)commandCount.ExecuteScalar();
                    if (i > 10)
                    {
                        buttonAdd.Visible = false;
                        label.Visible = false;
                        dataGridView.Visible = false;
                        label1.Visible = true;
                    }
                    if (i <= 10 && i > 0)
                    {
                        dataGridView.Visible = true;
                        buttonAdd.Visible = false;
                        label.Visible = false;
                        label1.Visible = false;
                        OleDbCommand commandRead = new OleDbCommand("select F2 as Название from [Лист1$A2:E50000] where F1 like '%" +
                                                         textBoxSearch.Text +
                                                         "%' or F2 like '%" +
                                                         textBoxSearch.Text +
                                                         "%'", connection);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(commandRead);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        dataGridView.DataSource = data;
                    }
                    if (i == 0)
                    {
                        buttonAdd.Visible = true;
                        label.Visible = true;
                        dataGridView.Visible = false;
                        label1.Visible = false;
                    }
                }
                else
                {
                    dataGridView.Visible = false;
                    buttonAdd.Visible = false;
                    label.Visible = false;
                    label1.Visible = false;
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
