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

namespace LoginScreen
{
    public partial class RegistrationScreen : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=Engindiyar\\SQLEXPRESS;Initial Catalog=UyeProjesi;Integrated Security=True");
        public RegistrationScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Uyeler(UyeTc,UyeSifre) values(@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaydınız yapılmıştır Şifreniz" + " " + textBox1.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
