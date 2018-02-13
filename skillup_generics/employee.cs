using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
    class employee
    {
        private int emp_no, emp_p;
        private string emp_fname, emp_lname, emp_add, emp_city, emp_s;

        public int EmployeeNo
        {
            get { return emp_no; }
            set { emp_no = value; }
        }
        public int PostalCode
        {
            get { return emp_p; }
            set { emp_p = value; }
        }
        public string FirstName
        {
            get { return emp_fname; }
            set { emp_fname = value; }
        }
        public string LastName
        {
            get { return emp_lname; }
            set { emp_lname = value; }
        }
        public string Address
        {
            get { return emp_add; }
            set { emp_add = value; }
        }
        public string City
        {
            get { return emp_city; }
            set { emp_city = value; }
        }
        public string State
        {
            get { return emp_s; }
            set { emp_s = value; }
        }

    }
}
