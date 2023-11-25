using BUS;
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
using System.Xml.Linq;

namespace WindowsFormsApp1 {
	public partial class Scheme : Form {
		FeatureBUS FeatureBUS;
		CarTypeBUS CarTypeBUS;
		CarBus carBus;
		OrderBUS OrderBUS;
        private bool isAuthenticated = false;
        private UserType currentUserType;

        public Scheme() {
			InitializeComponent();
		}

        public Scheme(UserType userType)
        {
            InitializeComponent();
            currentUserType = userType;
        }

        private void Scheme_Load(object sender, EventArgs e) {
			FeatureBUS = new FeatureBUS();
			CarTypeBUS = new CarTypeBUS();
			carBus = new CarBus();
			OrderBUS = new OrderBUS();	
			LoadOrder();
			loadCar();
		}
		private void LoadOrder() {
			dataGridView1.DataSource = OrderBUS.getAllOrder();
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
			string status = dataGridView1.CurrentRow.Cells[dataGridView1.Columns.Count - 1].Value.ToString().Trim();	
			if (status.Equals("Ðã thanh toán"))
            {
				MessageBox.Show("Order Paymented", "Info", MessageBoxButtons.YesNo);
				return;

			}

            if (MessageBox.Show("Confirm Payment" , "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes){
				int id =int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
				bool flag = OrderBUS.payment(id);
				if (flag) {
                    MessageBox.Show("Payment successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCar();
					LoadOrder();
				} else {
                    MessageBox.Show("Payment failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
		}
		private void loadCar() {
			flowLayoutPanel1.Controls.Clear();	
			DataTable cars = carBus.getAll(); 
			foreach (DataRow row in cars.Rows) {
				Button button1 = new Button();
				button1.Height = 100;
				button1.Width = 100;
				button1.Text = row["carName"].ToString() + "\n" + row["typeName"].ToString() + "\n" + row["carID"].ToString();
				int id = int.Parse(row["carID"].ToString());
				if (carBus.findStatusCar(id)) {
					button1.BackColor = Color.White;
					button1.Text = button1.Text + "\nEmpty";
				} else {
					button1.BackColor = Color.Red ;
					button1.Text = button1.Text + "\n Currently renting";
				}
				flowLayoutPanel1.Controls.Add(button1);
			}
			flowLayoutPanel1.WrapContents = true;
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
    }
}
