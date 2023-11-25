using BUS;
using DTO;
using Microsoft.Reporting.WinForms;
using NPOI.HPSF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            CarTypeBUS carTypeBUS = new CarTypeBUS();
            OrderBUS orderBUS = new OrderBUS();
            List<CarTypeDTO> listTypeCarDTO = carTypeBUS.getAll();

            List<TypeCarReport> listTypeCar = new List<TypeCarReport>();
            foreach (CarTypeDTO carTypeDTO in listTypeCarDTO)
            {
                TypeCarReport typeCarReport = new TypeCarReport();
                typeCarReport.TypeCarID = carTypeDTO.getTypeCarID();
                typeCarReport.TypeName = carTypeDTO.getTypeName();

                CarBus carBus = new CarBus();
                DataTable carsTable = carBus.getByTypeCarID(carTypeDTO.getTypeCarID());
                int carCount = carsTable.Rows.Count;
                typeCarReport.NumberOfCars = carCount;

                // Tính tổng số tiền đơn hàng của mỗi loại xe
                decimal totalOrderAmountForTypeCar = 0;
                foreach (DataRow carRow in carsTable.Rows)
                {
                    int carID = Convert.ToInt32(carRow["carID"]);
                    DataTable ordersByCarID = orderBUS.getOrdersByCarID(carID);
                    foreach (DataRow orderRow in ordersByCarID.Rows)
                    {
                        totalOrderAmountForTypeCar += Convert.ToDecimal(orderRow["total"]);
                    }
                }
                typeCarReport.TotalOrderAmount = totalOrderAmountForTypeCar;

                listTypeCar.Add(typeCarReport);
            }

            reportViewer1.LocalReport.ReportPath = "Report.rdlc";
            var source = new ReportDataSource("DataSet1", listTypeCar);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);

            reportViewer1.RefreshReport();
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {
            CarBus carBUS = new CarBus();
            OrderBUS orderBUS = new OrderBUS();

            DataTable listCarDTO = carBUS.getAll();

            List<CarReport> listCar = new List<CarReport>();
            foreach (DataRow row in listCarDTO.Rows)
            {
                CarReport carReport = new CarReport();
                carReport.carID = Convert.ToInt32(row["carID"]);
                carReport.carName = row["carName"].ToString();

                DataTable ordersByCarID = orderBUS.getOrdersByCarID(carReport.carID);
                carReport.quantity = ordersByCarID.Rows.Count;

                decimal totalOrderAmount = 0;
                foreach (DataRow orderRow in ordersByCarID.Rows)
                {
                    totalOrderAmount += Convert.ToDecimal(orderRow["total"]);
                }
                carReport.totalOrderAmount = totalOrderAmount;

                listCar.Add(carReport);
            }

            reportViewer2.LocalReport.ReportPath = "Report2.rdlc";
            var source = new ReportDataSource("DataSet1", listCar);
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(source);

            reportViewer2.RefreshReport();
        }


    }
}
