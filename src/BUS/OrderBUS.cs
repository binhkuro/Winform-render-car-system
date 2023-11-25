using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class OrderBUS
    {
        OrderDAL orderDAL = new OrderDAL();
        public OrderBUS() { }
        public bool checkout(OrderDTO orderDTO)
        {
            return orderDAL.checkout(orderDTO);
        }

        public DataTable getAllOrder()
        {
            return orderDAL.getAllOrder();
        }

        public bool payment(int id)
        {
            return orderDAL.payment(id);
        }

        public bool hasOrdersCustomer(int customerId)
        {
            return orderDAL.hasOrdersCustomer(customerId);
        }

        public bool hasOrdersCar(int carId)
        {
            return orderDAL.hasOrdersCar(carId);
        }

        public DataTable getOrdersByCarID(int carID)
        {
            return orderDAL.getByCarID(carID);
        }
    }
}
