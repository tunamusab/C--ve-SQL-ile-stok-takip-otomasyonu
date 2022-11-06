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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataSet daset = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9C7V3JG\\SQLEXPRESS; Initial Catalog=stoktakip; Integrated Security=TRUE");
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("kutucukları doldurduğunuzdan emin olun.");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into login(username,pass) values(@username,@pass)", baglanti);
                komut.Parameters.AddWithValue("@username", textBox1.Text);
                komut.Parameters.AddWithValue("@pass", textBox2.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                tablogetir();
                MessageBox.Show("yeni kullanıcı eklendi", "admin");
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
            da = new SqlDataAdapter("select *from login", baglanti);//sql tablosunu data gride aktarma
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from login where no='" + textBox3.Text + "'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            tablogetir();
            MessageBox.Show("kullanıcı silindi");
            foreach (Control item in groupBox2.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label4.Text = Properties.localization.S015;
            label1.Text = Properties.localization.S016;
            label2.Text = Properties.localization.S017;
            button1.Text = Properties.localization.S008;
            label3.Text = Properties.localization.S018;
            button2.Text = Properties.localization.S019;

            tablogetir();
        }
    }
}
