using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace WindowsFormsApp1 {
	public partial class Booking : Form {
		CarTypeBUS CarTypeBUS;
		CarBus carBus;
		OrderBUS orderBus;
		CustomerBUS customerBus;	

        private bool isAuthenticated = false;
		private UserType currentUserType;

        public Booking() {
			InitializeComponent();
		}

        public Booking(UserType userType)
        {
            InitializeComponent();
            currentUserType = userType;
        }

        private void Booking_Load(object sender, EventArgs e) {
			CarTypeBUS = new CarTypeBUS();
			carBus = new CarBus();	
			orderBus = new OrderBUS();	
			comboBox1.DataSource = CarTypeBUS.getAllTypeCar();
			comboBox1.DisplayMember = "typeName";
			comboBox1.ValueMember = "typeCarID";
			customerBus = new CustomerBUS();
            /*DataTable customerDataTable = customerBUS.getAll();
            List<CustomerDTO> customers = new List<CustomerDTO>();
            foreach (DataRow row in customerDataTable.Rows)
            {
				int customerId = Convert.ToInt32(row["id"]);
				string customerName = row["nameCustomer"].ToString();
				string phoneCustomer = row["phoneCustomer"].ToString();
				string addressCustomer = row["addressCustomer"].ToString();
				string gender = row["gender"].ToString();

				CustomerDTO customer = new CustomerDTO(customerId, customerName, phoneCustomer, addressCustomer, gender);
				customers.Add(customer);
            }

            cbTenKhachHang.DataSource = customers;
            cbTenKhachHang.ValueMember = "CustomerId";
*/
            loadCar();
			loadOrder();
		}

		private void loadOrder() {
			dataGridView1.DataSource = orderBus.getAllOrder();
		}

		private void loadCar(int id = -1) {
			DataTable dataTable = new DataTable();
			if(id == -1) {
				dataTable = carBus.getAll();
			} else {
				dataTable = carBus.getByTypeCarID(id);
			}
			flowLayoutPanel1.Controls.Clear();
			foreach (DataRow row in dataTable.Rows) {
				int carID = Convert.ToInt32(row["carID"]);
				string carName = row["carName"].ToString();
				string typeName = row["typeName"].ToString();
				string nhienLieuID = row["nhienLieuID"].ToString();
				Button button = new Button();
				button.Text = "MS" + carID +
					"\n" + typeName + "_" +carName +
					"\n" + nhienLieuID;
				button.Height = 100;
				button.Width = 100;
				if (carBus.findStatusCar(carID)) {
					button.Click += button_Click;
				} else {
					button.BackColor = Color.Red;
				}
				button.Tag = carID;
				flowLayoutPanel1.Controls.Add(button);
				
			}
		}
		private void button_Click(object sender, EventArgs e) {
			Button clickedButton = (Button)sender;
			if(clickedButton.BackColor == Color.Red) {
				MessageBox.Show("Xe đang được cho thuê ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			clickedButton.BackColor = (clickedButton.BackColor != Color.Green) ? Color.Green : Color.White;
			foreach (Control control in flowLayoutPanel1.Controls) {
				if (control is Button otherButton && otherButton != clickedButton && control.BackColor != Color.Red) {
					otherButton.BackColor = Color.White;
				}
			}
		}

		static float price = 0.0f;
		private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e) {
			ComboBox comboBox1 = (ComboBox)sender;
			int id = (int)comboBox1.SelectedValue;
			this.loadCar(id);
			CarTypeDTO carTypeDTO = CarTypeBUS.getCarType(id);

			price = carTypeDTO.Price;
			lbMoney.Text = carTypeDTO.Price.ToString();
			getTotal();
		}
		private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
			getTotal();
		}
		private float getTotal() {
			int day = (int)numericUpDown1.Value;
			lbTotal.Text = (day*price).ToString();	
			return day*price;
		}

		private void btnPayment_Click(object sender, EventArgs e) {
			try {
				OrderDTO orderDTO = new OrderDTO();
				//orderDTO.CustomerId = (int)cbTenKhachHang.SelectedValue;
				orderDTO.RentalTime = DateTime.Now;
				var greenButtons = flowLayoutPanel1.Controls.OfType<Button>().Where(button => button.BackColor == Color.Green).ToList();
				if (greenButtons == null) {
					MessageBox.Show("Vui lòng chọn loại xe thuê ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				Button button1 = (Button)greenButtons[0];
				int CarId = int.Parse(button1.Tag.ToString());
				orderDTO.CarID = CarId;
				orderDTO.Quantity = (int)numericUpDown1.Value;
				orderDTO.RentailTimeLimit = orderDTO.RentalTime.AddDays((int)numericUpDown1.Value);
				orderDTO.Status = false;
				orderDTO.Total = getTotal();

				DataTable dataTable = customerBus.findCustomerByPhone(txtPhone.Text);
				int cusId;
				if (dataTable.Rows.Count > 0) {
					DataRow row = dataTable.Rows[0];
					cusId = int.Parse(row["id"].ToString());
				} else {
					CustomerDTO customerDTO = new CustomerDTO();
					customerDTO.AddressCustomer = txtAddress.Text;
					customerDTO.PhoneCustomer = txtPhone.Text;
					customerDTO.NameCustomer = txtName.Text;
					customerDTO.Gender = "Nam";
					customerBus.addCustomer(customerDTO);
					DataTable dataTable1 = customerBus.findCustomerByPhone(txtPhone.Text);
					DataRow row = dataTable1.Rows[0];
					cusId = int.Parse(row["id"].ToString());
				}
				orderDTO.CustomerId = cusId;
				bool flag = orderBus.checkout(orderDTO);
				if (flag) {
					MessageBox.Show("Order created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					loadOrder();
					loadCar();	
				} else {
					MessageBox.Show("Failed to create the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} catch(Exception ex) {
				
			}
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            isAuthenticated = true;
            Home homeForm = new Home(currentUserType);
            this.Hide();
            homeForm.Show();
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

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
			try {
				string customerName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
				DataTable db = customerBus.findCustomerByName(customerName);
				DataRow dataRow = db.Rows[0];
				txtName.Text = dataRow["nameCustomer"].ToString();
				txtPhone.Text = dataRow["phoneCustomer"].ToString();
				txtAddress.Text = dataRow["addressCustomer"].ToString();
			} catch (Exception ex) {

			}
		}
	}
}
