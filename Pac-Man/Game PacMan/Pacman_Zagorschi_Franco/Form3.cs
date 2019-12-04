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
    public partial class Form3 : Form
    {
        int n = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Program.st_connect);
            conn.Open();
            string s = "select User1.id, id_user, Chet, date" +
                " from User1 INNER JOIN Avto ON User1.id = Avto.id"+
                " order by id_user";
            //Делаем запрос к БД через адаптер, чтобы потом данные поместить в DATASET
            SqlDataAdapter adap = new SqlDataAdapter(s, conn);
            //создаем пустой DATASET
            DataSet ds = new DataSet();
            //соединяем DATASET с наним набором данных
            adap.Fill(ds);
            //соединяем DATASET с визуальным компонентом
            dataGridView1.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count >= 10)
            {
                //button1.Enabled = true;
            }
            else
            {
                //button1.Enabled = false;
            }
            conn.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
                      
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
