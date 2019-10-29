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
    public partial class Gider : Form
    {
        public Gider()
        {
            InitializeComponent();
        }
        SQLiteConnection conn = new SQLiteConnection("data source=data.db");
        void ekle()
        {
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand("insert into GelirGider (Tarih,Tutar,Aciklama,GelirGider) values (@Tarih,@Tutar,@Aciklama,@GelirGider)", conn);
            cmd.Parameters.AddWithValue("@Tarih", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@Tutar", textBox2.Text);
            cmd.Parameters.AddWithValue("@Aciklama", textBox1.Text);
            cmd.Parameters.AddWithValue("@GelirGider", "Gider");
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Gider Ekleme Başarılı!", "Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }       
        private void button1_Click(object sender, EventArgs e)
        {
            ekle();
            Ana frm = (Ana)Application.OpenForms["Ana"];
            frm.getir();
            this.Close();
        }
    }
}
