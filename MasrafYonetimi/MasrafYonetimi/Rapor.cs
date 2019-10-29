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
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }
        public static int gelir;
        public static int gider;
        DataTable ds;
        SQLiteConnection conn = new SQLiteConnection("data source=data.db");
        void hesapla()
        {
            int topgelir = 0;
            int topgider = 0;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from GelirGider", conn);
            SQLiteDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                if (oku["GelirGider"].ToString() == "Gelir") topgelir = topgelir + int.Parse(oku["Tutar"].ToString());
                if (oku["GelirGider"].ToString() == "Gider") topgider = topgider + int.Parse(oku["Tutar"].ToString());                                  
            }
            int toplam = topgelir - topgider;
            label2.Text = topgelir.ToString();
            gelir = topgelir;
            label3.Text = topgider.ToString();
            gider = topgider;
            label5.Text = toplam.ToString();
            if (toplam<0)
            {
                label7.Text = "Durum İyi Değil";
                label5.BackColor = Color.IndianRed;
            }
            else
            {
                label7.Text = "Durum Gayet İyi";
                label5.BackColor = Color.LightGreen;
            }
            conn.Close();
        }
        private void Rapor_Load(object sender, EventArgs e)
        {
            hesapla();
            conn.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter("select* from GelirGider", conn);
            ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView dv = ds.DefaultView;
            dv.RowFilter = string.Format("Tarih >'{0}' AND Tarih <='{1}'", maskedTextBox1.Text, maskedTextBox2.Text);
            dataGridView1.DataSource = dv;
        }
    }
}
