using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CarReport
    {
        public int carID { get; set; }
        public string carName { get; set; }
        public int quantity { get; set; }
        public decimal totalOrderAmount { get; set; }

        public CarReport()
        {
            carID = 0;
            carName = string.Empty;
            quantity = 0;
            totalOrderAmount = 0;
        }

        public CarReport(int carID, string carName, int quantity, decimal totalOrderAmount)
        {
            carID = carID;
            carName = carName;
            quantity = quantity;
            totalOrderAmount = totalOrderAmount;
        }
    }
}
