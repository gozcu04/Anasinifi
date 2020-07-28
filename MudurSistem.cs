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
    public partial class MudurSistem : Form
    {
        public MudurSistem()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-V6Q0A0I\SQLEXPRESS;Initial Catalog=AnasinifiOtomasyon;Integrated Security=True");
        private void btnsınf1_Click(object sender, EventArgs e)
        {
            SınıfBir snfbır = new SınıfBir();
            snfbır.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SınıfIkı snfıkı = new SınıfIkı();
            snfıkı.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SınıfUc snfuc = new SınıfUc();
            snfuc.Show();
        }

        private void btnogretmenler_Click(object sender, EventArgs e)
        {
            Ogretmenler ogrtmnlr = new Ogretmenler();
            ogrtmnlr.Show();
        }

        private void btnogrencıler_Click(object sender, EventArgs e)
        {
            Ogrenciler ogrnclr = new Ogrenciler();
            ogrnclr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calısanlar clsnlr = new Calısanlar();
            clsnlr.Show();
        }

        private void MudurSistem_Load(object sender, EventArgs e)
        {

        }
    }
}
