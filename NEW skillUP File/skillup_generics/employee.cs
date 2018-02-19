using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
    public class employee
    {
        private string employeeNo;
        string employeePostalCode;
        private string employeeFirstName, employeeLastName, employeeAddress, employeeCity, employeeState;

        public string EmployeeNo
        {
            get { return employeeNo; }
            set { employeeNo = value; }
        }
        public string PostalCode
        {
            get { return employeePostalCode; }
            set { employeePostalCode = value; }
        }
        public string FirstName
        {
            get { return employeeFirstName; }
            set { employeeFirstName = value; }
        }
        public string LastName
        {
            get { return employeeLastName; }
            set { employeeLastName = value; }
        }
        public string Address
        {
            get { return employeeAddress; }
            set { employeeAddress = value; }
        }
        public string City
        {
            get { return employeeCity; }
            set { employeeCity = value; }
        }
        public string State
        {
            get { return employeeState; }
            set { employeeState = value; }
        }

        public override string ToString()
        {
            return EmployeeNo + "\t\t" + FirstName + "\t\t" + LastName + "\t\t" + Address + "\t\t"+City+"\t"+State+"\t"+PostalCode;
        }



    }
}
