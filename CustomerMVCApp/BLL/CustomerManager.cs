using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CustomerMVCApp.DAL;
using CustomerMVCApp.Models;

namespace CustomerMVCApp.BLL
{
    public class CustomerManager
    {
        CustomerRepository customerRepository = new CustomerRepository();
        public bool AddCustomer(Customer customer)
        {
            return customerRepository.AddCustomer(customer);
        }
        public bool DeleteCustomer(int code)
        {
            return customerRepository.DeleteCustomer(code);
        }
        public bool UpdateCustomer(Customer customer)
        {
            return customerRepository.UpdateCustomer(customer);
        }
        public DataTable ShowCustomer()
        {
            return customerRepository.ShowCustomer();
        }
    }
}