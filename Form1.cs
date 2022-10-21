using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\bargy\\Аптека.mdf;Integrated Security=True;Connect Timeout=30";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();

            da.SelectCommand = new SqlCommand("SELECT * FROM Pharmacy", connection);
            ds.Tables.Clear();
            da.Fill(ds);
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //da.SelectCommand = new SqlCommand("SELECT * FROM Pharmacy", connection);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "INSERT INTO Pharmacy (Medicament) values ('" + textBox1.Text + "');";
            //command.CommandType = CommandType.Text;
            connection.Open();

            command.ExecuteReader();
            command.CommandText = "SELECT * FROM Pharmacy";
            connection.Close();
            connection.Open();

            da.SelectCommand = new SqlCommand("SELECT * FROM Pharmacy", connection);
            ds.Tables.Clear();
            da.Fill(ds);
            comboBox1.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "DELETE FROM Pharmacy WHERE Id = '" + textBox2.Text + "';";
            //command.CommandType = CommandType.Text;
            connection.Open();
            command.ExecuteReader();
            command.CommandText = "SELECT * FROM Pharmacy";
            connection.Close();
            connection.Open();

            da.SelectCommand = new SqlCommand("SELECT * FROM Pharmacy", connection);
            ds.Tables.Clear();
            da.Fill(ds);
            comboBox1.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            connection.Close();
        }
    }
}
