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

namespace OBS_Proje
{
    public partial class FirmaKaydı : Form
    {
        public FirmaKaydı()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-ECATR0T9\\SQLEXPRESS;Initial Catalog=OBS_Proje;Integrated Security=True");

        Giris grs = new Giris();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            grs.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtBoxFirmaAd.Text == "" || txtBoxFKulAdı.Text == "" || txtBoxFsifre.Text == "" || maskedTextBoxFtelefon.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
            else
            {
                baglan.Open();

                string kulAdı;
                kulAdı = txtBoxFKulAdı.Text;

                SqlCommand komut = new SqlCommand("Select * from KayıtOlTbl where KullanıcıAdı = '" + kulAdı + "' ", baglan);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Bu Kullanıcı Adı kullanılıyor. Lütfen farklı bir Kullanıcı Adı giriniz.");
                }
                else
                {
                    oku.Close();
                    SqlCommand firmaEkle = new SqlCommand("Insert Into KayıtOlTbl (KullanıcıAdı,Sifre,FirmaAdı,Telefon,KullanıcıTipi) Values ('" + txtBoxFKulAdı.Text.ToString() + "' , '" + txtBoxFsifre.Text.ToString() + "' , '" + txtBoxFirmaAd.Text.ToString() + "' , '" + maskedTextBoxFtelefon.Text.ToString() + "')", baglan);
                    firmaEkle.ExecuteNonQuery();

                    MessageBox.Show("Firma Kaydı Oluşturdunuz.");

                    this.Close();
                    grs.Show();
                }
            }
        }
    }
}
