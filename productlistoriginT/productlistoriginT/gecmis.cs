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
    public partial class gecmis : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9C7V3JG\\SQLEXPRESS; Initial Catalog=stoktakip; Integrated Security=TRUE");
        public gecmis()
        {
            InitializeComponent();
        }
        void tablogetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select *from giris_gecmis", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void gecmis_Load(object sender, EventArgs e)
        {
            label1.Text = Properties.localization.S020;
            button2.Text = Properties.localization.S021;

            tablogetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from giris_gecmis",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            tablogetir();
        }
    }
}
