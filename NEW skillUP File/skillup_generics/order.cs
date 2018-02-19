using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{

   

   public class order 
    {
        private employee employee;
        private customer customer;
        private string orderNo;
        private string orderDate;
        private string shipname, shipadd, shipcity, shipstate, shipcountry;
        private int shipcode;
        private DateTime createdDate;
        private DateTime ? modifiedDate;
        

        public string OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }
        public int ShipPostalCode
        {
            get { return shipcode; }
            set { shipcode = value; }
        }
        public string ShipName
        {
            get { return shipname; }
            set { shipname = value; }
        }
        public string ShipAddress
        {
            get { return shipadd; }
            set { shipadd = value; }
        }
        public string ShipCity
        {
            get { return shipcity; }
            set { shipcity = value; }
        }
        public string ShipState
        {
            get { return shipstate; }
            set { shipstate = value; }
        }
        public string ShipCountry
        {
            get { return shipcountry; }
            set { shipcountry = value; }
        }
        public string OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
        public DateTime ? ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }

        public employee EmployeeDetail
        {
            get { return employee; }
            set { employee = value; }
        }

        public customer CustomerDetail
        {
            get { return customer; }
            set { customer = value; }
        }

        public override string ToString()
        {
            return OrderNo + "\t\t" + employee.EmployeeNo + "\t\t" + employee.FirstName + "\t\t" + customer.CustomerNo + "\t\t" + customer.CustomerName + "\t\t" + ShipAddress + "\t\t";
        }


    }
}
