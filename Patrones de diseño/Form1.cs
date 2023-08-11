using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Patrones_de_diseño.Program;

namespace Patrones_de_diseño
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = ShowPatterns();
        }

        public DataTable ShowPatterns()
        {
            using (SqlConnection connection = DatabaseConnection.GetInstance().GetConnection())
            {
                SqlCommand cmd = new SqlCommand("ShowPatterns", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                // La conexión se cerrará automáticamente al salir del bloque using
                return dt;
            }
        }

    }
}
