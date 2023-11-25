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
    public partial class Login : Form
    {
        private List<User> userList;
        public event Action OnLoginSuccess;

        public Login()
        {
            InitializeComponent();

            txtMatKhau.UseSystemPasswordChar = true;

            userList = new List<User>
            {
                new User("admin", "admin", UserType.Admin),
                new User("staff1", "staff1", UserType.Staff),
                new User("staff2", "staff2", UserType.Staff),
                new User("staff3", "staff3", UserType.Staff)
            };
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = txtMatKhau.Text;
            User authenticatedUser = AuthenticateUser(username, password);
            if (authenticatedUser != null)
            {
                Home homeForm = new Home(authenticatedUser.UserType);
                this.Hide();
                homeForm.Show();
            }
            else
            {
                Home homeForm = new Home();
                this.Hide();
                homeForm.Show();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = decryptPassword(txtMatKhau.Text);

            User authenticatedUser = AuthenticateUser(username, password);

            if (authenticatedUser != null)
            {
                OnLoginSuccess?.Invoke();
                Home homeForm = new Home(authenticatedUser.UserType);
                homeForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private User AuthenticateUser(string username, string password)
        {
            return userList.FirstOrDefault(user => user.Username == username && decryptPassword(user.Password) == password);
        }

        private string decryptPassword(string cipher)
        {
            string plain = "";

            for (int i = 0; i < cipher.Length; i++)
                plain += Convert.ToChar(cipher[i] - 1);

            return plain;
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
