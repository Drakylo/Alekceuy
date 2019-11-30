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
            string s = "update Users1 set Login = '" + textBox1.Text.Trim() + "', " +
                                         "Password = '" + textBox2.Text.Trim() + "', " +
                                         "where ID_users = " + Program.id_user.ToString();
            {
                MessageBox.Show("Ваши данные успешно изменены!");
            }
            SqlCommand comm = new SqlCommand(s, connect);
            comm.ExecuteScalar();
            connect.Close();
            pictureBox5.Visible = false;
            pictureBox3.Visible = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }
    }
}
