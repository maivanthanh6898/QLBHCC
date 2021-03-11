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
    public partial class frmKhachHang : Form
    {
        private string connString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        private string id, name;
        public frmKhachHang(String name, String id)
        {
            this.id = id;
            this.name = name;
            InitializeComponent();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {

        }
        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void tbFind_Enter(object sender, EventArgs e)
        {
            if (tbFind.Text == "Nhập mã khách hàng...")
            {
                tbFind.Text = "";
                tbFind.ForeColor = Color.Black;
            }
        }

        private void tbFind_Leave(object sender, EventArgs e)
        {
            if (tbFind.Text == "")
            {
                tbFind.Text = "Nhập mã khách hàng...";
                tbFind.ForeColor = Color.Gray;
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            tbFind.Text = "Nhập mã khách hàng...";
            tbFind.ForeColor = Color.Gray;
            radioButton1.Checked = true;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select idKhachHang AS Id,sTenKh as N'Tên khách hàng',sDiaChi as N'Địa chỉ',sGioiTinh AS N'Giới tính', sSDT as SĐT from tbl_khachhang order by Id DESC ";
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.AutoResizeColumns();
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                String gt = radioButton1.Checked ? "Nam" : "Nữ";
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "insert into tbl_khachhang values(N'" + tbTen.Text + "',N'" + tbDc.Text + "','" + gt + "','" + tbSdt.Text + "')";
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                int ire = comm.ExecuteNonQuery();
                if (ire > 0)
                {
                    MessageBox.Show("Lưu thành công");
                    load();
                }
                else
                {
                    MessageBox.Show("Lưu thất bại");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Bạn chưa chọn thông tin khách hàng để sửa");
                return;
            }
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            using (SqlConnection conn = new SqlConnection(connString))
            {
                String gt = radioButton1.Checked ? "Nam" : "Nữ";
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "update tbl_khachhang set sDiaChi = N'" + tbDc.Text + "',sGioiTinh = N'" + gt + "',sSDT = N'" + tbSdt.Text + "',sTenKh = N'" + tbTen.Text + "' WHERE idKhachHang = " + id;
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                int ire = comm.ExecuteNonQuery();
                if (ire > 0)
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

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                tbTen.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tbDc.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                radioButton1.Checked = dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "Nam";
                tbSdt.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            load();
            tbTen.Text = "";
            tbDc.Text = "";
            tbSdt.Text = "";
        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select idKhachHang AS Id,sTenKh as N'Tên khách hàng',sDiaChi as N'Địa chỉ',sGioiTinh AS N'Giới tính', sSDT as SĐT from tbl_khachhang where idKhachHang = " + tbFind.Text + " order by Id DESC ";
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.AutoResizeColumns();
                dataGridView1.DataSource = dt;
            }
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmHoaDon qlhd = new frmHoaDon(id, name, "");
            this.Hide();
            qlhd.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe qlhd = new frmThongKe(name, id);
            qlhd.Show();
            this.Dispose();
        }

        private void quảnLýCâyCảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyCayCanh qlhd = new QuanLyCayCanh(name, id);
            this.Hide();
            qlhd.Show();
        }
    }
}
