using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS_Proje
{
    public partial class YöneticiSayfası : Form
    {
        public YöneticiSayfası()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Otobüsİşlemleri formOtobüs = new Otobüsİşlemleri();
            formOtobüs.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Seferİşlemleri formSefer = new Seferİşlemleri();
            formSefer.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rezervasyonİşlemleri formRez = new Rezervasyonİşlemleri();
            formRez.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SatılanBiletler formSatBilet = new SatılanBiletler();
            formSatBilet.Show();
            this.Hide();
        }
    }
}
