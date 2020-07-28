using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnasınıfıOtomasyon
{
    public partial class OgretmenSıstem : Form
    {
        public OgretmenSıstem()
        {
            InitializeComponent();
        }

        private void btnsınf1_Click(object sender, EventArgs e)
        {
            Sınıf1 snf1 = new Sınıf1();
            snf1.Show();
        }

        private void btnsınıf2_Click(object sender, EventArgs e)
        {
            Sınıf2 snf2 = new Sınıf2();
            snf2.Show();
        }

        private void btnsınıf3_Click(object sender, EventArgs e)
        {
            Sınıf3 snf3 = new Sınıf3();
            snf3.Show();
        }

        private void OgretmenSıstem_Load(object sender, EventArgs e)
        {

        }
    }
}
