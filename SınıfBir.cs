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
    public partial class SınıfBir : Form
    {
        public SınıfBir()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-V6Q0A0I\SQLEXPRESS;Initial Catalog=AnasinifiOtomasyon;Integrated Security=True");
        private void SınıfBir_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }
        void listele ()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From SınıfBır", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into SınıfBır (AD,SOYAD,YAS,CINSIYET) values (@o1,@o2,@o3,@o4)", baglanti); 
            komut.Parameters.AddWithValue("@o1",txtad.Text);
            komut.Parameters.AddWithValue("@o2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@o3",txtyas.Text);
            komut.Parameters.AddWithValue("@o4",txtcınsıyet.Text);
            komut.ExecuteNonQuery();
            
            MessageBox.Show("Öğrenci Başarılı Bir Şekilde Eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

            SqlCommand komut2 = new SqlCommand("insert into Ogrencıler (AD,SOYAD,YAS,CINSIYET) values (@c1,@c2,@c3,@c4)", baglanti);
            komut2.Parameters.AddWithValue("@c1", txtad.Text);
            komut2.Parameters.AddWithValue("@c2", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@c3", txtyas.Text);
            komut2.Parameters.AddWithValue("@c4", txtcınsıyet.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From SınıfBır where ID=@o1",baglanti);
            komutsil.Parameters.AddWithValue("@o1",txtıd.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Başarılı Bir Şekilde Silindi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update SınıfBır set AD=@o1,SOYAD=@o2,YAS=@o3,CINSIYET=@o4 where ID=@o5",baglanti);
            komutguncelle.Parameters.AddWithValue("@o1",txtad.Text);
            komutguncelle.Parameters.AddWithValue("@o2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@o3", txtyas.Text);
            komutguncelle.Parameters.AddWithValue("@o4", txtcınsıyet.Text);
            komutguncelle.Parameters.AddWithValue("@o5", txtıd.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Başarılı Bir Şekilde Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Question);
            listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtyas.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtcınsıyet.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btntemizle_Click_1(object sender, EventArgs e)
        {
            txtıd.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtyas.Text = "";
            txtcınsıyet.Text = "";
            txtad.Focus();
        }
    }
}
