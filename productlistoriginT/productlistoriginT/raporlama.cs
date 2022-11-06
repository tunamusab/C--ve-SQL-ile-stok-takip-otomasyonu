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
    public partial class raporlama : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9C7V3JG\\SQLEXPRESS; Initial Catalog=stoktakip; Integrated Security=TRUE");
        public raporlama()
        {
            InitializeComponent();
        }

        private void raporlama_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'stoktakipDataSet1.ürün_bilgisi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ürün_bilgisiTableAdapter.Fill(this.stoktakipDataSet.ürün_bilgisi);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            üb fr = new üb();
            fr.Show();
            this.Hide();
        }
    }
}
