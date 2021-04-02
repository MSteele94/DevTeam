using KomodoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceRepository
{
    class CustomerRepository
    {

        int count = 0;


        protected readonly List<Customer> _customerList = new List<Customer>()
        {

        };


        public bool AddContentToCustomers(Customer content)
        {
            count++;
            content.CustomerID = count;
            _customerList.Add(content);


            return true;
        }
    }
}
