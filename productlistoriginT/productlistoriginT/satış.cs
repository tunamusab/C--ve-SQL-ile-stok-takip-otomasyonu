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
    public partial class satış : Form
    {
        public satış()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-9C7V3JG\\SQLEXPRESS; Initial Catalog = stoktakip; Integrated Security = True");
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void TCgetir()
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
        void IDgetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from ürün_bilgisi", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox2.Items.Add(read["ürün_ID"]);
            }
            baglanti.Close();
        }
        string gir = "";
        private void satış_Load(object sender, EventArgs e)
        {
            label2.Text = Properties.localization.S022;
            label6.Text = Properties.localization.S006;
            label1.Text = Properties.localization.S007;
            label3.Text = Properties.localization.S023;
            button1.Text = Properties.localization.S009;
            checkBox1.Text = Properties.localization.S024;

            gir = Form1.giris.ToString();
            IDgetir();
            TCgetir();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="" || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("lütfen bütün kutucukları doldurduğunuzdan emin olunuz...","productlist");
            }
            else
            {
                baglanti.Open();

                SqlCommand fiycmd = new SqlCommand("select fiyatı from ürün_bilgisi where ürün_ID= " + comboBox2.Text, baglanti);
                SqlDataReader dr = fiycmd.ExecuteReader();
                dr.Read();
                int fiy = Convert.ToInt32(dr["fiyatı"]);
                int mik = Convert.ToInt32(textBox2.Text);
                int  snc = Convert.ToInt32(fiy * mik);
                baglanti.Close();
                if (isthere)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("update musteri_ist set borç=borç+" + snc + " where tc='" + comboBox1.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    DateTime simdi = DateTime.Now;
                    SqlCommand command = new SqlCommand("insert into hareket_gecmisi(kullanıcı,tarih,saat,işlem_türü) values(@kullanıcı,@tarih,@saat,@işlem_türü) ", baglanti);
                    command.Parameters.AddWithValue("@kullanıcı", gir.ToString());
                    command.Parameters.AddWithValue("@tarih", simdi.ToShortDateString());
                    command.Parameters.AddWithValue("@saat", simdi.ToLongTimeString());
                    command.Parameters.AddWithValue("@işlem_türü", "satış işlemi(borç)");
                    command.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand komut1 = new SqlCommand("update ürün_bilgisi set talep=talep+" + textBox2.Text + "where ürün_ID='" + comboBox2.Text + "'", baglanti);
                    komut1.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("update ürün_bilgisi set ürün_adet=ürün_adet-'"+textBox2.Text+"' where ürün_ID='"+comboBox2.Text+"'",baglanti);
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                }
                else
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("update musteri_ist set satış=satış+" + snc + " where tc='" + comboBox1.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    DateTime simdi = DateTime.Now;
                    SqlCommand command = new SqlCommand("insert into hareket_gecmisi(kullanıcı,tarih,saat,işlem_türü) values(@kullanıcı,@tarih,@saat,@işlem_türü) ", baglanti);
                    command.Parameters.AddWithValue("@kullanıcı", gir.ToString());
                    command.Parameters.AddWithValue("@tarih", simdi.ToShortDateString());
                    command.Parameters.AddWithValue("@saat", simdi.ToLongTimeString());
                    command.Parameters.AddWithValue("@işlem_türü", "satış işlemi");
                    command.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand komut1 = new SqlCommand("update ürün_bilgisi set talep=talep+" + textBox2.Text + "where ürün_ID='" + comboBox2.Text + "'", baglanti);
                    komut1.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("update ürün_bilgisi set ürün_adet=ürün_adet-'" + textBox2.Text + "' where ürün_ID='" + comboBox2.Text + "'", baglanti);
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                }
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }

                    if (item is ComboBox)
                    {
                        item.Text = "";
                    }
                }
                MessageBox.Show("satış başarılı", "productlist");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        bool isthere;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                isthere = true;
            }
            else
            {
                isthere = false;
            }
        }
    }
}
