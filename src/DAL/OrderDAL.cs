using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDAL
    {
        SqlCommand command;
        public OrderDAL() { }
        public bool checkout(OrderDTO orderDTO)
        {
            string sql = "INSERT INTO [dbo].[MyOrder] ([customerId],[carID],[rentalTime] , [RentalDay] ,[RentailTimeLimit] , [Status]  ,[total]) VALUES  ( @a , @c , @d , @e  , @f , @g  , @h ) ";
            return Connection.actionQuery(sql, new object[] {
                orderDTO.CustomerId,
                orderDTO.CarID,
                orderDTO.RentalTime,
                orderDTO.Quantity,
                orderDTO.RentailTimeLimit,
                (orderDTO.Status == true ? 1  : 0 ),
                orderDTO.Total
            });
        }

        public DataTable getAllOrder()
        {
            string sql = "SELECT TOP (1000)MyOrder.[id]\r\n      ,[nameCustomer]\r\n      ,[carID]\r\n      ,[RentalTime]\r\n      ,[RentalDay]\r\n      ,[RentailTimeLimit]\r\n      ,[total],\r\n\t  Status = (CASE WHEN status = 0 THEN N'Đang chờ thanh toán' ELSE 'Đã thanh toán' END)\r\n  FROM [midterm].[dbo].[MyOrder]\r\n\tJOIN Customer ON Customer.id = MyOrder.customerId";
            return Connection.selectQuery(sql);
        }

        public bool payment(int id)
        {
            string sql = "update myorder set status =  1  where  id = @id ";
            return Connection.actionQuery(sql, new object[] { id });
        }

        public bool hasOrdersCustomer(int customerId)
        {
            string sql = "SELECT COUNT(*) FROM [dbo].[MyOrder] WHERE [CustomerId] = @customerId";
            DataTable result = Connection.selectQuery(sql, new object[] { customerId });
            int count = Convert.ToInt32(result.Rows[0][0]);
            return count > 0;
        }

        public bool hasOrdersCar(int carId)
        {
            string sql = "SELECT COUNT(*) FROM [dbo].[MyOrder] WHERE [CarId] = @carId";
            DataTable result = Connection.selectQuery(sql, new object[] { carId });
            int count = Convert.ToInt32(result.Rows[0][0]);
            return count > 0;
        }

        public DataTable getByCarID(int CarID)
        {
            string sql = "SELECT o.iD, o.customerId, c.carId, o.rentalTime, o.total " +
                         "FROM [myorder] o " +
                         "INNER JOIN car c ON c.CarID = o.carId " +
                         "WHERE c.CarID = @CarID";
            return Connection.selectQuery(sql, new object[] { CarID });
        }
    }
}
