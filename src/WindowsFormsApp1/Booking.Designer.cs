namespace WindowsFormsApp1 {
	partial class Booking {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lbText = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnPayment = new System.Windows.Forms.Button();
			this.lbMoney = new System.Windows.Forms.Label();
			this.lbTotal = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnDangXuat = new System.Windows.Forms.Button();
			this.btnBack2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtAddress);
			this.groupBox1.Controls.Add(this.txtPhone);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.lbText);
			this.groupBox1.Location = new System.Drawing.Point(723, 99);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(388, 205);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin đặt xe";
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(142, 151);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(160, 20);
			this.txtAddress.TabIndex = 18;
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(142, 101);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(160, 20);
			this.txtPhone.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(58, 154);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "Địa chỉ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(44, 108);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "Số điện thoại";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(37, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Tên khách Hàng";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(142, 45);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(160, 20);
			this.txtName.TabIndex = 12;
			// 
			// lbText
			// 
			this.lbText.AutoSize = true;
			this.lbText.Location = new System.Drawing.Point(190, 229);
			this.lbText.Name = "lbText";
			this.lbText.Size = new System.Drawing.Size(0, 13);
			this.lbText.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(41, 84);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Số ngày đặt";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(159, 77);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
			this.numericUpDown1.TabIndex = 0;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(44, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Loại xe";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(159, 36);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 3;
			this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.flowLayoutPanel1);
			this.groupBox2.Location = new System.Drawing.Point(21, 29);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(696, 275);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Danh sách các xe";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(686, 249);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnBack);
			this.groupBox3.Controls.Add(this.btnPayment);
			this.groupBox3.Controls.Add(this.lbMoney);
			this.groupBox3.Controls.Add(this.lbTotal);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.comboBox1);
			this.groupBox3.Controls.Add(this.numericUpDown1);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Location = new System.Drawing.Point(723, 310);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(388, 312);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Thành tiền";
			// 
			// btnBack
			// 
			this.btnBack.Location = new System.Drawing.Point(58, 223);
			this.btnBack.Margin = new System.Windows.Forms.Padding(2);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(96, 23);
			this.btnBack.TabIndex = 4;
			this.btnBack.Text = "Về trang chủ";
			this.btnBack.UseVisualStyleBackColor = true;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnPayment
			// 
			this.btnPayment.Location = new System.Drawing.Point(159, 223);
			this.btnPayment.Name = "btnPayment";
			this.btnPayment.Size = new System.Drawing.Size(75, 23);
			this.btnPayment.TabIndex = 13;
			this.btnPayment.Text = "Thanh toán";
			this.btnPayment.UseVisualStyleBackColor = true;
			this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
			// 
			// lbMoney
			// 
			this.lbMoney.AutoSize = true;
			this.lbMoney.Location = new System.Drawing.Point(159, 124);
			this.lbMoney.Name = "lbMoney";
			this.lbMoney.Size = new System.Drawing.Size(60, 13);
			this.lbMoney.TabIndex = 12;
			this.lbMoney.Text = "0.000 VNĐ";
			// 
			// lbTotal
			// 
			this.lbTotal.AutoSize = true;
			this.lbTotal.Location = new System.Drawing.Point(159, 166);
			this.lbTotal.Name = "lbTotal";
			this.lbTotal.Size = new System.Drawing.Size(60, 13);
			this.lbTotal.TabIndex = 11;
			this.lbTotal.Text = "0.000 VNĐ";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(37, 166);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(52, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Tổng tiền";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(24, 125);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Giá thuê xe một ngày";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(21, 310);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.Size = new System.Drawing.Size(692, 312);
			this.dataGridView1.TabIndex = 3;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			// 
			// btnDangXuat
			// 
			this.btnDangXuat.Location = new System.Drawing.Point(942, 48);
			this.btnDangXuat.Margin = new System.Windows.Forms.Padding(2);
			this.btnDangXuat.Name = "btnDangXuat";
			this.btnDangXuat.Size = new System.Drawing.Size(96, 23);
			this.btnDangXuat.TabIndex = 5;
			this.btnDangXuat.Text = "Log out";
			this.btnDangXuat.UseVisualStyleBackColor = true;
			this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
			// 
			// btnBack2
			// 
			this.btnBack2.Location = new System.Drawing.Point(842, 48);
			this.btnBack2.Margin = new System.Windows.Forms.Padding(2);
			this.btnBack2.Name = "btnBack2";
			this.btnBack2.Size = new System.Drawing.Size(96, 23);
			this.btnBack2.TabIndex = 6;
			this.btnBack2.Text = "Home";
			this.btnBack2.UseVisualStyleBackColor = true;
			this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
			// 
			// Booking
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1257, 704);
			this.Controls.Add(this.btnBack2);
			this.Controls.Add(this.btnDangXuat);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Booking";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Booking";
			this.Load += new System.EventHandler(this.Booking_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbText;
		private System.Windows.Forms.Label lbTotal;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lbMoney;
		private System.Windows.Forms.Button btnPayment;
		private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnBack2;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
	}
}