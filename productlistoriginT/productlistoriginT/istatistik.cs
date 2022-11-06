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
    public partial class istatistik : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9C7V3JG\\SQLEXPRESS; Initial Catalog=stoktakip; Integrated Security=TRUE");
        SqlDataAdapter da = new SqlDataAdapter();
        public istatistik()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fr3 = new Form3();
            fr3.Show();
        }

        public void rowcolor()
        {
            for(int i = 0; i<x; i++)
            {
                int val = Int32.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                if (val < 250)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (val>=250 && val<500)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (val >= 500 && val < 1000)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }
        int x = 0;
        void tablogetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select ürün_ID,ürün_adı,ürün_cinsi,ürün_adet from ürün_bilgisi", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void urun()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select ürün_ID,ürün_adı,talep from ürün_bilgisi order by talep desc", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }

        private void musteri()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select no, tc, satış from musteri_ist order by satış desc", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView3.DataSource = tablo;
            baglanti.Close();
        }

        private void istatistik_Load(object sender, EventArgs e)
        {
            urun();
            musteri();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select count(ürün_ID) from ürün_bilgisi", baglanti);
            SqlDataReader read6 = komut6.ExecuteReader();
            while (read6.Read())
            {
                x = Convert.ToInt32(read6[0]);
            }
            baglanti.Close();

            DataTable dt = new DataTable();

            tablogetir();
            rowcolor();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update ürün_bilgisi set f_m = maliyeti*ürün_adet", baglanti);
            komut3.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update ürün_bilgisi set f_ü = fiyatı*ürün_adet", baglanti);
            komut4.ExecuteNonQuery();
            baglanti.Close();

            label1.Text = Properties.localization.S029;
            label2.Text = Properties.localization.S031;
            label12.Text = Properties.localization.S030;
            label3.Text = Properties.localization.S032;
            label10.Text = Properties.localization.S033;
            label11.Text = Properties.localization.S034;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(satış) from musteri_ist",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                label27.Text = read[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select sum(f_m) from ürün_bilgisi",baglanti);
            SqlDataReader read1 = komut1.ExecuteReader();
            while (read1.Read())
            {
                label26.Text = read1[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(f_ü) from ürün_bilgisi", baglanti);
            SqlDataReader read2 = komut2.ExecuteReader();
            while (read2.Read())
            {
                label25.Text = read2[0].ToString();
            }
            baglanti.Close();
        }
    }
}
