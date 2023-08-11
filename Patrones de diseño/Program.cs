using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Patrones_de_diseño
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        //Usando el patrón de diseño Singleton
        public class DatabaseConnection
        {
            private static DatabaseConnection instance;
            private SqlConnection connection;

            private DatabaseConnection()
            {
                connection = new SqlConnection("Server=DESKTOP-TFNBFUK;database=Patrones de diseño;integrated security=true");
                connection.Open();
            }

            public static DatabaseConnection GetInstance()
            {
                if (instance == null)
                {
                    instance = new DatabaseConnection();
                }
                return instance;
            }

            public SqlConnection GetConnection()
            {
                return connection;

            }
        }
    }
}
