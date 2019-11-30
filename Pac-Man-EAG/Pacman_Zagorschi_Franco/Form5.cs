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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pacManDataSet1.Avto". При необходимости она может быть перемещена или удалена.
            //  this.avtoTableAdapter1.Fill(this.pacManDataSet1.Avto);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pacManDataSet.Avto". При необходимости она может быть перемещена или удалена.
            //  this.avtoTableAdapter.Fill(this.pacManDataSet.Avto);
            SqlConnection connect = new SqlConnection(Program.st_connect);

            // Открыть подключение
            connect.Open();

            //строка запроса на поиск юзера
            string s = "select * from Avto ";

            //Делаем запрос к БД
            SqlCommand command = new SqlCommand(s, connect);
            DataSet ss = new DataSet();

            SqlDataAdapter a = new SqlDataAdapter(command);
            a.Fill(ss);
            dataGridView1.DataSource =ss.Tables[0];
            connect.Close();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            int k = dataGridView1.CurrentRow.Index;
            Program.id_user = Convert.ToInt32(dataGridView1[0, k].Value);
            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();

            string s = "delete from User1 where id =  " + Program.id_user.ToString();
            SqlCommand comm = new SqlCommand(s, conn);
            {
                MessageBox.Show("Пользователь успешно удален!");
            }
            comm.ExecuteScalar();
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.Show();
        }
    }
}
