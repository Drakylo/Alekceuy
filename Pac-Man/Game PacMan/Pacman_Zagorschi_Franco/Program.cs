using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_Zagorschi_Franco
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        /// 

        // Строка подключения к БД
        public static string st_connect = @"Data Source=DESKTOP-8QJRE3U;Initial Catalog=PacMan;Integrated Security=True";

        //Переменная для хранения id авторизовавшегося
        public static int id_user = -1;

        // Переменная для хранения типапользователя, который сейчас авторизован
        public static bool type_user = false;



        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
