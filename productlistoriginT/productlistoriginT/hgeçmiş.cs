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

namespace productlistoriginT
{
    public partial class hgeçmiş : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP; Initial Catalog=stoktakip; Integrated Security=TRUE");
        SqlDataAdapter da = new SqlDataAdapter();
        public hgeçmiş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        void tablogetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select *from hareket_gecmisi", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void hgeçmiş_Load(object sender, EventArgs e)
        {
            button2.Text = Properties.localization.S021;

            tablogetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from hareket_gecmisi",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            tablogetir();
        }
    }
}
