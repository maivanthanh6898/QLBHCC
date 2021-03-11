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
    public partial class QuanLyCayCanh : Form
    {
        private string connString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        String id, name;
        DataTable dttb = new DataTable();
        public QuanLyCayCanh(string username, string id)
        {
            InitializeComponent();
            this.id = id;
            this.name = username;
        }

        private void QuanLyCayCanh_Load(object sender, EventArgs e)
        {
            load();
            tbFind.Text = "Nhập tên cây cần tìm...";
            tbFind.ForeColor = Color.Gray;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "select * from tbl_loaicay";
                    comm.CommandType = CommandType.Text;
                    comm.Connection = conn;
                    cbLoai.DisplayMember = "Text";
                    cbLoai.ValueMember = "Value";
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cbLoai.Items.Add(new { Value = dr["idLoaiCay"].ToString(), Text = dr["sTenLoai"].ToString() });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void load()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select idCayCanh as Id, sTenCayCanh as N'Tên cây',tbl_loaicay.idLoaiCay as N'Tên loại', fGiaBan as N'Giá bán', fGiaNhap as N'Giá nhập', iSoLuong as N'Số lượng', sMoTa as N'Mô tả', sAnh as 'Anh'  from tbl_caycanh, tbl_loaicay where tbl_caycanh.iLoaiCay = tbl_loaicay.idLoaiCay order by Id DESC ";
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.AutoResizeColumns();
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[7].Visible = false;
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbGiaB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbGiaN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbSl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbFind_Enter(object sender, EventArgs e)
        {
            if (tbFind.Text == "Nhập tên cây cần tìm...")
            {
                tbFind.Text = "";
                tbFind.ForeColor = Color.Black;
            }
        }

        private void tbFind_Leave(object sender, EventArgs e)
        {
            if (tbFind.Text == "")
            {
                tbFind.Text = "Nhập tên cây cần tìm...";
                tbFind.ForeColor = Color.Gray;
            }
        }

        private void btnAđ_Click(object sender, EventArgs e)
        {
            if (!checkAdd())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        if (!File.Exists(path + "\\image\\" + filename))
                        {
                            System.IO.File.Copy(openFileDialog1.FileName, path + "\\image\\" + filename);
                        }
                        if (filename == null)
                        {
                            MessageBox.Show("Please select a valid image.");
                        }
                        conn.Open();
                        SqlCommand comm = new SqlCommand();
                        comm.CommandText = "SP_addCay";
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@tencc", tbTen.Text);
                        comm.Parameters.AddWithValue("@iLoaiCay", cbLoai.SelectedItem.GetType().GetProperty("Value").GetValue(cbLoai.SelectedItem, null).ToString());
                        comm.Parameters.AddWithValue("@fGiaBan", tbGiaB.Text);
                        comm.Parameters.AddWithValue("@fGiaNhap", tbGiaN.Text);
                        comm.Parameters.AddWithValue("@iSoLuong", tbSl.Text);
                        comm.Parameters.AddWithValue("@sMoTa", tbDesc.Text);
                        comm.Parameters.AddWithValue("@sAnh", path + "\\image\\" + filename);
                        int ire = comm.ExecuteNonQuery();
                        if (ire >= 1)
                        {
                            MessageBox.Show("Thêm thành công");
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("UNIQUE"))
                    {
                        MessageBox.Show("Tên cây cảnh đã tồn tại, vui lòng thử lại!");
                        return;
                    }
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Thông tin chưa đầy đủ, kiểm tra lại!");
            }
        }

        private bool checkAdd()
        {
            return tbTen.Text == "" || tbTen.Text == null
                || tbGiaB.Text == "" || tbGiaB.Text == null || tbGiaB.Text == "0"
                || tbGiaN.Text == "" || tbGiaN.Text == null || tbGiaN.Text == "0"
                || tbSl.Text == "" || tbSl.Text == null || tbSl.Text == "0" ||
                 cbLoai.SelectedItem == null;

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "delete from tbl_caycanh where idCayCanh = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    comm.CommandType = CommandType.Text;
                    comm.Connection = conn;
                    int ire = comm.ExecuteNonQuery();
                    if (ire >= 1)
                    {
                        MessageBox.Show("Xóa thành công");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!checkAdd())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        if (!File.Exists(path + "\\image\\" + filename))
                        {
                            System.IO.File.Copy(openFileDialog1.FileName, path + "\\image\\" + filename);
                        }
                        if (filename == null)
                        {
                            MessageBox.Show("Please select a valid image.");
                        }
                        conn.Open();
                        SqlCommand comm = new SqlCommand();
                        comm.CommandText = "SP_fixCay";
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@tencc", tbTen.Text);
                        comm.Parameters.AddWithValue("@iLoaiCay", cbLoai.SelectedItem.GetType().GetProperty("Value").GetValue(cbLoai.SelectedItem, null).ToString());
                        comm.Parameters.AddWithValue("@fGiaBan", tbGiaB.Text);
                        comm.Parameters.AddWithValue("@fGiaNhap", tbGiaN.Text);
                        comm.Parameters.AddWithValue("@iSoLuong", tbSl.Text);
                        comm.Parameters.AddWithValue("@sMoTa", tbDesc.Text);
                        comm.Parameters.AddWithValue("@anh", path + "\\image\\" + filename);
                        comm.Parameters.AddWithValue("@id", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
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
                catch (Exception ex)
                {
                    if (ex.Message.Contains("UNIQUE"))
                    {
                        MessageBox.Show("Tên cây cảnh đã tồn tại, vui lòng thử lại!");
                        return;
                    }
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Thông tin chưa đầy đủ, kiểm tra lại!");
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                foreach (var item in cbLoai.Items)
                {
                    if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString()
                        == item.GetType().GetProperty("Value").GetValue(item, null).ToString())
                    {
                        cbLoai.SelectedItem = item;
                        break;
                    }
                }
                tbTen.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tbGiaB.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                tbGiaN.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                tbSl.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                tbDesc.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells[7].Value.ToString() == "" || dataGridView1.SelectedRows[0].Cells[7].Value.ToString() == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    pictureBox1.Image = new Bitmap(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (tbFind.Text == "Nhập tên cây cần tìm..." || tbFind.Text == "")
                {
                    load();
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand comm = new SqlCommand();
                        comm.CommandText = "select idCayCanh as Id, sTenCayCanh as N'Tên cây',tbl_loaicay.idLoaiCay as N'Tên loại', fGiaBan as N'Giá bán', fGiaNhap as N'Giá nhập', iSoLuong as N'Số lượng', sMoTa as N'Mô tả', sAnh as 'Anh'  from tbl_caycanh, tbl_loaicay where tbl_caycanh.iLoaiCay = tbl_loaicay.idLoaiCay and sTenCayCanh like '%" + tbFind.Text + "%'";
                        comm.CommandType = CommandType.Text;
                        comm.Connection = conn;
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void tblBan_Click(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (tbFind.Text == "Nhập tên cây cần tìm..." || tbFind.Text == "")
            {
                load();
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "select idCayCanh as Id, sTenCayCanh as N'Tên cây',tbl_loaicay.idLoaiCay as N'Tên loại', fGiaBan as N'Giá bán', fGiaNhap as N'Giá nhập', iSoLuong as N'Số lượng', sMoTa as N'Mô tả', sAnh as 'Anh'  from tbl_caycanh, tbl_loaicay where tbl_caycanh.iLoaiCay = tbl_loaicay.idLoaiCay and sTenCayCanh like '%" + tbFind.Text + "%'";
                    comm.CommandType = CommandType.Text;
                    comm.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void quaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon qlhd = new frmHoaDon(id, name);
            this.Hide();
            qlhd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select image to be upload.";
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
