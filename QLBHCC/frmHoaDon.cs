using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBHCC
{
    public partial class frmHoaDon : Form
    {
        private string connString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        private string id, name;
        DataTable dttb = new DataTable();
        double tongtien = 0.0d;
        public frmHoaDon(String id, String name)
        {
            this.id = id;
            this.name = name;
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            DataColumn dc = new DataColumn("Mã cây", typeof(String));
            dttb.Columns.Add(dc);

            dc = new DataColumn("Tên cây", typeof(String));
            dttb.Columns.Add(dc);

            dc = new DataColumn("Số lượng", typeof(String));
            dttb.Columns.Add(dc);

            dc = new DataColumn("Giá bán", typeof(String));
            dttb.Columns.Add(dc);

            dc = new DataColumn("Tổng tiền", typeof(String));
            dttb.Columns.Add(dc);
            load();
        }
        private void load()
        {
            tbTk.Text = "Nhập mã HĐ...";
            tbTk.ForeColor = Color.Gray;
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            tbMaNV.Text = id;
            tbTenNV.Text = name;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from tbl_caycanh";
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        acsc.Add(dr["idCayCanh"].ToString());
                    }
                }
                tbMaCay.AutoCompleteCustomSource = acsc;
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

            //if (dataGridView1.SelectedRows.Count != 0 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            //{
            //    tbTen.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //    tbGiaB.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //    tbGiaN.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //    tbSl.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //    tbDesc.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            //    if (dataGridView1.SelectedRows[0].Cells[7].Value.ToString() == "" || dataGridView1.SelectedRows[0].Cells[7].Value.ToString() == null)
            //    {
            //        pictureBox1.Image = null;
            //    }
            //    else
            //    {
            //        pictureBox1.Image = new Bitmap(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
            //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //    }
            //}
        }

        private void tbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbMaCay_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void tbMaCay_Leave(object sender, EventArgs e)
        {

        }

        private void tbMaCay_TextChanged(object sender, EventArgs e)
        {
            if (tbMaCay.Text == "" || tbMaCay.Text == null)
            {
                tbTenCay.Text = "";
                tbSoLuong.Text = "";
                tbDonGia.Text = "";
                return;
            }
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from tbl_caycanh where idCayCanh = " + tbMaCay.Text;
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tbTenCay.Text = dr["sTenCayCanh"].ToString();
                        tbDonGia.Text = dr["fGiaBan"].ToString();
                    }
                }
                else
                {
                    tbTenCay.Text = "";
                    tbSoLuong.Text = "";
                    tbDonGia.Text = "";
                }
            }
        }

        private void tbTk_Enter(object sender, EventArgs e)
        {

            if (tbTk.Text == "Nhập mã HĐ...")
            {
                tbTk.Text = "";
                tbTk.ForeColor = Color.Black;
            }
        }

        private void tbTk_Leave(object sender, EventArgs e)
        {

            if (tbTk.Text == "")
            {
                tbTk.Text = "Nhập mã HĐ...";
                tbTk.ForeColor = Color.Gray;
            }
        }

        private void tbTk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (tbTk.Text == "Nhập mã HĐ..." || tbTk.Text == "")
                {
                    load();
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand comm = new SqlCommand();
                        comm.CommandText = "select idChiTiet as Id,sTenCayCanh as N'Tên cây',tbl_chitiethoadon.iSoLuong as N'Số lượng',tbl_chitiethoadon.fGiaBan as 'Giá bán',fTongTien as N'Tổng tiền' from tbl_caycanh,tbl_chitiethoadon where tbl_caycanh.idCayCanh = tbl_chitiethoadon.idCayCanh and idHoaDon =" + tbTk.Text;
                        comm.CommandType = CommandType.Text;
                        comm.Connection = conn;
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        if (dt.Rows.Count > 0)
                        {
                            button2.Enabled = true;
                            tbMaHD.Text = tbTk.Text;
                        }
                        else
                        {
                            tbMaHD.Text = "";
                        }
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
                comm.CommandText = "delete from tbl_chitiethoadon where idHoaDon=" + tbMaHD.Text;
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                int ire = comm.ExecuteNonQuery();
                if (ire > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    dttb.Rows.Clear();
                    tongtien = 0.0d;
                    dataGridView1.DataSource = dttb;
                    load();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow toInsert = dttb.NewRow();
            toInsert[1] = tbTenCay.Text;
            toInsert[2] = tbSoLuong.Text;
            toInsert[3] = tbDonGia.Text;
            toInsert[4] = float.Parse(tbSoLuong.Text) * float.Parse(tbDonGia.Text);
            toInsert[0] = tbMaCay.Text;
            dttb.Rows.Add(toInsert);
            tongtien += float.Parse(tbSoLuong.Text) * float.Parse(tbDonGia.Text);
            dataGridView1.DataSource = dttb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dttb.Rows.Clear();
            tongtien = 0.0d;
            dataGridView1.DataSource = dttb;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (tbMaKH.Text == "" || tbMaKH.Text == null || dttb.Rows.Count < 1)
                {
                    button3.Enabled = false;
                }
                Int32 newProdID = 0;
                DateTime today = DateTime.Today;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "SP_CREATEHD";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@IDNV", id);
                comm.Parameters.AddWithValue("@IDKH", tbMaKH.Text);
                comm.Parameters.AddWithValue("@date", today);
                comm.Parameters.AddWithValue("@tt", tongtien);
                newProdID = (Int32)comm.ExecuteScalar();
                if (newProdID != 0)
                {
                    MessageBox.Show("Thêm thành công");
                    load();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }

                for (int i = dataGridView1.Rows.Count - 2; i >= 0; i--)
                {
                    DataRow dr = dttb.Rows[i];
                    comm.CommandText = "SP_INSERTDETAILS";
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Connection = conn;
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@IDHD", newProdID);
                    comm.Parameters.AddWithValue("@IDCC", dr[0].ToString());
                    comm.Parameters.AddWithValue("@SL", int.Parse(dr[2].ToString()));
                    comm.Parameters.AddWithValue("@GIA", float.Parse(dr[3].ToString()));
                    comm.Parameters.AddWithValue("@TONGTIEN", float.Parse(dr[4].ToString()));
                    int ire = comm.ExecuteNonQuery();
                    if (ire < 1)
                    {
                        MessageBox.Show("Thêm thất bại");
                        return;
                    }
                }
            }
        }

        private void quảnLýCâyCảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyCayCanh qlhd = new QuanLyCayCanh(name, id);
            this.Hide();
            qlhd.Show();
        }

        private void tbSDT_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from tbl_khachhang where sSDT = " + tbSDT.Text;
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tbMaKH.Text = dr["idKhachHang"].ToString();
                        tbTenKH.Text = dr["sTenKh"].ToString();
                        tbDc.Text = dr["sDiaChi"].ToString();
                    }
                }
            }
        }
    }
}
