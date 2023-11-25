namespace WindowsFormsApp1
{
    partial class Home
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
			this.Tittle = new System.Windows.Forms.Label();
			this.btnQuanLyXe = new System.Windows.Forms.Button();
			this.btnQuanLyLichTrinh = new System.Windows.Forms.Button();
			this.btnQuanLyKhachHang = new System.Windows.Forms.Button();
			this.btnQuanLyDonDatHang = new System.Windows.Forms.Button();
			this.btnDangNhap = new System.Windows.Forms.Button();
			this.btnDangXuat = new System.Windows.Forms.Button();
			this.lblXinChao = new System.Windows.Forms.Label();
			this.lblUser = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Tittle
			// 
			this.Tittle.AutoSize = true;
			this.Tittle.Font = new System.Drawing.Font("Microsoft YaHei UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Tittle.Location = new System.Drawing.Point(84, 37);
			this.Tittle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Tittle.Name = "Tittle";
			this.Tittle.Size = new System.Drawing.Size(328, 52);
			this.Tittle.TabIndex = 1;
			this.Tittle.Text = "Quản lý thuê xe";
			// 
			// btnQuanLyXe
			// 
			this.btnQuanLyXe.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.btnQuanLyXe.Font = new System.Drawing.Font("Franklin Gothic Medium", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnQuanLyXe.Location = new System.Drawing.Point(58, 117);
			this.btnQuanLyXe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnQuanLyXe.Name = "btnQuanLyXe";
			this.btnQuanLyXe.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnQuanLyXe.Size = new System.Drawing.Size(161, 37);
			this.btnQuanLyXe.TabIndex = 2;
			this.btnQuanLyXe.Text = "XE";
			this.btnQuanLyXe.UseVisualStyleBackColor = false;
			this.btnQuanLyXe.Click += new System.EventHandler(this.btnQuanLyXe_Click);
			// 
			// btnQuanLyLichTrinh
			// 
			this.btnQuanLyLichTrinh.BackColor = System.Drawing.Color.HotPink;
			this.btnQuanLyLichTrinh.Font = new System.Drawing.Font("Franklin Gothic Medium", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnQuanLyLichTrinh.Location = new System.Drawing.Point(247, 117);
			this.btnQuanLyLichTrinh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnQuanLyLichTrinh.Name = "btnQuanLyLichTrinh";
			this.btnQuanLyLichTrinh.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnQuanLyLichTrinh.Size = new System.Drawing.Size(161, 37);
			this.btnQuanLyLichTrinh.TabIndex = 3;
			this.btnQuanLyLichTrinh.Text = "LỊCH TRÌNH";
			this.btnQuanLyLichTrinh.UseVisualStyleBackColor = false;
			this.btnQuanLyLichTrinh.Click += new System.EventHandler(this.btnQuanLyLichTrinh_Click);
			// 
			// btnQuanLyKhachHang
			// 
			this.btnQuanLyKhachHang.BackColor = System.Drawing.Color.MediumSlateBlue;
			this.btnQuanLyKhachHang.Font = new System.Drawing.Font("Franklin Gothic Medium", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnQuanLyKhachHang.Location = new System.Drawing.Point(58, 180);
			this.btnQuanLyKhachHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnQuanLyKhachHang.Name = "btnQuanLyKhachHang";
			this.btnQuanLyKhachHang.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnQuanLyKhachHang.Size = new System.Drawing.Size(161, 37);
			this.btnQuanLyKhachHang.TabIndex = 5;
			this.btnQuanLyKhachHang.Text = "KHÁCH HÀNG";
			this.btnQuanLyKhachHang.UseVisualStyleBackColor = false;
			this.btnQuanLyKhachHang.Click += new System.EventHandler(this.btnQuanLyKhachHang_Click);
			// 
			// btnQuanLyDonDatHang
			// 
			this.btnQuanLyDonDatHang.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnQuanLyDonDatHang.Font = new System.Drawing.Font("Franklin Gothic Medium", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnQuanLyDonDatHang.Location = new System.Drawing.Point(247, 180);
			this.btnQuanLyDonDatHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnQuanLyDonDatHang.Name = "btnQuanLyDonDatHang";
			this.btnQuanLyDonDatHang.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnQuanLyDonDatHang.Size = new System.Drawing.Size(161, 37);
			this.btnQuanLyDonDatHang.TabIndex = 6;
			this.btnQuanLyDonDatHang.Text = "ĐƠN ĐẶT HÀNG";
			this.btnQuanLyDonDatHang.UseVisualStyleBackColor = false;
			this.btnQuanLyDonDatHang.Click += new System.EventHandler(this.btnQuanLyDonDatHang_Click);
			// 
			// btnDangNhap
			// 
			this.btnDangNhap.BackColor = System.Drawing.Color.MistyRose;
			this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnDangNhap.Location = new System.Drawing.Point(165, 250);
			this.btnDangNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnDangNhap.Name = "btnDangNhap";
			this.btnDangNhap.Size = new System.Drawing.Size(130, 32);
			this.btnDangNhap.TabIndex = 8;
			this.btnDangNhap.Text = "Đăng nhập";
			this.btnDangNhap.UseVisualStyleBackColor = false;
			this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
			// 
			// btnDangXuat
			// 
			this.btnDangXuat.BackColor = System.Drawing.Color.MistyRose;
			this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnDangXuat.Location = new System.Drawing.Point(165, 275);
			this.btnDangXuat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnDangXuat.Name = "btnDangXuat";
			this.btnDangXuat.Size = new System.Drawing.Size(130, 32);
			this.btnDangXuat.TabIndex = 9;
			this.btnDangXuat.Text = "Đăng xuất";
			this.btnDangXuat.UseVisualStyleBackColor = false;
			this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
			// 
			// lblXinChao
			// 
			this.lblXinChao.AutoSize = true;
			this.lblXinChao.Location = new System.Drawing.Point(183, 250);
			this.lblXinChao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblXinChao.Name = "lblXinChao";
			this.lblXinChao.Size = new System.Drawing.Size(49, 13);
			this.lblXinChao.TabIndex = 10;
			this.lblXinChao.Text = "Xin chào";
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.ForeColor = System.Drawing.Color.Red;
			this.lblUser.Location = new System.Drawing.Point(231, 250);
			this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(62, 13);
			this.lblUser.TabIndex = 11;
			this.lblUser.Text = "Người dùng";
			// 
			// Home
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SkyBlue;
			this.ClientSize = new System.Drawing.Size(466, 322);
			this.Controls.Add(this.lblUser);
			this.Controls.Add(this.lblXinChao);
			this.Controls.Add(this.btnDangXuat);
			this.Controls.Add(this.btnDangNhap);
			this.Controls.Add(this.btnQuanLyDonDatHang);
			this.Controls.Add(this.btnQuanLyKhachHang);
			this.Controls.Add(this.btnQuanLyLichTrinh);
			this.Controls.Add(this.btnQuanLyXe);
			this.Controls.Add(this.Tittle);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Home";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Home";
			this.Load += new System.EventHandler(this.Home_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Tittle;
        private System.Windows.Forms.Button btnQuanLyXe;
        private System.Windows.Forms.Button btnQuanLyLichTrinh;
        private System.Windows.Forms.Button btnQuanLyKhachHang;
        private System.Windows.Forms.Button btnQuanLyDonDatHang;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnBaoCao;
    }
}