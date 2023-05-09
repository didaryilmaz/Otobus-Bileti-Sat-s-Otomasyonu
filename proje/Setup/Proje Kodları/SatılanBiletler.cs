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
    public partial class SatılanBiletler : Form
    {
        public SatılanBiletler()
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
        private void SatılanBiletler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oBS_ProjeDataSet7.SatılanBiletlerTbl' table. You can move, or remove it, as needed.
            this.satılanBiletlerTblTableAdapter4.Fill(this.oBS_ProjeDataSet7.SatılanBiletlerTbl);

        }
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand com = new SqlCommand("update SatılanBiletlerTbl set MüşteriAdı= '" + textBoxMüsAdı.Text + "' ,MüşteriSoyadı= '" + textBoxMüsSoy.Text + "' ,Cinsiyet= '" + comboBoxCinsiyet.Text + "' ,TelefonNo= '" + maskedTextBoxTel.Text + "' ,T.C.KimlikNo= '" + maskedTextBoxTc.Text + "' ,SeferNo= '" + textBoxSeferNo.Text + "' ,KoltukNo= '" + textBoxKoltukNo.Text + "'  where SeferNo= '" + textBoxSeferNo.Text + "' ", baglantı);
            com.ExecuteNonQuery();
            verileriGöster("Select * from SatılanBiletlerTbl ");
            baglantı.Close();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand com = new SqlCommand("delete from SatılanBiletlerTbl where SeferNo = @seferNo ", baglantı);
            com.Parameters.AddWithValue("@seferNo", textBoxSeferNo.Text);
            com.ExecuteNonQuery();
            verileriGöster("Select * from SatılanBiletlerTbl ");
            baglantı.Close();

            textBoxSeferNo.Clear();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            textBoxMüsAdı.Clear();
            textBoxMüsSoy.Clear();
            comboBoxCinsiyet.Text = "";
            maskedTextBoxTel.Clear();
            maskedTextBoxTc.Clear();
            textBoxSeferNo.Clear();
            textBoxKoltukNo.Clear();
        }

        private void btnGeriDön_Click(object sender, EventArgs e)
        {
            YöneticiSayfası frmYönetici = new YöneticiSayfası();
            frmYönetici.Show();
            this.Hide();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçiliAlan = dataGridView1.SelectedCells[0].RowIndex;
            string müsAdı = dataGridView1.Rows[seçiliAlan].Cells[0].Value.ToString();
            string müsSoyad = dataGridView1.Rows[seçiliAlan].Cells[1].Value.ToString();
            string cinsiyet = dataGridView1.Rows[seçiliAlan].Cells[2].Value.ToString();
            string telefon = dataGridView1.Rows[seçiliAlan].Cells[3].Value.ToString();
            string tc = dataGridView1.Rows[seçiliAlan].Cells[4].Value.ToString();
            string seferNo = dataGridView1.Rows[seçiliAlan].Cells[5].Value.ToString();
            string koltukNo = dataGridView1.Rows[seçiliAlan].Cells[6].Value.ToString();

            textBoxMüsAdı.Text = müsAdı;
            textBoxMüsSoy.Text = müsSoyad;
            comboBoxCinsiyet.Text = cinsiyet;
            maskedTextBoxTel.Text = telefon;
            maskedTextBoxTc.Text = tc;
            textBoxSeferNo.Text = seferNo;
            textBoxKoltukNo.Text = koltukNo;
        }
    }
}
