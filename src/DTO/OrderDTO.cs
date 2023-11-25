using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {

        private int iD;
        private int customerId;
        private int carId;
        private DateTime rentalTime;
        private int quantity;
        private bool status;
        private DateTime rentailTimeLimit;
        private float total;

        // Constructor
        public OrderDTO(int iD, int customerId, int carId, DateTime rentalTime, int quantity, bool status, DateTime rentailTimeLimit, float total)
        {
            this.iD = iD;
            this.customerId = customerId;
            this.carId = carId;
            this.RentalTime = rentalTime; // Using the setter
            this.quantity = quantity;
            this.status = status;
            this.rentailTimeLimit = rentailTimeLimit;
            this.total = total;
        }

        public OrderDTO() { }

        // Getter and Setter for iD
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public float Total
        {
            get { return total; }
            set { total = value; }
        }

        // Getter and Setter for customerId
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        // Getter and Setter for carId
        public int CarID
        {
            get { return carId; }
            set { carId = value; }
        }

        // Getter and Setter for rentalTime
        public DateTime RentalTime
        {
            get { return rentalTime; }
            set
            {
                // You can add validation or other logic here if needed
                rentalTime = value;
            }
        }
        public DateTime RentailTimeLimit
        {
            get { return rentailTimeLimit; }
            set
            {
                // You can add validation or other logic here if needed
                rentailTimeLimit = value;
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
