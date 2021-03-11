namespace QLBHCC
{
    partial class frmKhachHang
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
            this.btnFind = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTen = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDc = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSdt = new System.Windows.Forms.MaskedTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýCâyCảnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(765, 183);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(201, 41);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click_1);
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(23, 41);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(172, 20);
            this.tbFind.TabIndex = 6;
            this.tbFind.Enter += new System.EventHandler(this.tbFind_Enter);
            this.tbFind.Leave += new System.EventHandler(this.tbFind_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên KH:";
            // 
            // tbTen
            // 
            this.tbTen.Location = new System.Drawing.Point(145, 269);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(171, 20);
            this.tbTen.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Địa chỉ:";
            // 
            // tbDc
            // 
            this.tbDc.Location = new System.Drawing.Point(510, 269);
            this.tbDc.Name = "tbDc";
            this.tbDc.Size = new System.Drawing.Size(171, 20);
            this.tbDc.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Giới tính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "SĐT:";
            // 
            // tbSdt
            // 
            this.tbSdt.Location = new System.Drawing.Point(510, 310);
            this.tbSdt.Name = "tbSdt";
            this.tbSdt.Size = new System.Drawing.Size(171, 20);
            this.tbSdt.TabIndex = 14;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(145, 313);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 17);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Nam";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton2.Location = new System.Drawing.Point(231, 313);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 17);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Nữ";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(201, 371);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(337, 371);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýCâyCảnhToolStripMenuItem,
            this.quảnLýHóaĐơnToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 21;
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
            this.quảnLýHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHóaĐơnToolStripMenuItem_Click_1);
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý khách hàng";
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            this.thốngKêToolStripMenuItem.Click += new System.EventHandler(this.thốngKêToolStripMenuItem_Click);
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSdt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmKhachHang";
            this.Text = "frmKhachHang";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tbTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbDc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbSdt;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýCâyCảnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
    }
}