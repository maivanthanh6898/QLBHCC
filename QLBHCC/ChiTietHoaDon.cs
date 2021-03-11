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
        }
    }
}
