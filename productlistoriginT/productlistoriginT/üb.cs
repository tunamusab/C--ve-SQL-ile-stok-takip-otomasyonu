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
    public partial class üb : Form
    {
        public üb()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9C7V3JG\\SQLEXPRESS; Initial Catalog=stoktakip; Integrated Security=TRUE");
        SqlDataAdapter da = new SqlDataAdapter();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fr3 = new Form3();
            fr3.Show();
        }
        void tablogetir1()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select ürün_ID,ürün_adı,ürün_cinsi,marka,kumaş_kalitesi,aksesuar,üretildiği_yer,fiyatı,maliyeti,ürün_adet,depo_numarası from ürün_bilgisi", baglanti);//sql tablosunu data gride aktarma
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void üb_Load(object sender, EventArgs e)
        {
            button1.Text = Properties.localization.S060;
            label1.Text = Properties.localization.S006;

            tablogetir1();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from ürün_bilgisi where ürün_ID like '%" + textBox1.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            raporlama rp = new raporlama();
            rp.Show();
            this.Hide();
        }
    }
}
