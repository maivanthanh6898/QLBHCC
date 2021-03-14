using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBHCC
{
    public partial class frmThongKe : Form
    {
        private string connString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        private string id, name;
        public frmThongKe(String id, String name)
        {
            InitializeComponent();
            this.id = id;
            this.name = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker1.Value;
            DateTime to = dateTimePicker2.Value;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select h.idHoaDon as Id, k.sTenKh as N'Khách hàng', n.sTenNv as N'Nhân viên', h.dNgayTao as N'Ngày tạo', h.fTongTien as N'Tổng tiền' from tbl_hoadon as h,tbl_khachhang as k,tbl_nhanvien as n where h.idKhachHang = k.idKhachHang and h.idNhanVien = n.idNhanVien" +
                    " and dNgayTao >= '" + from.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) + " 12:00:00 AM'" + " and dNgayTao <= '" + to.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) + " 12:00:00 AM'";
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.AutoResizeColumns();
                dataGridView2.DataSource = dt;
            }
        }

        private void quảnLýCâyCảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyCayCanh hd = new QuanLyCayCanh(name, id);
            hd.Show();
            this.Dispose();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon hd = new frmHoaDon(id, name, "");
            hd.Show();
            this.Dispose();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang hd = new frmKhachHang(name, id);
            hd.Show();
            this.Dispose();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "thongke.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        PdfPTable pdfTable = new PdfPTable(dataGridView2.Columns.Count);
                        pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                        foreach (DataGridViewColumn column in dataGridView2.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            pdfTable.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            if (row.Index != dataGridView2.Rows.Count - 1)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }
                        }
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN
                                                 , 15
                                                 , iTextSharp.text.Font.BOLDITALIC
                                                 , BaseColor.BLACK
                           );
                        Chunk titleChunk = new Chunk("                                                 THONG KE HOA DON\n\n", titleFont);

                        iTextSharp.text.Font space = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                            , 14
                                            , iTextSharp.text.Font.NORMAL
                                            , BaseColor.BLACK
                            );
                        Chunk space1 = new Chunk("\n\n\n", space);
                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 30f, 20f, 20f, 10f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();
                            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph();
                            pdfDoc.Add(titleChunk);
                            pdfDoc.Add(paragraph);
                            pdfDoc.Add(space1);
                            pdfDoc.Add(paragraph);
                            pdfDoc.Add(paragraph);
                            pdfDoc.Add(pdfTable);
                            pdfDoc.Add(paragraph);
                            pdfDoc.Close();
                            stream.Close();
                        }

                        MessageBox.Show("Xuất file thành công !!!", "Info");
                    }
                }
            }
            else
            {
                MessageBox.Show("Thông tin rỗng !!!", "Info");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0 || dataGridView2.SelectedRows[0].Index == dataGridView2.Rows.Count - 1)
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn cần xem");
                return;
            }
            frmHoaDon hd = new frmHoaDon(id, name, dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            hd.Show();
            this.Dispose();
        }
    }
}
