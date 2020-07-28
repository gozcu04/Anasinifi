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
    public partial class Ogretmenler : Form
    {
        public Ogretmenler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-V6Q0A0I\SQLEXPRESS;Initial Catalog=AnasinifiOtomasyon;Integrated Security=True");

        private void Ogretmenler_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            //Öğretmenler Verilerini Datagride çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Ogretmenler", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsıfre.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
 
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Ogretmenler (AD,SOYAD,SIFRE) values (@h1,@h2,@h3)", baglanti); 
            komut.Parameters.AddWithValue("@h1", txtad.Text);
            komut.Parameters.AddWithValue("@h2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@h3", txtsıfre.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğretmen Başarılı Bir Şekilde Eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Ogretmenler where ID=@h1",baglanti);
            komutsil.Parameters.AddWithValue("@h1",txtıd.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğretmen Başarılı Bir Şekilde Silindi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Ogretmenler set AD=@h1,SOYAD=@h2,SIFRE=@h3 where ID=@h4", baglanti);
            komutguncelle.Parameters.AddWithValue("@h1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@h2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@h3", txtsıfre.Text);
            komutguncelle.Parameters.AddWithValue("@h4", txtıd.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğretmen Başarılı Bir Şekilde Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtıd.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtsıfre.Text = "";
            txtad.Focus();
        }
    }
}
