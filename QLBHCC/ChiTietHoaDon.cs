using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace QLBHCC
{
    public partial class ChiTietHoaDon : Form
    {
        String id;
        private string connString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        private float gia = 0;
        public ChiTietHoaDon(String id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select idChiTiet as Id,tbl_chitiethoadon.idCayCanh as N'Mã cây',sTenCayCanh as N'Tên cây', tbl_chitiethoadon.iSoluong as N'Số lượng', tbl_chitiethoadon.fGiaBan as N'Giá', tbl_chitiethoadon.fTongTien as N'Tổng Tiền' from tbl_caycanh,tbl_chitiethoadon WHERE tbl_chitiethoadon.idCayCanh = tbl_caycanh.idCayCanh ";
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.AutoResizeColumns();
                dataGridView1.DataSource = dt;
            }
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from tbl_CayCanh";
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                cbLoai.DisplayMember = "Text";
                cbLoai.ValueMember = "Value";
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbLoai.Items.Add(dr["idCayCanh"].ToString());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from tbl_CayCanh where idCayCanh = '" + cbLoai.Text + "'";
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                cbLoai.DisplayMember = "Text";
                cbLoai.ValueMember = "Value";
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox1.Text = dr["sTenCayCanh"].ToString();
                        gia = int.Parse(dr["fGiaBan"].ToString());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "sp_fixdetails";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@i", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                comm.Parameters.AddWithValue("@id", cbLoai.Text);
                comm.Parameters.AddWithValue("@sl", textBox2.Text);
                comm.Parameters.AddWithValue("@gia", gia);
                int ire = comm.ExecuteNonQuery();
                if (ire >= 1)
                {
                    MessageBox.Show("Sửa thành công");
                    load();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String ma = "";
            String kh = "";
            String nv = "";
            String date = "";
            String tongtien = "";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select h.idHoaDon as Id, k.sTenKh as N'Khách hàng', n.sTenNv as N'Nhân viên', h.dNgayTao as N'Ngày tạo', h.fTongTien as N'Tổng tiền' from tbl_hoadon as h,tbl_khachhang as k,tbl_nhanvien as n where h.idKhachHang = k.idKhachHang and h.idNhanVien = n.idNhanVien and h.idHoaDon = " + id;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;
            cbLoai.DisplayMember = "Text";
            cbLoai.ValueMember = "Value";
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ma = dr["Id"].ToString();
                    kh = dr["Khách hàng"].ToString();
                    nv = dr["Nhân viên"].ToString();
                    date = dr["Ngày tạo"].ToString();
                    tongtien = dr["Tổng tiền"].ToString();
                }
            }

            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
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
                        PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                        pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            pdfTable.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable.AddCell(cell.Value.ToString());
                            }
                        }
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                 , 15
                                                 , iTextSharp.text.Font.BOLDITALIC
                                                 , BaseColor.BLACK
                           );
                        Chunk titleChunk = new Chunk("                                                 Hoa don thanh toan", titleFont);

                        iTextSharp.text.Font id = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                 , 14
                                                 , iTextSharp.text.Font.NORMAL
                                                 , BaseColor.BLACK
                           );
                        Chunk titleChunk1 = new Chunk("Ma HD: " + ma, id);

                        iTextSharp.text.Font kh1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                 , 14
                                                 , iTextSharp.text.Font.NORMAL
                                                 , BaseColor.BLACK
                           );
                        Chunk titleChunk3 = new Chunk("Ten Khach Hang: " + kh, kh1);
                        iTextSharp.text.Font nv1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                 , 14
                                                 , iTextSharp.text.Font.NORMAL
                                                 , BaseColor.BLACK
                           );
                        Chunk titleChunk4 = new Chunk("Ten nhan vien: " + nv, nv1);
                        iTextSharp.text.Font date1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                 , 14
                                                 , iTextSharp.text.Font.NORMAL
                                                 , BaseColor.BLACK
                           );
                        Chunk titleChunk5 = new Chunk("Ngay Lap: " + date, date1);
                        iTextSharp.text.Font space = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                 , 14
                                                 , iTextSharp.text.Font.NORMAL
                                                 , BaseColor.BLACK
                           );
                        Chunk space1 = new Chunk("\n\n\n", space);
                        iTextSharp.text.Font space2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                 , 14
                                                 , iTextSharp.text.Font.NORMAL
                                                 , BaseColor.BLACK
                           );
                        Chunk space3 = new Chunk("\n", space2);
                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 30f, 20f, 20f, 10f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();
                            Paragraph paragraph = new Paragraph();
                            pdfDoc.Add(titleChunk);
                            pdfDoc.Add(paragraph);
                            paragraph = new Paragraph();
                            pdfDoc.Add(space1);
                            pdfDoc.Add(paragraph);
                            pdfDoc.Add(titleChunk1);
                            paragraph = new Paragraph();
                            pdfDoc.Add(space3);
                            pdfDoc.Add(paragraph);
                            paragraph = new Paragraph();
                            pdfDoc.Add(paragraph);
                            paragraph = new Paragraph();
                            pdfDoc.Add(space3);
                            pdfDoc.Add(paragraph);
                            pdfDoc.Add(titleChunk3);
                            paragraph = new Paragraph();
                            pdfDoc.Add(paragraph);
                            paragraph = new Paragraph();
                            pdfDoc.Add(space3);
                            pdfDoc.Add(paragraph);
                            pdfDoc.Add(titleChunk4);
                            paragraph = new Paragraph();
                            pdfDoc.Add(paragraph);
                            paragraph = new Paragraph();
                            pdfDoc.Add(space3);
                            pdfDoc.Add(paragraph);
                            pdfDoc.Add(titleChunk5);
                            paragraph = new Paragraph();
                            pdfDoc.Add(paragraph);
                            paragraph = new Paragraph();
                            pdfDoc.Add(paragraph);
                            paragraph = new Paragraph();
                            paragraph = new Paragraph();
                            pdfDoc.Add(space1);
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
    }
}
