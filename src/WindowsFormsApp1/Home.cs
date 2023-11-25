using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Home : Form
    {
        private bool isAuthenticated = false;
        private UserType currentUserType;

        public Home()
        {
            InitializeComponent();
            btnDangXuat.Visible = false;
            lblXinChao.Visible = false;
            lblUser.Visible = false;
        }

        public Home(UserType userType)
        {
            InitializeComponent();

            if (userType == UserType.Admin || userType == UserType.Staff)
            {
                isAuthenticated = true;
                currentUserType = userType;
                btnDangNhap.Visible = false;
                btnDangXuat.Visible = true;
                lblXinChao.Visible = true;
                lblUser.Visible = true;
                lblUser.Text = $"{currentUserType}";
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            if (isAuthenticated == false)
            {
                MessageBox.Show("Please log in to proceed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Customer customerForm = new Customer(currentUserType);
                this.Hide();
                customerForm.Show();
            }
        }

        private void btnQuanLyXe_Click(object sender, EventArgs e)
        {
            if (isAuthenticated == false)
            {
                MessageBox.Show("Please log in to proceed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (currentUserType == UserType.Admin)
            {
                Car carForm = new Car(currentUserType);
                this.Hide();
                carForm.Show();
            }
            else
            {
                MessageBox.Show("You don't have permission to perform this action", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuanLyDonDatHang_Click(object sender, EventArgs e)
        {
            if (isAuthenticated == false)
            {
                MessageBox.Show("Please log in to proceed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Booking bookingForm = new Booking(currentUserType);
                this.Hide();
                bookingForm.Show();
            }
        }

        private void btnQuanLyLichTrinh_Click(object sender, EventArgs e)
        {
            if (isAuthenticated == false)
            {
                MessageBox.Show("Please log in to proceed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Scheme schemeForm = new Scheme(currentUserType);
                this.Hide();
                schemeForm.Show();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            this.Hide();
            homeForm.Show();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (isAuthenticated == false)
            {
                MessageBox.Show("Please log in to proceed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Report report = new Report();
                report.Show();
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

        }
    }
}
