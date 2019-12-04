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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox3.Visible = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Program.st_connect);
            connect.Open();
            string s = "update Avto set Login = '" + textBox1.Text.Trim() + "', " +
                                       "Password = '" + textBox2.Text.Trim() + 
                                       "' where id = " + Program.id_user.ToString();
            
            SqlCommand comm = new SqlCommand(s, connect);
            comm.ExecuteScalar();
            connect.Close();
            pictureBox5.Visible = false;
            pictureBox3.Visible = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            {
                MessageBox.Show("Ваши данные успешно изменены!");
            }
            connect.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
        
    }
}
