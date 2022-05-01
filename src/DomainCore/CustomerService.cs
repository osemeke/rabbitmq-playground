using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    public class CustomerService
    {
        Random random = new Random();

        public Customer GetNewCustomer()
        {
            //return new Customer
            //{
            //    Id = "1",
            //    Name = "",
            //    BookingReference = "MUHAMMAD ABDULLATEEF WAZIRI"
            //};

            return GetCustomers().OrderBy(x => Guid.NewGuid()).FirstOrDefault();

        }



        public List<Customer> GetCustomers()
        {
            return (new CustomerRepository()).GetAll();
        }
    }
}
