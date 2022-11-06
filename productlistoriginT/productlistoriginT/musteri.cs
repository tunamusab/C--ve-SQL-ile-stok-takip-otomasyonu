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
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }

        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP; Initial Catalog=stoktakip; Integrated Security=TRUE");

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void IDgetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from musteri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["tc"]);
            }
            baglanti.Close();
        }
        void tablogetir1()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select tc,satış from musteri_ist", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }
        void tablogetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select tc,borç from musteri_ist", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        string gir="";
        private void musteri_Load(object sender, EventArgs e)
        {
            label1.Text = Properties.localization.S025;
            label2.Text = Properties.localization.S026;
            label3.Text = Properties.localization.S027;
            button1.Text = Properties.localization.S028;

            gir = Form1.giris.ToString();
            IDgetir();
            tablogetir();
            tablogetir1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update musteri_ist set borç=borç-'" + textBox2.Text + "' where tc='" + comboBox1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand command = new SqlCommand("update musteri_ist set satış=satış+'" + textBox2.Text + "' where tc='" + comboBox1.Text + "'", baglanti);
            command.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            DateTime simdi = DateTime.Now;
            SqlCommand con = new SqlCommand("insert into hareket_gecmisi(kullanıcı,tarih,saat,işlem_türü) values(@kullanıcı,@tarih,@saat,@işlem_türü) ", baglanti);
            con.Parameters.AddWithValue("@kullanıcı", gir.ToString());
            con.Parameters.AddWithValue("@tarih", simdi.ToShortDateString());
            con.Parameters.AddWithValue("@saat", simdi.ToLongTimeString());
            con.Parameters.AddWithValue("@işlem_türü", "borç tahsilat");
            con.ExecuteNonQuery();
            baglanti.Close();

            foreach(Control item in groupBox1.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }

            tablogetir();
            tablogetir1();
            MessageBox.Show("borç tahsil edilmiştir...");
        }
    }
}
