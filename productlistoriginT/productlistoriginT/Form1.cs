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
using System.Globalization;
using System.Threading;

namespace productlistoriginT
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-9C7V3JG\\SQLEXPRESS; Initial Catalog=stoktakip; Integrated Security=TRUE");
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı adı" || textBox1.Text=="Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                if (button1.Text == "LOGİN")
                {
                    textBox1.Text = "Username";
                    textBox1.ForeColor = Color.Silver;
                }
                else
                {
                    textBox1.Text = "Kullanıcı adı";
                    textBox1.ForeColor = Color.Silver;
                }
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre" || textBox2.Text=="Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '*';
            }
        }
        char? none = null;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                if (button1.Text == "LOGİN")
                {
                    textBox2.Text = "Password";
                    textBox2.ForeColor = Color.Silver;
                    textBox2.PasswordChar = Convert.ToChar(none);
                }
                else
                {
                    textBox2.Text = "Şifre";
                    textBox2.ForeColor = Color.Silver;
                    textBox2.PasswordChar = Convert.ToChar(none);
                }
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
        }
        public static string giris="";
        bool isthere;
        bool isthere2;
        private void button1_Click(object sender, EventArgs e)
        {
            loginsave();
            string username = textBox1.Text;
            string pass = textBox2.Text;
            if (textBox1.Text == "" || string.IsNullOrEmpty(textBox2.Text) || textBox1.Text=="Kullanıcı adı" || textBox2.Text=="Şifre")
            {
                
            }
            if (username=="admin" && pass=="pass")
            {
                giris = username;
                Form4 fr4 = new Form4();
                fr4.Show();
                this.Hide();
                isthere2 = true;
            }
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from login where username='" + username + "' and pass='" + pass + "'", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                if (username == reader["username"].ToString().TrimEnd() && pass == reader["pass"].ToString().TrimEnd())
                {
                    isthere = true;
                    break;
                }
                else
                {
                    isthere = false;
                }
            }
            if (isthere)
            {
                giris = username;
                Form3 fr3 = new Form3();
                fr3.Show();
                this.Hide();
            }
            else if (isthere2)
            {

            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı...", "productlist");
            }
                connection.Close();
        }
        private void loginsave()
        {
            DateTime simdi = DateTime.Now;
            connection.Open();
            SqlCommand komut = new SqlCommand("insert into giris_gecmis(kullanici_adi,tarih,saat)values(@kullanici_adi,@tarih,@saat)", connection);
            komut.Parameters.AddWithValue("kullanici_adi",textBox1.Text);
            komut.Parameters.AddWithValue("tarih",simdi.ToShortDateString());
            komut.Parameters.AddWithValue("saat",simdi.ToLongTimeString()); //button click1 in içine program bitiminde atanacak
            komut.ExecuteNonQuery();
            connection.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = Properties.localization.S001;
            button3.Text = Properties.localization.S002;
            textBox1.Text = Properties.localization.S003;
            textBox2.Text = Properties.localization.S004;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text=="TÜRKÇE") 
            {
                Properties.Settings.Default.lang = "en-US";
                Properties.Settings.Default.Save();
                Application.Restart();
            }
            else
            {
                Properties.Settings.Default.lang = "tr";
                Properties.Settings.Default.Save();
                Application.Restart();
            }
        }
    }
}
