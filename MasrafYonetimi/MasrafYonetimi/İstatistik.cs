using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasrafYonetimi
{
    public partial class İstatistik : Form
    {
        public İstatistik()
        {
            InitializeComponent();
        }

        private void İstatistik_Load(object sender, EventArgs e)
        {
            //Grafiğe değer ekleme
            chart1.Series["Gelir-Gider"].Points.Add(Rapor.gelir);
            chart1.Series["Gelir-Gider"].Points.Add(Rapor.gider);


            //x ekseninde isimlerini belirleme
            chart1.Series["Gelir-Gider"].Points[0].AxisLabel = "Gelir";
            chart1.Series["Gelir-Gider"].Points[1].AxisLabel = "Gider";

            chart1.Series["Gelir-Gider"].Points[0].Color = Color.LightGreen;
            chart1.Series["Gelir-Gider"].Points[1].Color = Color.IndianRed;

        }
    }
}
