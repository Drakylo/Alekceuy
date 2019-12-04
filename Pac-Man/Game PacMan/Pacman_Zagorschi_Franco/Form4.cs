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

namespace Pacman_Zagorschi_Franco
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    textBox1.Text == "" ||
                    textBox2.Text == "" )
                {
                    MessageBox.Show("Не все поля заполнены!!");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(Program.st_connect);
                    conn.Open();

                    string s = "insert into Avto " + " " + " (Login, Password, type_user) values " +
                        " ('" + textBox1.Text.Trim() + "' , " +
                         " '" + textBox2.Text.Trim() + "' , 0 )";
                    SqlCommand comm = new SqlCommand(s, conn);
                    comm.ExecuteScalar();
                    conn.Close();
                    this.Close();
                    {
                        MessageBox.Show("Регистрация прошла успешно! Удачи в игре!!! =)");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Что то пошло не так!!!");
            }
        }
    }
}
