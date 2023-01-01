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

namespace Proje_Hastane
{
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand grs = new SqlCommand("select * from Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2", bgl.baglanti());
            grs.Parameters.AddWithValue("@p1", mskTC.Text);
            grs.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = grs.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay dd = new FrmDoktorDetay();
                dd.tc = mskTC.Text;
                dd.Show();
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
