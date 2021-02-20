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
using System.Windows.Input;

namespace QLBHCC
{
    public partial class QuanLyHoaDon : Form
    {
        private string connString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        String id;
        public QuanLyHoaDon(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void load()
        {
            tbFind.Text = "Nhập mã hóa đơn cần tìm...";
            tbFind.ForeColor = Color.Gray;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select idCayCanh as Id, sTenCayCanh as N'Tên cây',iLoaiCay as N'Loại cây', fGiaBan as N'Giá bán', fGiaNhap as N'Giá nhập', iSoLuong as N'Số lượng', sMoTa as N'Mô tả'  from tbl_caycanh";
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
                comm.CommandText = "select h.idHoaDon as Id, k.sTenKh as N'Khách hàng', n.sTenNv as N'Nhân viên', h.dNgayTao as N'Ngày tạo', h.fTongTien as N'Tổng tiền' from tbl_hoadon as h,tbl_khachhang as k,tbl_nhanvien as n where h.idKhachHang = k.idKhachHang and h.idNhanVien = n.idNhanVien";
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.AutoResizeColumns();
                dataGridView2.DataSource = dt;
            }
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "select * from tbl_khachhang";
                    comm.CommandType = CommandType.Text;
                    comm.Connection = conn;
                    cbLoai.DisplayMember = "Text";
                    cbLoai.ValueMember = "Value";
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cbLoai.Items.Add(dr["idKhachHang"].ToString());
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                ListViewItem item = new ListViewItem((dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "----" + textBox1.Text));
                item.SubItems.Add(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                item.SubItems.Add(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                item.SubItems.Add(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                listView1.Items.Add(item);
            }
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            cbLoai.Items.Clear();
            load();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                Int32 newProdID = 0;
                DateTime today = DateTime.Today;
                conn.Open();
                float tt = 0;
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    string[] subs = listView1.Items[i].Text.Split(new string[] { "----" }, StringSplitOptions.None);
                    tt += float.Parse(listView1.Items[i].SubItems[3].Text) * float.Parse(subs[1]);
                }
                if (cbLoai.Text == null || cbLoai.Text == "")
                {
                    MessageBox.Show("Chưa chọn mã khách hàng");
                    return;
                }
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "SP_CREATEHD";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@IDNV", id);
                comm.Parameters.AddWithValue("@IDKH", cbLoai.Text);
                comm.Parameters.AddWithValue("@date", today);
                comm.Parameters.AddWithValue("@tt", tt);
                newProdID = (Int32)comm.ExecuteScalar();
                if (newProdID != 0)
                {
                    MessageBox.Show("Thêm thành công");

                    cbLoai.Items.Clear();
                    load();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }

                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    string[] subs = listView1.Items[i].Text.Split(new string[] { "----" }, StringSplitOptions.None);
                    comm.CommandText = "SP_INSERTDETAILS";
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Connection = conn;
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@IDHD", newProdID);
                    comm.Parameters.AddWithValue("@IDCC", int.Parse(listView1.Items[i].SubItems[1].Text));
                    comm.Parameters.AddWithValue("@SL", int.Parse(subs[1]));
                    comm.Parameters.AddWithValue("@GIA", float.Parse(listView1.Items[i].SubItems[3].Text));
                    comm.Parameters.AddWithValue("@TONGTIEN", float.Parse(listView1.Items[i].SubItems[3].Text) * float.Parse(subs[1]));
                    int ire = comm.ExecuteNonQuery();
                    if (ire < 1)
                    {
                        MessageBox.Show("Thêm thất bại");
                        return;
                    }
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (tbFind.Text == "Nhập mã hóa đơn cần tìm..." || tbFind.Text == "")
            {
                cbLoai.Items.Clear();
                load();
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "select h.idHoaDon as Id, k.sTenKh as N'Khách hàng', n.sTenNv as N'Nhân viên', h.dNgayTao as N'Ngày tạo', h.fTongTien as N'Tổng tiền' from tbl_hoadon as h,tbl_khachhang as k,tbl_nhanvien as n where h.idKhachHang = k.idKhachHang and h.idNhanVien = n.idNhanVien and h.idHoaDon =" + tbFind.Text;
                    comm.CommandType = CommandType.Text;
                    comm.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
        }

        private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (tbFind.Text == "Nhập tên cây cần tìm..." || tbFind.Text == "")
                {

                    cbLoai.Items.Clear();
                    load();
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand comm = new SqlCommand();
                        comm.CommandText = "select h.idHoaDon as Id, k.sTenKh as N'Khách hàng', n.sTenNv as N'Nhân viên', h.dNgayTao as N'Ngày tạo', h.fTongTien as N'Tổng tiền' from tbl_hoadon as h,tbl_khachhang as k,tbl_nhanvien as n where h.idKhachHang = k.idKhachHang and h.idNhanVien = n.idNhanVien and h.idHoaDon =" + tbFind.Text;
                        comm.CommandType = CommandType.Text;
                        comm.Connection = conn;
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
            }
        }

        private void tbFind_Leave(object sender, EventArgs e)
        {
            if (tbFind.Text == "")
            {
                tbFind.Text = "Nhập mã hóa đơn cần tìm...";
                tbFind.ForeColor = Color.Gray;
            }
        }

        private void tbFind_Enter(object sender, EventArgs e)
        {
            if (tbFind.Text == "Nhập mã hóa đơn cần tìm...")
            {
                tbFind.Text = "";
                tbFind.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count != 0 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                ChiTietHoaDon hoaDon = new ChiTietHoaDon(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                hoaDon.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idkh;
            ThongKe testDialog = new ThongKe();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                float from = float.Parse(testDialog.getFrom() == "" || testDialog.getFrom() == null ? "0" : testDialog.getFrom());
                float to = float.Parse(testDialog.getTo() == "" || testDialog.getTo() == null ? "9999999999999" : testDialog.getTo());
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "select h.idHoaDon as Id, k.sTenKh as N'Khách hàng', n.sTenNv as N'Nhân viên', h.dNgayTao as N'Ngày tạo', h.fTongTien as N'Tổng tiền' from tbl_hoadon as h,tbl_khachhang as k,tbl_nhanvien as n"
                        + " where h.idKhachHang = k.idKhachHang and h.idNhanVien = n.idNhanVien and h.fTongTien >= " + to + " and h.fTongTien <= " + from;
                    if (testDialog.getKh() != "" && testDialog.getKh() != null)
                    {
                        comm.CommandText += " and h.idKhachHang = " + int.Parse(testDialog.getKh());
                    };
                    comm.CommandType = CommandType.Text;
                    comm.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            testDialog.Dispose();
        }
    }
}
