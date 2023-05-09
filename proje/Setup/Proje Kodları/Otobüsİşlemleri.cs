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
    public partial class Otobüsİşlemleri : Form
    {
        public Otobüsİşlemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=LAPTOP-ECATR0T9\\SQLEXPRESS;Initial Catalog=OBS_Proje;Integrated Security=True");

        public void verileriGöster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler , baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSfrGörüntüle_Click(object sender, EventArgs e)
        {
            verileriGöster("Select * from OtobüsİslemTbl ");
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand com = new SqlCommand("insert into OtobüsİslemTbl (OtobüsID, OtobüsAdı, KoltukDüzeni, BagajHacmi) values (@OtoID, @OtoAdı, @Koltuk, @Bagaj)" , baglantı);
            com.Parameters.AddWithValue("@OtoID", textBox1.Text);
            com.Parameters.AddWithValue("@OtoAdı", comboBox1.Text);
            com.Parameters.AddWithValue("@Koltuk", comboBox2.Text);
            com.Parameters.AddWithValue("@Bagaj", comboBox3.Text);
            com.ExecuteNonQuery();
            verileriGöster("Select * from OtobüsİslemTbl ");
            baglantı.Close();

            textBox1.Clear();
            comboBox1.Text = "" ;
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand com = new SqlCommand("delete from OtobüsİslemTbl where OtobüsID = @OtoID ", baglantı);
            com.Parameters.AddWithValue("@OtoID", textBox1.Text);
            com.ExecuteNonQuery();
            verileriGöster("Select * from OtobüsİslemTbl ");
            baglantı.Close();

            textBox1.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçiliAlan = dataGridView1.SelectedCells[0].RowIndex;
            string otoID = dataGridView1.Rows[seçiliAlan].Cells[0].Value.ToString();
            string otoAdı = dataGridView1.Rows[seçiliAlan].Cells[1].Value.ToString();
            string koltuk = dataGridView1.Rows[seçiliAlan].Cells[2].Value.ToString();
            string bagaj = dataGridView1.Rows[seçiliAlan].Cells[3].Value.ToString();

            textBox1.Text = otoID;
            comboBox1.Text = otoAdı;
            comboBox2.Text = koltuk;
            comboBox3.Text = bagaj;


        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand com = new SqlCommand("update OtobüsİslemTbl set OtobüsAdı= '" +comboBox1.Text+ "' ,KoltukDüzeni= '" +comboBox2.Text+ "' ,BagajHacmi= '" +comboBox3.Text+ "' where OtobüsID= '" +textBox1.Text+ "' ", baglantı);
            com.ExecuteNonQuery();
            verileriGöster("Select * from OtobüsİslemTbl ");
            baglantı.Close();
        }

        private void btnGeriDön_Click(object sender, EventArgs e)
        {
            YöneticiSayfası formYönetici = new YöneticiSayfası();
            formYönetici.Show();
            this.Hide();
        }
    }
}
