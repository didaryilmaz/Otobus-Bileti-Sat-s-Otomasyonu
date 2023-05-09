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
    public partial class Seferİşlemleri : Form
    {
        public Seferİşlemleri()
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

        private void btnSfrGörüntüle_Click(object sender, EventArgs e)
        {
            verileriGöster("Select * from SeferİslemTbl ");
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand com = new SqlCommand("insert into SeferİslemTbl (Nereden, Nereye, SeferNo, SeferTarihi, SeferSaati, OtobüsAdı, PeronNo, SeferÜcreti) values (@nereden, @nereye, @seferNo, @tarih, @saat, @otoAdı, @peron, @ücret)", baglantı);
            
            com.Parameters.AddWithValue("@nereden", comboBox1.Text);
            com.Parameters.AddWithValue("@nereye", comboBox2.Text);
            com.Parameters.AddWithValue("@seferNo", textBox1.Text);
            com.Parameters.AddWithValue("@tarih", maskedTextBox1.Text);
            com.Parameters.AddWithValue("@saat", maskedTextBox2.Text);
            com.Parameters.AddWithValue("@otoAdı", comboBox3.Text);
            com.Parameters.AddWithValue("@peron", textBox2.Text);
            com.Parameters.AddWithValue("@ücret", textBox3.Text);
            com.ExecuteNonQuery();
            verileriGöster("Select * from SeferİslemTbl ");
            baglantı.Close();

            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Clear();
            maskedTextBox1.Text = "";
            maskedTextBox2.Clear();
            comboBox3.Text = "";
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand com = new SqlCommand("delete from SeferİslemTbl where SeferNo = @seferNo ", baglantı);
            com.Parameters.AddWithValue("@seferNo", textBox1.Text);
            com.ExecuteNonQuery();
            verileriGöster("Select * from SeferİslemTbl ");
            baglantı.Close();

            textBox1.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

            comboBox1.Text = nereden;
            comboBox2.Text = nereye;
            textBox1.Text = seferNo;
            maskedTextBox1.Text = tarih;
            maskedTextBox2.Text = saat;
            comboBox3.Text = otoAdı;
            textBox2.Text = peron;
            textBox3.Text = ücret;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand com = new SqlCommand("update SeferİslemTbl set Nereden= '" + comboBox1.Text + "' ,Nereye= '" + comboBox2.Text + "' ,SeferNo= '" + textBox1.Text + "' ,SeferTarihi= '" + maskedTextBox1.Text + "' ,SeferSaati= '" + maskedTextBox2.Text + "' ,OtobüsAdı= '" + comboBox3.Text + "' ,PeronNo= '" + textBox2.Text + "' ,SeferÜcreti= '" + textBox3.Text + "' where SeferNo= '" + textBox1.Text + "' ", baglantı);
            com.ExecuteNonQuery();
            verileriGöster("Select * from SeferİslemTbl ");
            baglantı.Close();
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
    }
}
