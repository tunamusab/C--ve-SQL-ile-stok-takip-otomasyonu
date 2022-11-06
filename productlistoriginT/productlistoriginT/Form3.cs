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
    public partial class Form3 : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9C7V3JG\\SQLEXPRESS; Initial Catalog=stoktakip; Integrated Security=TRUE");
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            istatistik c = new istatistik();
            c.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            üb b = new üb();
            b.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            konum k = new konum();
            k.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Ara" || textBox1.Text=="Search")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                if (label2.Text=="KULLANICI:") 
                {
                    textBox1.Text = "Ara";
                    textBox1.ForeColor = Color.Silver;
                    tablogetir();
                }
                else
                {
                    textBox1.Text = "Search";
                    textBox1.ForeColor = Color.Silver;
                    tablogetir();
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.giris.ToString();

            if (label1.Text == "admin")
            {
                
            }
            else
            {
                button8.Visible = false;
            }

            button8.Text = Properties.localization.S059;
            label2.Text = Properties.localization.S005;
            label4.Text = Properties.localization.S006;
            label3.Text = Properties.localization.S007;
            button2.Text = Properties.localization.S008;
            button6.Text = Properties.localization.S009;
            button3.Text = Properties.localization.S010;
            button4.Text = Properties.localization.S011;
            button7.Text = Properties.localization.S012;
            button5.Text = Properties.localization.S013;
            textBox1.Text = Properties.localization.S014;

            IDgetir();
            tablogetir();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            musteri mst = new musteri();
            mst.Show();         
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("lütfen önce ürün ID ve ürün adet kutucuklarını doldurunuz...", "productlist");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update ürün_bilgisi set ürün_adet=ürün_adet+'" + int.Parse(textBox3.Text) + "'where ürün_ID='" + comboBox2.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                DateTime simdi = DateTime.Now;
                SqlCommand command = new SqlCommand("insert into hareket_gecmisi(kullanıcı,tarih,saat,işlem_türü) values(@kullanıcı,@tarih,@saat,@işlem_türü) ", baglanti);
                command.Parameters.AddWithValue("@kullanıcı",label1.Text);
                command.Parameters.AddWithValue("@tarih", simdi.ToShortDateString());
                command.Parameters.AddWithValue("@saat", simdi.ToLongTimeString());
                command.Parameters.AddWithValue("@işlem_türü", "ürün ekleme");
                command.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                SqlCommand komut1 = new SqlCommand("update ürün_bilgisi set gelen=gelen+'"+textBox3.Text+"' where ürün_ID='"+comboBox2.Text+"'",baglanti);
                komut1.ExecuteNonQuery();
                baglanti.Close();

                tablogetir();
                foreach (Control item in groupBox3.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                MessageBox.Show("ürün başarıyla depoya eklendi");
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            satış st = new satış();
            st.Show();
        }
        private void IDgetir()
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
        void tablogetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select ürün_ID,ürün_adı,marka,fiyatı,ürün_adet from ürün_bilgisi", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            fr4.Show();
            this.Hide();
        }
    }
}
