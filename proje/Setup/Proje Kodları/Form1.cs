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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=LAPTOP-ECATR0T9\\SQLEXPRESS;Initial Catalog=OBS_Proje;Integrated Security=True");


        private void btnYönKaydı_Click_1(object sender, EventArgs e)
        {
            FirmaKaydı frmFrmKyt = new FirmaKaydı();
            frmFrmKyt.Show();
            this.Hide();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            try
            {
                baglantı.Open();
                string sql = "Select * from KayıtOlTbl where KullanıcıAdı = @KullanıcıAdı and Sifre = @Sifre";
                SqlParameter prm1 = new SqlParameter("@KullanıcıAdı", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("@Sifre", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql , baglantı);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dt.Rows.Count > 0)
                {
                    YöneticiSayfası frmYönetici = new YöneticiSayfası();
                    frmYönetici.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Kullanıcı Adı veya Parola Geçersizdir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
