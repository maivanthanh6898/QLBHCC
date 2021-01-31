namespace QLBHCC
{
    partial class QuanLyCayCanh
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnAđ = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbTen = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGiaB = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGiaN = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSl = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.RichTextBox();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.tblBan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(807, 173);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(34, 31);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(172, 20);
            this.tbFind.TabIndex = 1;
            this.tbFind.Enter += new System.EventHandler(this.tbFind_Enter);
            this.tbFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFind_KeyDown);
            this.tbFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFind_KeyPress);
            this.tbFind.Leave += new System.EventHandler(this.tbFind_Leave);
            // 
            // btnAđ
            // 
            this.btnAđ.Location = new System.Drawing.Point(678, 249);
            this.btnAđ.Name = "btnAđ";
            this.btnAđ.Size = new System.Drawing.Size(163, 31);
            this.btnAđ.TabIndex = 2;
            this.btnAđ.Text = "Thêm";
            this.btnAđ.UseVisualStyleBackColor = true;
            this.btnAđ.Click += new System.EventHandler(this.btnAđ_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(678, 291);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(163, 33);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(678, 336);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(163, 36);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(212, 31);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // tbTen
            // 
            this.tbTen.Location = new System.Drawing.Point(116, 260);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(171, 20);
            this.tbTen.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tên cây cảnh: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Loại cây: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Giá bán : ";
            // 
            // tbGiaB
            // 
            this.tbGiaB.Location = new System.Drawing.Point(116, 333);
            this.tbGiaB.Name = "tbGiaB";
            this.tbGiaB.Size = new System.Drawing.Size(171, 20);
            this.tbGiaB.TabIndex = 10;
            this.tbGiaB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGiaB_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Giá nhập: ";
            // 
            // tbGiaN
            // 
            this.tbGiaN.Location = new System.Drawing.Point(116, 369);
            this.tbGiaN.Name = "tbGiaN";
            this.tbGiaN.Size = new System.Drawing.Size(171, 20);
            this.tbGiaN.TabIndex = 12;
            this.tbGiaN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGiaN_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Số lượng;";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tbSl
            // 
            this.tbSl.Location = new System.Drawing.Point(400, 256);
            this.tbSl.Name = "tbSl";
            this.tbSl.Size = new System.Drawing.Size(205, 20);
            this.tbSl.TabIndex = 14;
            this.tbSl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSl_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Mô tả: ";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(400, 295);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(205, 94);
            this.tbDesc.TabIndex = 18;
            this.tbDesc.Text = "";
            // 
            // cbLoai
            // 
            this.cbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(116, 298);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(171, 21);
            this.cbLoai.TabIndex = 19;
            // 
            // tblBan
            // 
            this.tblBan.Location = new System.Drawing.Point(678, 388);
            this.tblBan.Name = "tblBan";
            this.tblBan.Size = new System.Drawing.Size(163, 31);
            this.tblBan.TabIndex = 20;
            this.tblBan.Text = "Bán";
            this.tblBan.UseVisualStyleBackColor = true;
            // 
            // QuanLyCayCanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.tblBan);
            this.Controls.Add(this.cbLoai);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbGiaN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbGiaB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAđ);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "QuanLyCayCanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cây cảnh";
            this.Load += new System.EventHandler(this.QuanLyCayCanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button btnAđ;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.MaskedTextBox tbTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbGiaB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbGiaN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox tbSl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox tbDesc;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.Button tblBan;
    }
}