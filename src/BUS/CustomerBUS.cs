using DAL;
using DAL.Properties;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CustomerBUS
    {
        CustomerDAL customerDAL = new CustomerDAL();

        public DataTable getAll()
        {
            return customerDAL.getAllCustomer();
        }

        public DataTable findCustomerByName(string nameCustomer)
        {
            return customerDAL.findCustomerByName(nameCustomer);
        }

        public DataTable findCustomerByPhone(string phoneCustomer)
        {
            return customerDAL.findCustomerByPhone(phoneCustomer);
        }

        public DataTable findCustomerByAddress(string addressCustomer)
        {
            return customerDAL.findCustomerByAddress(addressCustomer);
        }

        public bool addCustomer(CustomerDTO customerDTO)
        {
            return customerDAL.addCustomer(customerDTO);
        }

        public bool removeCustomer(int idCustomer)
        {
            return customerDAL.removeCustomer(idCustomer);
        }

        public bool updateCustomer(CustomerDTO customerDTO)
        {
            return customerDAL.updateCustomer(customerDTO);
        }
    }
}
