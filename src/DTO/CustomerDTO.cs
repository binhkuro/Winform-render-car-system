using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        private int id;
        private string nameCustomer;
        private string phoneCustomer;
        private string addressCustomer;
        private string gender;

        public CustomerDTO() { }

        public CustomerDTO(int id, string nameCustomer, string phoneCustomer, string addressCustomer, string gender)
        {
            this.id = id;
            this.nameCustomer = nameCustomer;
            this.phoneCustomer = phoneCustomer;
            this.addressCustomer = addressCustomer;
            this.gender = gender;
        }

        public int CustomerId { get => id; set => id = value; }
        public string NameCustomer { get => nameCustomer; set => nameCustomer = value; }
        public string PhoneCustomer { get => phoneCustomer; set => phoneCustomer = value; }
        public string AddressCustomer { get => addressCustomer; set => addressCustomer = value; }
        public string Gender { get => gender; set => gender = value; }
    }
}
