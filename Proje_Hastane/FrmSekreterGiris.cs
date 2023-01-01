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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand grs = new SqlCommand("select * from Tbl_Sekreterler where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
            grs.Parameters.AddWithValue("@p1", mskTC.Text);
            grs.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = grs.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay sd = new FrmSekreterDetay();
                sd.tc = mskTC.Text;
                sd.Show();
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
