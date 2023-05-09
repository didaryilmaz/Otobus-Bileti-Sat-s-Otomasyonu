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
    public partial class Rezervasyonİşlemleri : Form
    {
        public Rezervasyonİşlemleri()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=LAPTOP-ECATR0T9\\SQLEXPRESS;Initial Catalog=OBS_Proje;Integrated Security=True");

        public void verileriGöster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Rezervasyonİşlemleri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oBS_ProjeDataSet5.SeferİslemTbl' table. You can move, or remove it, as needed.
            this.seferİslemTblTableAdapter1.Fill(this.oBS_ProjeDataSet5.SeferİslemTbl);
            // TODO: This line of code loads data into the 'oBS_ProjeDataSet1.SeferİslemTbl' table. You can move, or remove it, as needed.
            this.seferİslemTblTableAdapter.Fill(this.oBS_ProjeDataSet1.SeferİslemTbl);

        }

        private void btnDevamEt_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand com = new SqlCommand("insert into SatılanBiletlerTbl (MüşteriAdı, MüşteriSoyadı, Cinsiyet, TelefonNo, [T.C.KimlikNo], SeferNo ,KoltukNo) values (@adı, @soyadı, @cinsiyet, @telefon, @tc, @seferNo, @koltuk)", baglantı);

            com.Parameters.AddWithValue("@adı", textBoxMüsAdı.Text);
            com.Parameters.AddWithValue("@soyadı", textBoxMüsSoy.Text);
            com.Parameters.AddWithValue("@cinsiyet", comboBoxCinsiyet.Text);
            com.Parameters.AddWithValue("@telefon", maskedTextBoxTel.Text);
            com.Parameters.AddWithValue("@tc", maskedTextBoxTc.Text);
            com.Parameters.AddWithValue("@seferNo", textBox1.Text);
            com.Parameters.AddWithValue("@koltuk", textBox4.Text);
            com.ExecuteNonQuery();
            verileriGöster("Select * from SatılanBiletlerTbl ");
            baglantı.Close();

            SatılanBiletler frmBiletler = new SatılanBiletler();
            frmBiletler.Show();
            this.Hide();
        }

        private void btnGeriDön_Click(object sender, EventArgs e)
        {
            YöneticiSayfası formYönetici = new YöneticiSayfası();
            formYönetici.Show();
            this.Hide();
        }

        private void btnDeğiştir_Click(object sender, EventArgs e)
        {
            lblGizli.Text = comboBox1.Text;
            comboBox1.Text = comboBox2.Text;
            comboBox2.Text = lblGizli.Text;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int seçiliAlan = dataGridView1.SelectedCells[0].RowIndex;
            string nereden = dataGridView1.Rows[seçiliAlan].Cells[0].Value.ToString();
            string nereye = dataGridView1.Rows[seçiliAlan].Cells[1].Value.ToString();
            string seferNo = dataGridView1.Rows[seçiliAlan].Cells[2].Value.ToString();
            string tarih = dataGridView1.Rows[seçiliAlan].Cells[3].Value.ToString();
            string saat = dataGridView1.Rows[seçiliAlan].Cells[4].Value.ToString();
            string otoAdı = dataGridView1.Rows[seçiliAlan].Cells[5].Value.ToString();
            string peron = dataGridView1.Rows[seçiliAlan].Cells[6].Value.ToString();
            string ücret = dataGridView1.Rows[seçiliAlan].Cells[7].Value.ToString();
            string koltuk = dataGridView1.Rows[seçiliAlan].Cells[8].Value.ToString();


            comboBox1.Text = nereden;
            comboBox2.Text = nereye;
            textBox1.Text = seferNo;
            maskedTextBox1.Text = tarih;
            maskedTextBox2.Text = saat;
            comboBox3.Text = otoAdı;
            textBox2.Text = peron;
            textBox3.Text = ücret;
            textBox4.Text = koltuk;
        }
    }
}
