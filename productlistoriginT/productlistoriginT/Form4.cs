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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet daset = new DataSet();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-; Initial Catalog=stoktakip; Integrated Security=TRUE");
        private void Form4_Load(object sender, EventArgs e)
        {
            label6.Text = Properties.localization.S035;
            label5.Text = Properties.localization.S036;
            label9.Text = Properties.localization.S037;
            label7.Text = Properties.localization.S038;
            label20.Text = Properties.localization.S040;
            label4.Text = Properties.localization.S057;
            label3.Text = Properties.localization.S058;
            label19.Text = Properties.localization.S056;
            label23.Text = Properties.localization.S006;
            label1.Text = Properties.localization.S045;
            label2.Text = Properties.localization.S046;
            label15.Text = Properties.localization.S047;
            label14.Text = Properties.localization.S048;
            label13.Text = Properties.localization.S049;
            label18.Text = Properties.localization.S050;
            label21.Text = Properties.localization.S006;
            label22.Text = Properties.localization.S027;
            label12.Text = Properties.localization.S051;
            label11.Text = Properties.localization.S052;
            label17.Text = Properties.localization.S053;
            label16.Text = Properties.localization.S054;
            button9.Text = Properties.localization.S041;
            button10.Text = Properties.localization.S042;
            button12.Text = Properties.localization.S043;
            button11.Text = Properties.localization.S044;
            button2.Text = Properties.localization.S008;
            button3.Text = Properties.localization.S039;
            button4.Text = Properties.localization.S019;
            button1.Text = Properties.localization.S008;
            button7.Text = Properties.localization.S039;
            button6.Text = Properties.localization.S019;
            button8.Text = Properties.localization.S055;

            musteri_göster();
            tablogetir();
            tablogetir1();
            IDgetir();
        }
        private void musteri_göster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from musteri", baglanti);//data gride musteri tablosunu aktarma
            adtr.Fill(daset, "musteri");
            dataGridView1.DataSource = daset.Tables["musteri"];
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtürün.Text == "" || string.IsNullOrEmpty(txtkategori.Text) || string.IsNullOrEmpty(txtmarka.Text) || string.IsNullOrEmpty(txtkalite.Text) || string.IsNullOrEmpty(txtaksesuar.Text) || string.IsNullOrEmpty(txtyer.Text) || string.IsNullOrEmpty(txtfiyat.Text) || string.IsNullOrEmpty(txtmaliyet.Text) || string.IsNullOrEmpty(txtdepo.Text) || string.IsNullOrEmpty(txtadet.Text))
            {
                MessageBox.Show("yeni ürün bilgilerini eksiksiz girdiğinizden emin olun...", "productlist");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into ürün_bilgisi(ürün_adı,ürün_cinsi,marka,kumaş_kalitesi,aksesuar,üretildiği_yer,fiyatı,maliyeti,ürün_adet,depo_numarası) values (@ürün_adı,@ürün_cinsi,@marka,@kumaş_kalitesi,@aksesuar,@üretildiği_yer,@fiyatı,@maliyeti,@ürün_adet,@depo_numarası)", baglanti);//yeni ürün ekleme
                komut.Parameters.AddWithValue("@ürün_adı", txtürün.Text);
                komut.Parameters.AddWithValue("@ürün_cinsi", txtkategori.Text);
                komut.Parameters.AddWithValue("@marka", txtmarka.Text);
                komut.Parameters.AddWithValue("@kumaş_kalitesi", txtkalite.Text);
                komut.Parameters.AddWithValue("@aksesuar", txtaksesuar.Text);
                komut.Parameters.AddWithValue("@üretildiği_yer", txtyer.Text);
                komut.Parameters.AddWithValue("@fiyatı", double.Parse(txtfiyat.Text));
                komut.Parameters.AddWithValue("@maliyeti", double.Parse(txtmaliyet.Text));
                komut.Parameters.AddWithValue("@ürün_adet", int.Parse(txtadet.Text));
                komut.Parameters.AddWithValue("@depo_numarası", int.Parse(txtdepo.Text));

                komut.ExecuteNonQuery();
                baglanti.Close();
                tablogetir1();
                MessageBox.Show("yeni ürün eklendi");
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }
        void tablogetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select *from musteri", baglanti);//sql tablosunu data gride aktarma
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        void tablogetir1()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select ürün_ID,ürün_adı,ürün_cinsi,marka,kumaş_kalitesi,aksesuar,üretildiği_yer,fiyatı,maliyeti,ürün_adet,depo_numarası from ürün_bilgisi", baglanti);//sql tablosunu data gride aktarma
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || string.IsNullOrEmpty(txtSoyad.Text) || string.IsNullOrEmpty(txtAdres.Text) || string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("yeni müşteri bilgilerini eksiksiz girdiğinizden emin olun...", "productlist");
            }
            else {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into musteri(tc,ad,soyad,adres,telefon,email) values (@tc,@ad,@soyad,@adres,@telefon,@email)", baglanti);//yeni müşteri ekleme
                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@ad", txtAd.Text);
                komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                komut.Parameters.AddWithValue("@adres", txtAdres.Text);
                komut.Parameters.AddWithValue("@telefon", txtTel.Text);
                komut.Parameters.AddWithValue("@email", txtEmail.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                komut = new SqlCommand("insert into musteri_ist(tc) values (@tc)", baglanti);
                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                daset.Tables["musteri"].Clear();
                tablogetir();
                MessageBox.Show("yeni müşteri eklendi");
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update musteri set ad=@ad,soyad=@soyad,adres=@adres,telefon=@telefon,email=@email where tc=@tc", baglanti);//musteri güncelleme
            komut.Parameters.AddWithValue("@tc", txtTc.Text);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@telefon", txtTel.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["musteri"].Clear();
            tablogetir();
            MessageBox.Show("müşteri kaydı güncellendi");
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//data gride cift tıklandığında verileri textboxlara doldurma
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells["ad"].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)//müşteri tc sine göre müşteriyi silme
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from musteri where tc='"+dataGridView1.CurrentRow.Cells["tc"].Value.ToString()+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["musteri"].Clear();
            tablogetir();
            MessageBox.Show("kayıt silindi");
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)//TC ile müşteri sorgusu
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from musteri where tc like '%"+textBox3.Text+"%'",baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from ürün_bilgisi where ürün_ID like '%" + textBox4.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fr3 = new Form3();
            fr3.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update ürün_bilgisi set ürün_adı=@ürün_adı,ürün_cinsi=@ürün_cinsi,marka=@marka,kumaş_kalitesi=@kumaş_kalitesi,aksesuar=@aksesuar,üretildiği_yer=@üretildiği_yer,fiyatı=@fiyatı,maliyeti=@maliyeti,ürün_adet=@ürün_adet,depo_numarası=@depo_numarası where ürün_ID=@ürün_ID", baglanti);//ürün güncelleme
            komut.Parameters.AddWithValue("@ürün_ID",comboBox1.Text);
            komut.Parameters.AddWithValue("@ürün_adı", txtürün.Text);
            komut.Parameters.AddWithValue("@ürün_cinsi", txtkategori.Text);
            komut.Parameters.AddWithValue("@marka", txtmarka.Text);
            komut.Parameters.AddWithValue("@kumaş_kalitesi", txtkalite.Text);
            komut.Parameters.AddWithValue("@aksesuar", txtaksesuar.Text);
            komut.Parameters.AddWithValue("@üretildiği_yer", txtyer.Text);
            komut.Parameters.AddWithValue("@fiyatı", double.Parse(txtfiyat.Text));
            komut.Parameters.AddWithValue("@maliyeti", double.Parse(txtmaliyet.Text));
            komut.Parameters.AddWithValue("@ürün_adet", int.Parse(txtadet.Text));
            komut.Parameters.AddWithValue("@depo_numarası", int.Parse(txtdepo.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            tablogetir1();
            MessageBox.Show("ürün kaydı güncellendi");
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Text = dataGridView2.CurrentRow.Cells["ürün_ID"].Value.ToString();
            comboBox1.Text = dataGridView2.CurrentRow.Cells["ürün_ID"].Value.ToString();
            txtürün.Text = dataGridView2.CurrentRow.Cells["ürün_adı"].Value.ToString();
            txtkategori.Text = dataGridView2.CurrentRow.Cells["ürün_cinsi"].Value.ToString();
            txtmarka.Text = dataGridView2.CurrentRow.Cells["marka"].Value.ToString();
            txtkalite.Text = dataGridView2.CurrentRow.Cells["kumaş_kalitesi"].Value.ToString();
            txtaksesuar.Text = dataGridView2.CurrentRow.Cells["aksesuar"].Value.ToString();
            txtyer.Text = dataGridView2.CurrentRow.Cells["üretildiği_yer"].Value.ToString();
            txtfiyat.Text = dataGridView2.CurrentRow.Cells["fiyatı"].Value.ToString();
            txtmaliyet.Text = dataGridView2.CurrentRow.Cells["maliyeti"].Value.ToString();
            txtadet.Text = dataGridView2.CurrentRow.Cells["ürün_adet"].Value.ToString();
            txtdepo.Text = dataGridView2.CurrentRow.Cells["depo_numarası"].Value.ToString();
        }
        private void IDgetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from ürün_bilgisi", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["ürün_ID"]);
                comboBox2.Items.Add(read["ürün_ID"]);
            }
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from ürün_bilgisi where ürün_ID='" + dataGridView2.CurrentRow.Cells["ürün_ID"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            tablogetir1();
            MessageBox.Show("kayıt silindi");
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if(item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            gecmis g = new gecmis();
            g.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("lütfen önce ürün ID ve ürün adet kutucuklarını doldurunuz...", "productlist");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update ürün_bilgisi set ürün_adet=ürün_adet-'"+ textBox2.Text +"' where ürün_ID='"+ comboBox2.Text +"'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                tablogetir1();
                foreach (Control item in groupBox3.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                    if(item is ComboBox)
                    {
                        item.Text = "";
                    }
                }
                MessageBox.Show("ürün başarıyla depodan kaldırıldı...","productlist");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hgeçmiş frm = new hgeçmiş();
            frm.Show();
        }

    }
}