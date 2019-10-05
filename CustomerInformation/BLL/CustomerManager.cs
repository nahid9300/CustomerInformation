using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInformation.Model;
using CustomerInformation.Repository;

namespace CustomerInformation.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository=new CustomerRepository();
        public bool Insert(Customer customer)
        {
           return _customerRepository.Insert(customer);
        }

        public List<Customer> Display()
        {
            return _customerRepository.Display();
        }

        public DataTable Search(Customer customer)
        {
            return _customerRepository.Search(customer);
        }


        public DataTable ComboDisplay()
        {
            return _customerRepository.ComboDisplay();
        }

        public bool IsNameExists(Customer customer)
        {
            return _customerRepository.IsNameExists(customer);
        }
    }
}
