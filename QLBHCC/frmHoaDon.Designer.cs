namespace QLBHCC
{
    partial class frmHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSDT = new System.Windows.Forms.TextBox();
            this.tbDc = new System.Windows.Forms.TextBox();
            this.tbTenKH = new System.Windows.Forms.TextBox();
            this.tbMaKH = new System.Windows.Forms.TextBox();
            this.tbTenNV = new System.Windows.Forms.TextBox();
            this.tbMaNV = new System.Windows.Forms.TextBox();
            this.tbMaHD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbDonGia = new System.Windows.Forms.TextBox();
            this.tbTenCay = new System.Windows.Forms.TextBox();
            this.tbSoLuong = new System.Windows.Forms.TextBox();
            this.tbMaCay = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbTk = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýCâyCảnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa đơn bán hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSDT);
            this.groupBox1.Controls.Add(this.tbDc);
            this.groupBox1.Controls.Add(this.tbTenKH);
            this.groupBox1.Controls.Add(this.tbMaKH);
            this.groupBox1.Controls.Add(this.tbTenNV);
            this.groupBox1.Controls.Add(this.tbMaNV);
            this.groupBox1.Controls.Add(this.tbMaHD);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(27, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 124);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tbSDT
            // 
            this.tbSDT.Location = new System.Drawing.Point(520, 98);
            this.tbSDT.Name = "tbSDT";
            this.tbSDT.Size = new System.Drawing.Size(189, 20);
            this.tbSDT.TabIndex = 13;
            this.tbSDT.TextChanged += new System.EventHandler(this.tbSDT_TextChanged);
            this.tbSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSDT_KeyPress);
            // 
            // tbDc
            // 
            this.tbDc.Enabled = false;
            this.tbDc.Location = new System.Drawing.Point(520, 72);
            this.tbDc.Name = "tbDc";
            this.tbDc.Size = new System.Drawing.Size(189, 20);
            this.tbDc.TabIndex = 12;
            // 
            // tbTenKH
            // 
            this.tbTenKH.Enabled = false;
            this.tbTenKH.Location = new System.Drawing.Point(520, 43);
            this.tbTenKH.Name = "tbTenKH";
            this.tbTenKH.Size = new System.Drawing.Size(189, 20);
            this.tbTenKH.TabIndex = 11;
            // 
            // tbMaKH
            // 
            this.tbMaKH.Enabled = false;
            this.tbMaKH.Location = new System.Drawing.Point(520, 13);
            this.tbMaKH.Name = "tbMaKH";
            this.tbMaKH.Size = new System.Drawing.Size(189, 20);
            this.tbMaKH.TabIndex = 10;
            // 
            // tbTenNV
            // 
            this.tbTenNV.Enabled = false;
            this.tbTenNV.Location = new System.Drawing.Point(102, 71);
            this.tbTenNV.Name = "tbTenNV";
            this.tbTenNV.Size = new System.Drawing.Size(189, 20);
            this.tbTenNV.TabIndex = 9;
            // 
            // tbMaNV
            // 
            this.tbMaNV.Enabled = false;
            this.tbMaNV.Location = new System.Drawing.Point(102, 46);
            this.tbMaNV.Name = "tbMaNV";
            this.tbMaNV.Size = new System.Drawing.Size(189, 20);
            this.tbMaNV.TabIndex = 8;
            // 
            // tbMaHD
            // 
            this.tbMaHD.Enabled = false;
            this.tbMaHD.Location = new System.Drawing.Point(102, 20);
            this.tbMaHD.Name = "tbMaHD";
            this.tbMaHD.Size = new System.Drawing.Size(189, 20);
            this.tbMaHD.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(471, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "SĐT: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(471, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Đ/c:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tên KH:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã KH:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên NV:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã NV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã HĐ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbDonGia);
            this.groupBox2.Controls.Add(this.tbTenCay);
            this.groupBox2.Controls.Add(this.tbSoLuong);
            this.groupBox2.Controls.Add(this.tbMaCay);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(27, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(779, 74);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin mặt hàng";
            // 
            // tbDonGia
            // 
            this.tbDonGia.Enabled = false;
            this.tbDonGia.Location = new System.Drawing.Point(520, 47);
            this.tbDonGia.Name = "tbDonGia";
            this.tbDonGia.Size = new System.Drawing.Size(189, 20);
            this.tbDonGia.TabIndex = 11;
            // 
            // tbTenCay
            // 
            this.tbTenCay.Enabled = false;
            this.tbTenCay.Location = new System.Drawing.Point(520, 17);
            this.tbTenCay.Name = "tbTenCay";
            this.tbTenCay.Size = new System.Drawing.Size(189, 20);
            this.tbTenCay.TabIndex = 10;
            // 
            // tbSoLuong
            // 
            this.tbSoLuong.Location = new System.Drawing.Point(102, 43);
            this.tbSoLuong.Name = "tbSoLuong";
            this.tbSoLuong.Size = new System.Drawing.Size(189, 20);
            this.tbSoLuong.TabIndex = 8;
            // 
            // tbMaCay
            // 
            this.tbMaCay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbMaCay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbMaCay.Location = new System.Drawing.Point(102, 17);
            this.tbMaCay.Name = "tbMaCay";
            this.tbMaCay.Size = new System.Drawing.Size(189, 20);
            this.tbMaCay.TabIndex = 7;
            this.tbMaCay.TextChanged += new System.EventHandler(this.tbMaCay_TextChanged);
            this.tbMaCay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMaCay_KeyPress);
            this.tbMaCay.Leave += new System.EventHandler(this.tbMaCay_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(471, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Đơn giá:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(471, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Tên cây:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Số lượng:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Mã Cây:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 300);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(779, 150);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(139, 467);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Thêm HĐ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbTk
            // 
            this.tbTk.Location = new System.Drawing.Point(93, 274);
            this.tbTk.Name = "tbTk";
            this.tbTk.Size = new System.Drawing.Size(189, 20);
            this.tbTk.TabIndex = 13;
            this.tbTk.Enter += new System.EventHandler(this.tbTk_Enter);
            this.tbTk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTk_KeyPress);
            this.tbTk.Leave += new System.EventHandler(this.tbTk_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tìm kiếm:";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(287, 467);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(432, 467);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Lưu HĐ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 467);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýCâyCảnhToolStripMenuItem,
            this.quảnLýHóaĐơnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(833, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýCâyCảnhToolStripMenuItem
            // 
            this.quảnLýCâyCảnhToolStripMenuItem.Name = "quảnLýCâyCảnhToolStripMenuItem";
            this.quảnLýCâyCảnhToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.quảnLýCâyCảnhToolStripMenuItem.Text = "Quản lý cây cảnh";
            this.quảnLýCâyCảnhToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCâyCảnhToolStripMenuItem_Click);
            // 
            // quảnLýHóaĐơnToolStripMenuItem
            // 
            this.quảnLýHóaĐơnToolStripMenuItem.Name = "quảnLýHóaĐơnToolStripMenuItem";
            this.quảnLýHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.quảnLýHóaĐơnToolStripMenuItem.Text = "Quản lý hóa đơn";
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 502);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbTk);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmHoaDon";
            this.Text = "frmHoaDon";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSDT;
        private System.Windows.Forms.TextBox tbDc;
        private System.Windows.Forms.TextBox tbTenKH;
        private System.Windows.Forms.TextBox tbMaKH;
        private System.Windows.Forms.TextBox tbTenNV;
        private System.Windows.Forms.TextBox tbMaNV;
        private System.Windows.Forms.TextBox tbMaHD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbDonGia;
        private System.Windows.Forms.TextBox tbTenCay;
        private System.Windows.Forms.TextBox tbSoLuong;
        private System.Windows.Forms.TextBox tbMaCay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbTk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýCâyCảnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHóaĐơnToolStripMenuItem;
    }
}