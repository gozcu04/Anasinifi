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
    public partial class Calısanlar : Form
    {
        public Calısanlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-V6Q0A0I\SQLEXPRESS;Initial Catalog=AnasinifiOtomasyon;Integrated Security=True");

        private void Calısanlar_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            //Çalışanlar Verilerini Datagride çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From CALISAN", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into CALISAN (AD,SOYAD) values (@c1,@c2)", baglanti);
            komut.Parameters.AddWithValue("@c1", txtad.Text);
            komut.Parameters.AddWithValue("@c2", txtsoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Çalışan Başarılı Bir Şekilde Eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From CALISAN where ID=@c1", baglanti);
            komutsil.Parameters.AddWithValue("@c1", txtıd.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Çalışan Başarılı Bir Şekilde Silindi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update CALISAN set AD=@c1,SOYAD=@c2 where ID=@c3", baglanti);
            komutguncelle.Parameters.AddWithValue("@c1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@c2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@c3", txtıd.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Çalışan Başarılı Bir Şekilde Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtıd.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtad.Focus();
        }
    }
}
