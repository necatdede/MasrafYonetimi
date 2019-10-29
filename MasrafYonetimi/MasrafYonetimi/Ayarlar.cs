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
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }
        SQLiteConnection conn = new SQLiteConnection("data source=data.db");
        void sil()
        {
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand("delete from GelirGider where Tarih=@Tarih", conn);
            cmd.Parameters.AddWithValue("@Tarih",maskedTextBox1.Text );
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Girdiğiniz Tarihteki Tüm Kayıtlar Silindi!", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sil();
            Ana frm = (Ana)Application.OpenForms["Ana"];
            frm.getir();
            this.Close();
        }
    }
}
