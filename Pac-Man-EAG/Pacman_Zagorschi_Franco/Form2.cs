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
    public partial class Form2 : Form
    {
        
        
        public Form2()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
            {
                // Получаем логин и пароль в переменные сразу чистим краевые пробелы
                string login = textBox1.Text.Trim();
                string pass = textBox2.Text.Trim();
                if (login == "" || pass == "")
                {
                    MessageBox.Show("Вы не ввели данные для входа");
                }
                else
                {
                    SqlConnection connect = new SqlConnection(Program.st_connect);

                    // Открыть подключение
                    connect.Open();

                    //строка запроса на поиск юзера
                    string s = "select * from Avto where Login = '" + login + "' and Password= '" + pass + "'";

                    //Делаем запрос к БД
                    SqlCommand command = new SqlCommand(s, connect);

                    //Получаем данные, которые вернул зарос
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //получаем одну строку из набора данных
                        reader.Read();

                        //Получаем данные, в скобках это номер столбцов в запросе!!!
                        Program.id_user = reader.GetInt32(0);
                        Program.type_user = reader.GetBoolean(3);


                    //
                    if (Program.type_user == false)
                        {
                            //MessageBox.Show("Простой юзер");

                            Form1 f = new Form1();
                            f.Show();
                       
                        }
                        else
                        {
                            //MessageBox.Show("AdmiN");

                            Form3 f = new Form3();
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден!!!");
                    }


                    // Закрыть подключение
                    connect.Close();
                }
           
            }
            

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            Form2 f2 = new Form2();
            f2.Visible = false;
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void Form2_Load(object sender, EventArgs e)
        {
            
            Form2 f2 = new Form2();


        }
    }
}
