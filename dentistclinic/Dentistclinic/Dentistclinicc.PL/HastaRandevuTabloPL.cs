using Dentistclinicc.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Dentistclinicc.PL
{
    public partial class HastaRandevuTabloPL : Form
    {
        private HastaRandevuTabloBLL _randevuBLL;
        public HastaRandevuTabloPL()
        {
            InitializeComponent();
            _randevuBLL = new HastaRandevuTabloBLL();
        }

        private void HastaRandevuTabloPL_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            try
            {
                DataTable randevuData = _randevuBLL.GetRandevuData();
                dataGridView1.DataSource = randevuData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Veri Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btngiris_Click_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "PDF Dosyasını Kaydet",
                FileName = "RandevuListesi.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    ExportDataGridViewToPdf(dataGridView1, filePath);
                    MessageBox.Show("PDF başarıyla oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportDataGridViewToPdf(DataGridView dataGridView, string filePath)
        {
            if (dataGridView.ColumnCount == 0 || dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("DataGridView'de veri bulunmuyor. Lütfen tabloyu doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PDF belgesini oluştur
            Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Başlık
            Paragraph title = new Paragraph("HASTA RANDEVU LİSTESİ")
            {
                Alignment = Element.ALIGN_CENTER,
                Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18f)
            };
            document.Add(title);

            // Boşluk
            document.Add(new Paragraph("\n")); // Bir satır boşluk ekle

            // DataGridView sütun sayısı kadar tablo oluştur
            PdfPTable table = new PdfPTable(dataGridView.ColumnCount)
            {
                WidthPercentage = 100
            };

            // Sütun başlıklarını ekle
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                table.AddCell(headerCell);
            }

            // Verileri ekle
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string cellText = cell.Value?.ToString() ?? string.Empty;
                        PdfPCell dataCell = new PdfPCell(new Phrase(cellText))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        table.AddCell(dataCell);
                    }
                }
            }

            document.Add(table);
            document.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            YoneticiAnaSayfaPL gecis = new YoneticiAnaSayfaPL();
            gecis.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

