using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace QLBHCC
{
    public partial class LoginForm : Form
    {
        private string connString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandText = "SP_Login";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@username", tbUsername.Text);
                comm.Parameters.AddWithValue("@password", tbPassword.Text);
                var reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    String id = "";
                    String name = "";
                    while (reader.Read())
                    {
                        id = reader["idNhanVien"].ToString();
                        name = reader["sTenNv"].ToString();
                    };
                    this.Hide();
                    QuanLyCayCanh qlcc = new QuanLyCayCanh(name, id);
                    qlcc.Show();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác hoặc không tồn tại, vui lòng kiểm tra lại thông tin", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbUsername.Focus();
                }
            }
        }
    }
}
