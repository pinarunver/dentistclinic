using Dentistclinicc.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ZedGraph;

namespace Dentistclinicc.PL
{
    public partial class DoktorRandevuDurumPL : Form
    {
        private DoktorRandevuDurumBLL _bll = new DoktorRandevuDurumBLL();

        public DoktorRandevuDurumPL()
        {
            InitializeComponent();
        }

        private void DoktorRandevuDurumPL_Load(object sender, EventArgs e)
        { // Doktorları ComboBox'a yükle
            DataTable doktorlar = _bll.GetDoktorlar();
            comboBox1.DataSource = doktorlar;
            comboBox1.DisplayMember = "DoktorAdi";
            comboBox1.ValueMember = "DoktorAdi";
        }



        private void btngiris_Click_Click(object sender, EventArgs e)
        {
            string selectedDoktor = comboBox1.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedDoktor))
            {
                MessageBox.Show("Lütfen bir doktor seçiniz.");
                return;
            }

            DataTable randevuSayisi = _bll.GetRandevuSayisiByDoktor(selectedDoktor);

            if (randevuSayisi.Rows.Count == 0)
            {
                MessageBox.Show("Seçilen doktor için herhangi bir randevu bulunamadı.");
                return;
            }

            // ZedGraph Kontrolü
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();

            // Başlıklar
            pane.Title.Text = $"{selectedDoktor} için Günlük Randevu Sayıları";
            pane.XAxis.Title.Text = "Tarih";
            pane.YAxis.Title.Text = "Randevu Sayısı";

            // Verileri ekle
            PointPairList pointPairList = new PointPairList();
            foreach (DataRow row in randevuSayisi.Rows)
            {
                DateTime randevuTarihi = Convert.ToDateTime(row["RandevuTarihi"]);
                int randevuSayisiValue = Convert.ToInt32(row["RandevuSayisi"]);

                // X ekseni için tarih (OADate formatı), Y ekseni için randevu sayısı
                pointPairList.Add(randevuTarihi.ToOADate(), randevuSayisiValue);
            }

            // Çubuk grafiği oluştur
            BarItem bar = pane.AddBar("Randevu Sayısı", pointPairList, System.Drawing.Color.SkyBlue);

            // X eksenindeki tarihlerin formatı
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.Format = "dd.MM.yyyy";
            pane.XAxis.Scale.FontSpec.Angle = 45; // Açı verilerek okunabilirlik artırılır
            pane.XAxis.Scale.MajorStep = 1; // Her tarih için bir aralık
            pane.XAxis.Scale.MinorStep = 1;

            // Y ekseni otomatik olarak ayarlanır
            pane.YAxis.Scale.Min = 0;

            // Grafik görünümünü yenile
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    

    

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            YoneticiAnaSayfaPL gecis=new YoneticiAnaSayfaPL();
            gecis.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }


