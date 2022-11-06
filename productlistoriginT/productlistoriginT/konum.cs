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
    public partial class konum : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9C7V3JG\\SQLEXPRESS; Initial Catalog=stoktakip; Integrated Security=TRUE");
        public konum()
        {
            InitializeComponent();
        }

        private void konum_Load(object sender, EventArgs e)
        {
            label1.Text = Properties.localization.S006;

            tablogetir();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select ürün_ID,ürün_adı,depo_numarası from ürün_bilgisi where ürün_ID like '%" + textBox1.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void tablogetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select ürün_ID,ürün_adı,depo_numarası from ürün_bilgisi", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
