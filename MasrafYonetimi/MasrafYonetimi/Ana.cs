using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace MasrafYonetimi
{
    public partial class Ana : Form
    {
        public Ana()
        {
            InitializeComponent();
        }
        SQLiteConnection conn = new SQLiteConnection("data source=data.db");
        private void gelirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gelir frm = new Gelir();
            frm.MdiParent = this;
            frm.Show();
        }
        public void getir()
        {
            conn.Open();
            SQLiteDataAdapter ad = new SQLiteDataAdapter("select * from GelirGider", conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Ana_Load(object sender, EventArgs e)
        {
            getir();
        }

        private void giderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gider frm = new Gider();
            frm.MdiParent = this;
            frm.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void raporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rapor frm = new Rapor();
            frm.MdiParent = this;
            frm.Show();

        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar frm = new Ayarlar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bilgi alabilmek için www.necatdede.com adresine gidin","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            İstatistik frm = new İstatistik();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
