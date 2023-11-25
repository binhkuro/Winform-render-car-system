using BUS;
using DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Customer : Form
    {
        CustomerBUS customerBUS;
        OrderBUS orderBUS;
        private bool isAuthenticated = false;
        private UserType currentUserType;
        int d = 0;

        public Customer()
        {
            InitializeComponent();
        }

        public Customer(UserType userType)
        {
            InitializeComponent();
            currentUserType = userType;
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            customerBUS = new CustomerBUS();
            orderBUS = new OrderBUS();
            loadDataGridView();
        }

        private void loadDataGridView()
        {
            dataGridView1.DataSource = customerBUS.getAll();
            dataGridView1.ReadOnly = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int IdCustomer = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                txtNameCustomer.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPhoneCustomer.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtAddressCustomer.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string gender = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                rdbNam.Checked = (gender == "Nam");
                rdbNu.Checked = (gender == "Nữ");
            } catch (Exception ex) {
			    MessageBox.Show("Error exception" + ex.Message);
		    }
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            isAuthenticated = true;
            Home homeForm = new Home(currentUserType);
            this.Hide();
            homeForm.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            this.Hide();
            homeForm.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNameCustomer.Text = "";
            txtPhoneCustomer.Text = "";
            txtAddressCustomer.Text = "";
            txtTimKiem.Text = "";
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            rdbTen.Checked = false;
            rdbSDT.Checked = false;
            rdbDiaChi.Checked = false;
        }

        private void btnTimKIem_Click(object sender, EventArgs e)
        {
            string searchQuery = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchQuery))
            {
                loadDataGridView();
                return;
            }

            if (rdbTen.Checked)
            {
                DataTable resultByName = customerBUS.findCustomerByName(searchQuery);
                if (resultByName.Rows.Count > 0)
                {
                    dataGridView1.DataSource = resultByName;
                    return;
                }
            }
            else if (rdbSDT.Checked)
            {
                DataTable resultByPhone = customerBUS.findCustomerByPhone(searchQuery);
                if (resultByPhone.Rows.Count > 0)
                {
                    dataGridView1.DataSource = resultByPhone;
                    return;
                }
            }
            else if (rdbDiaChi.Checked)
            {
                DataTable resultByAddress = customerBUS.findCustomerByAddress(searchQuery);
                if (resultByAddress.Rows.Count > 0)
                {
                    dataGridView1.DataSource = resultByAddress;
                    return;
                }
            }

            MessageBox.Show("No matching information found or you have not selected search criteria.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void refesh()
        {
            txtNameCustomer.Text = "";
            txtPhoneCustomer.Text = "";
            txtAddressCustomer.Text = "";
            txtTimKiem.Text = "";
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            rdbTen.Checked = false;
            rdbSDT.Checked = false;
            rdbDiaChi.Checked = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            refesh();
            d = 1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            d = 2;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtNameCustomer.Text))
                {
                    MessageBox.Show("Choice 1 item to delete?");
                    return;
                }

                if (currentUserType == UserType.Staff)
                {
                    MessageBox.Show("You don't have permission to perform this action", "Delete Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idCustomer = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                if (orderBUS.hasOrdersCustomer(idCustomer))
                {
                    MessageBox.Show("Unable to delete customer with associated orders.", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Confirm delete " + txtNameCustomer.Text, "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool flag = customerBUS.removeCustomer(idCustomer);
                    if (!flag)
                    {
                        throw new Exception("Delete fail");
                    }
                    else
                    {
                        MessageBox.Show("Customer deleted successfully", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameCustomer.Text;
                string phone = txtPhoneCustomer.Text;
                string address = txtAddressCustomer.Text;
                string gender = (rdbNam.Checked) ? "Nam" : (rdbNu.Checked) ? "Nữ" : "";
                bool validation = valid(name, phone, address, gender);
                if (validation == false)
                {
                    return;
                }
                CustomerDTO customerDTO = new CustomerDTO();
                customerDTO.NameCustomer = name;
                customerDTO.PhoneCustomer = phone;
                customerDTO.AddressCustomer = address;
                customerDTO.Gender = gender;

                if (d == 1)
                {
                    if (customerBUS.addCustomer(customerDTO))
                    {
                        MessageBox.Show("Customer added successfully", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);                    }
                    else
                    {
                        MessageBox.Show("Add customer failed. Phone number already exists or other error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (d == 2)
                {
                    int idCustomer = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    customerDTO.CustomerId = idCustomer;
                    if (customerBUS.updateCustomer(customerDTO))
                    {
                        MessageBox.Show("Customer updated successfully", "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Add customer failed. Phone number already exists or other error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                loadDataGridView();
            } catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
        }

        private Boolean valid(string nameCustomer, string phoneCustomer, string addressCustomer, string gender)
        {
            if (string.IsNullOrWhiteSpace(nameCustomer))
            {
                MessageBox.Show("Please enter a valid name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(phoneCustomer))
            {
                MessageBox.Show("Please enter a phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(phoneCustomer, out _) || phoneCustomer.Length != 10)
            {
                MessageBox.Show("Please enter a valid 10-digit numeric phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(addressCustomer))
            {
                MessageBox.Show("Please enter a address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(gender))
            {
                MessageBox.Show("Please select gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage excel = new ExcelPackage();
                var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
                workSheet.DefaultRowHeight = 12;
                workSheet.Cells[1, 1].Value = "No.";
                workSheet.Cells[1, 2].Value = "Customer Name";
                workSheet.Cells[1, 3].Value = "Phone Number";
                workSheet.Cells[1, 4].Value = "Address";
                workSheet.Cells[1, 5].Value = "Gender";
                int recordIndex = 2;
                workSheet.Row(1).Height = 25;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;

                DataTable customersDataTable = customerBUS.getAll();
                foreach (DataRow row in customersDataTable.Rows)
                {
                    workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                    workSheet.Cells[recordIndex, 2].Value = row["NameCustomer"].ToString();
                    workSheet.Cells[recordIndex, 3].Value = row["PhoneCustomer"].ToString();
                    workSheet.Cells[recordIndex, 4].Value = row["AddressCustomer"].ToString();
                    workSheet.Cells[recordIndex, 5].Value = row["Gender"].ToString();
                    recordIndex++;
                }

                workSheet.Column(1).AutoFit();
                workSheet.Column(2).AutoFit();
                workSheet.Column(3).AutoFit();
                workSheet.Column(4).AutoFit();
                workSheet.Column(5).AutoFit();

                string sourceDirectory = Path.GetDirectoryName(Application.StartupPath);

                string p_strPath = Path.Combine(sourceDirectory, "Customer_List.xlsx");

                if (!Directory.Exists(sourceDirectory))
                {
                    Directory.CreateDirectory(sourceDirectory);
                }

                File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
                excel.Dispose();

                MessageBox.Show($"File created successfully.\nLocation: {p_strPath}", "File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error creating the file. The file might be in use by another process.\nDetails: {ex.Message}", "File Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
