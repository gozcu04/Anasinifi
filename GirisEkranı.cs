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
    public partial class GirisEkranı : Form
    {
        public GirisEkranı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-V6Q0A0I\SQLEXPRESS;Initial Catalog=AnasinifiOtomasyon;Integrated Security=True");
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Öğretmen Giriş

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Ogretmenler where SIFRE=@h1",baglanti);
            komut.Parameters.AddWithValue("@h1", txtogrtmnsıfre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                OgretmenSıstem ogrtmnsstm = new OgretmenSıstem();
                ogrtmnsstm.Show();
                
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi Girişi Yapıldı.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            baglanti.Close();


        }

        private void GirisEkranı_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Müdür Giriş

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Mudur where SIFRE=@m1", baglanti);
            komut.Parameters.AddWithValue("@m1", txtmdrsıfre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                MudurSistem mdrsstm = new MudurSistem();
                mdrsstm.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi Girişi Yapıldı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            baglanti.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
