using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlGit1
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataSet dataSet;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            connection = new MySqlConnection("Persist Security Info=true;" + "server=localhost;database=sakila;uid=root;password=7S&micolcheia");
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                adapter = new MySqlDataAdapter("select film_id, title, description, release_year from film order by film_id", connection);
                adapter.Fill(dataSet, "film");
                dataGridView1.DataSource = dataSet;
                dataGridView1.DataMember = "film";
            }
        }
    }
}
