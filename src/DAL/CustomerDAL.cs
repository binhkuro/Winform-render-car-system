using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Properties
{
    public class CustomerDAL
    {
        SqlCommand command;
        public DataTable getAllCustomer()
        {
            string sql = "select id, nameCustomer, phoneCustomer, addressCustomer, gender from customer\r\n ";
            return Connection.selectQuery(sql);
        }

        public DataTable findCustomerByName(string nameCustomer)
        {
            string sql = "select id, nameCustomer, phoneCustomer, addressCustomer, gender from customer where [nameCustomer] = @NameCustomer";
            return Connection.selectQuery(sql, new object[] { nameCustomer });
        }

        public DataTable findCustomerByPhone(string phoneCustomer)
        {
            string sql = "SELECT id, nameCustomer, phoneCustomer, addressCustomer, gender FROM customer WHERE [phoneCustomer] LIKE '%' + @PhoneCustomer + '%'";
            return Connection.selectQuery(sql, new object[] { phoneCustomer });
        }

        public DataTable findCustomerByAddress(string addressCustomer)
        {
            string sql = "select id, nameCustomer, phoneCustomer, addressCustomer, gender from customer where [addressCustomer] = @AddressCustomer";
            return Connection.selectQuery(sql, new object[] { addressCustomer });
        }

        public bool addCustomer(CustomerDTO customer)
        {
            string nameCustomer = customer.NameCustomer;
            string phoneCustomer = customer.PhoneCustomer;
            string addressCustomer = customer.AddressCustomer;
            string gender = customer.Gender;

            if (phoneExists(phoneCustomer))
            {
                return false;
            }

            String sql = "insert into customer(nameCustomer  , phoneCustomer , addressCustomer, gender ) values ( @a , @b , @c , @d ) ";
            return Connection.actionQuery(sql, new object[] { nameCustomer, phoneCustomer, addressCustomer, gender });
        }

        public bool removeCustomer(int idCustomer)
        {
            string sql = "delete from customer where id = @id ";
            return Connection.actionQuery(sql, new object[] { idCustomer });
        }

        public bool updateCustomer(CustomerDTO customerDTO)
        {
            if (phoneExists(customerDTO.PhoneCustomer, customerDTO.CustomerId))
            {
                return false;
            }

            string sql = "" +
                "UPDATE [dbo].[Customer]\r\n   " +
                "SET [nameCustomer] = @a \r\n ,[phoneCustomer] = @b \r\n ,[addressCustomer] = @c \r\n ,[gender] = @d " +
                "WHERE [id] = @e \r\n";

            return Connection.actionQuery(sql, new object[] {
                customerDTO.NameCustomer,
                customerDTO.PhoneCustomer,
                customerDTO.AddressCustomer,
                customerDTO.Gender,
                customerDTO.CustomerId
            });
        }

        private bool phoneExists(string phone, int customerId)
        {
            string sql = "select count(*) from customer where phoneCustomer = @phone and id <> @customerId";
            DataTable result = Connection.selectQuery(sql, new object[] { phone, customerId });
            int count = Convert.ToInt32(result.Rows[0][0]);
            return count > 0;
        }

        private bool phoneExists(string phone)
        {
            string sql = "select count(*) from customer where phoneCustomer = @phone";
            DataTable result = Connection.selectQuery(sql, new object[] { phone });
            int count = Convert.ToInt32(result.Rows[0][0]);
            return count > 0;
        }
    }
}
