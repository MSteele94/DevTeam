using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepository
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string LastName { get; set; }
        public int CustomerAge { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int NumberOfYearsUsingKomodo { get; set; }

        public Customer(){}
        public Customer(string lastName, int customerAge, DateTime enrollmentDate, int numberOfYearsUsingKomodo)
        {
            LastName = lastName;
            CustomerAge = customerAge;
            EnrollmentDate = enrollmentDate;
            NumberOfYearsUsingKomodo = numberOfYearsUsingKomodo;
        }
    }
}
