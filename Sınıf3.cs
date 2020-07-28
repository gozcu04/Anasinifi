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

namespace AnasınıfıOtomasyon
{
    public partial class Sınıf3 : Form
    {
        public Sınıf3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-V6Q0A0I\SQLEXPRESS;Initial Catalog=AnasinifiOtomasyon;Integrated Security=True");

        private void Sınıf3_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From SınıfUc", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
