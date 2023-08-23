using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginScreen
{
    public partial class LoginPage : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=Engindiyar\\SQLEXPRESS;Initial Catalog=UyeProjesi;Integrated Security=True");

        public LoginPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Uyeler where UyeTc=@p1 and UyeSifre = @p2",baglanti);
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MainPage mp = new MainPage();
                mp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Şifre veya TC");
            }
            baglanti.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationScreen rs = new RegistrationScreen();
            rs.Show();
            this.Hide();
        }
    }
}
