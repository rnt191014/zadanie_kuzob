using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace zadanie_kuzob
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String log_user = textBox1.Text;
            String pass_user = textBox2.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `FIO` = @userLogin AND `password` = @userPass", db.getConnection());
            command.Parameters.Add("@userLogin", MySqlDbType.VarChar).Value = log_user;
            command.Parameters.Add("@userPass", MySqlDbType.VarChar).Value = pass_user;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (log_user == "" && pass_user == "")
            {
                MessageBox.Show("Вы не ввели данные");
            }
            else if(log_user == "" || pass_user == ""){
                MessageBox.Show("Вы заполнели не все поля");
            }
            else if (table.Rows.Count > 0)
            {
                Hide();
                Form3 avtoriz = new Form3();
                avtoriz.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Что пошло не то");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 reg = new Form2();
            reg.ShowDialog();
            this.Close();
        }
    }
}
