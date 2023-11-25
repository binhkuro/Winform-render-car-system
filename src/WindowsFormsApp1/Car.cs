using BUS;
using DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace WindowsFormsApp1 {
	public partial class Car : Form {
		FeatureBUS FeatureBUS;
		CarTypeBUS CarTypeBUS;
        OrderBUS orderBUS;
        CarBus carBus;
        private bool isAuthenticated = false;
        private UserType currentUserType;

        public Car() {
			InitializeComponent();
		}

        public Car(UserType userType)
        {
            InitializeComponent();
            currentUserType = userType;
        }

        private void Form1_Load(object sender, EventArgs e) {
			FeatureBUS = new FeatureBUS();
			CarTypeBUS = new CarTypeBUS();
			carBus = new CarBus();
            orderBUS = new OrderBUS();
            LoadFeature();
			LoadTypeCar();
		}

		private void LoadFeature() {
			List<FeatureDTO> featureDTOs = FeatureBUS.getAll();
			foreach (FeatureDTO featureDTO in featureDTOs) {
				ListViewItem listViewItem = new ListViewItem() { Text = featureDTO.getNameFeature().ToString() };
				listViewItem.SubItems.Add(featureDTO.getId().ToString());
				listView1.Items.Add(listViewItem);
			}
		}

		private void loadDataGridView() {
			dataGridView1.DataSource = carBus.getAll();
			dataGridView1.ReadOnly = true;
		}

		private void LoadTypeCar() {
			List<CarTypeDTO> carTypeDTOs = CarTypeBUS.getAll();
			List<Button> buttons = new List<Button>();
			foreach (CarTypeDTO carTypeDTO in carTypeDTOs) {
				Button button1 = new Button();
				button1.Height = 100;
				button1.Width = 100;
				button1.Text = carTypeDTO.getTypeName();
				button1.Tag = carTypeDTO.getTypeCarID();

				button1.Click += new EventHandler(Button_Click);

				flowLayoutPanel1.Controls.Add(button1);
			}
			flowLayoutPanel1.WrapContents = true;

			comboBox3.DataSource = CarTypeBUS.getAllTypeCar();
			comboBox3.DisplayMember = "typeName";
			comboBox3.ValueMember = "typeCarID";

			loadDataGridView();
		}
		private void Button_Click(object sender, EventArgs e) {
			Button clickedButton = sender as Button;
			if (clickedButton != null) {
				int typeCarID = int.Parse(clickedButton.Tag.ToString());
				DataTable dataTable = carBus.getByTypeCarID(typeCarID);
				dataGridView1.DataSource = dataTable;
				dataGridView1.ReadOnly = true;
			}
		}
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
			try {

				lbIdCar.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
				txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
				string typeCar = dataGridView1.CurrentRow.Cells[2].Value.ToString();
				string nhienlieu = dataGridView1.CurrentRow.Cells[3].Value.ToString();

				CarTypeBUS = new CarTypeBUS();
				int count = 0;
				List<CarTypeDTO> CarTypeDTO = CarTypeBUS.getAll();
				for (int i = 0; i < CarTypeDTO.Count; i++) {
					if (typeCar.Trim().StartsWith(CarTypeDTO[i].getTypeName().ToString().Trim())) {
						comboBox3.SelectedIndex = i;
						break;
					}
				}

				List<FeatureDTO> featureDTOs = carBus.getAllCar(int.Parse(lbIdCar.Text));
				foreach (ListViewItem item in listView1.Items) {
					item.Checked = false;
				}
				foreach (ListViewItem item in listView1.Items) {
					string featureName = item.SubItems[0].Text;
					foreach (FeatureDTO feature in featureDTOs) {
						if (featureName.Equals(feature.getNameFeature())) {
							item.Checked = true;
							break;
						}
					}
				}

				foreach (RadioButton item in groupBox3.Controls) {
					if (item.Text.Equals(nhienlieu.ToString())) {
						item.Checked = true;
						break;
					}
				}
			} catch (Exception ex) {
				MessageBox.Show("Error exception" + ex.Message);
			}
		}
		void refesh() {
			lbIdCar.Text = "";
			txtName.Clear();
			foreach (ListViewItem item in listView1.Items) {
				item.Checked = false;
			}
			foreach (RadioButton item in groupBox3.Controls) {
				item.Checked = false;
			}
		}

		int d = 0;
		private void btnAdd_Click(object sender, EventArgs e) {
			refesh();
			txtName.Focus();
			d = 1;
		}
		private void btnUpdate_Click(object sender, EventArgs e) {
			d = 2;
		}

		private void btnSave_Click(object sender, EventArgs e) {
			try {
				string name = txtName.Text;
				int typeCarId = (int)comboBox3.SelectedValue;

				List<int> FeatureDTO = new List<int>();
				if (listView1.CheckedItems.Count > 0) {
					foreach (ListViewItem selectedItem in listView1.CheckedItems) {
						string id = selectedItem.SubItems[1].Text;
						FeatureDTO.Add(int.Parse(id));
					}
				}

				string nhienlieu = "";
				foreach (RadioButton item in groupBox3.Controls) {
					if (item.Checked) {
						nhienlieu = item.Text;
						break;
					}
				}

				bool validation = valid(name, typeCarId, FeatureDTO, nhienlieu);
				if (validation == false) {
					return;
				}

				CarDTO carDTO = new CarDTO();
				carDTO.NhienLieuID = nhienlieu;
				carDTO.CarName = name;
				carDTO.TypeCarID = typeCarId;
				if (d == 1) {
					if (carBus.addCar(carDTO)) {
						int id = carBus.findCarByName(carDTO.CarName);
						foreach (int item in FeatureDTO) {
							bool succ = carBus.addCarFeature(id, item);
							if (succ == false) {
								throw new Exception("Errror");
							}
						}
                        MessageBox.Show("Car added successfully.", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
						throw new Exception("Add car fail");
					}
				} else if (d == 2) {
					carDTO.CarID = int.Parse(lbIdCar.Text);
					if (carBus.updateCar(carDTO)) {
						int id = carBus.findCarByName(carDTO.CarName);
						carBus.deleteCarFeature(id);
						foreach (int item in FeatureDTO) {
							bool succ = carBus.addCarFeature(id, item);
							if (succ == false) {
								throw new Exception("Errror");
							}
						}
                        MessageBox.Show("Car updated successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
						throw new Exception("Update fail");
					}
				}
				loadDataGridView();
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			try {
				if (String.IsNullOrEmpty(txtName.Text)) {
                    MessageBox.Show("Please select an item to delete.", "Delete Item Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
				}
                int idCar = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                if (orderBUS.hasOrdersCar(idCar))
                {
                    MessageBox.Show("Unable to delete car with associated orders.", "Delete Car Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Confirm delete " + txtName.Text, "Confirm ", MessageBoxButtons.YesNo) == DialogResult.Yes) {
					bool flag = carBus.removeCar(int.Parse(lbIdCar.Text));
					if (flag == false) {
						throw new Exception("Delete Fail");
					} else {
                        MessageBox.Show("Car deleted successfully", "Delete Car", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataGridView();
					}
				}
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private Boolean valid(string name, int typeCarId, List<int> FeatureDTO, string nhienlieu) {
			if (string.IsNullOrWhiteSpace(name)) {
				MessageBox.Show("Please enter a valid name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (!int.TryParse(comboBox3.SelectedValue.ToString(), out typeCarId) || typeCarId <= 0) {
				MessageBox.Show("Please select a valid car type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (listView1.CheckedItems.Count == 0) {
				MessageBox.Show("Please select at least one feature.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (string.IsNullOrWhiteSpace(nhienlieu)) {
				MessageBox.Show("Please select a fuel type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;

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

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            lbIdCar.Text = "";
            txtName.Text = "";
            comboBox3.SelectedIndex = -1;

            foreach (RadioButton item in groupBox3.Controls)
            {
                item.Checked = false;
            }

            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = false;
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    using (var package = new ExcelPackage(new FileInfo(filePath)))
                    {
                        var worksheet = package.Workbook.Worksheets[0];

                        DataTable dt = new DataTable();

                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            dt.Columns.Add(worksheet.Cells[1, col].Text);
                        }

                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                        {
                            DataRow newRow = dt.Rows.Add();
                            for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                            {
                                newRow[worksheet.Cells[1, col].Text] = worksheet.Cells[row, col].Text;
                            }

                            string carName = newRow["carName"].ToString();
                            int typeCarId = int.Parse(newRow["typeCarID"].ToString());
                            string nhienlieuId = newRow["nhienLieuID"].ToString();

                            CarDTO carDTO = new CarDTO
                            {
                                CarName = carName,
                                TypeCarID = typeCarId,
                                NhienLieuID = nhienlieuId,
                            };

							carBus.addCar(carDTO);
                        }

                        loadDataGridView();
                        MessageBox.Show("Data imported successfully.", "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing data: {ex.Message}", "Import Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}