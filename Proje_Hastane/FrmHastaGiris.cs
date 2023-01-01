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

namespace Proje_Hastane
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit hk=new FrmHastaKayit();
            hk.Show();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand grs = new SqlCommand("select * from Tbl_Hastalar where HastaTC=@p1 and HastaSifre=@p2", bgl.baglanti());
            grs.Parameters.AddWithValue("@p1",mskTC.Text);
            grs.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dr= grs.ExecuteReader();
            if (dr.Read())
            {
                FrmHastaDetay hd = new FrmHastaDetay();
                hd.tc = mskTC.Text;
                hd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Tc veya Şifre");
            }
            bgl.baglanti().Close();
            
        }
    }
}
