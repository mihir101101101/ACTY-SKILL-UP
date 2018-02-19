using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace skillup_generics
{
    public class customer
    {
        private string customerNo;
        private int postalCode;
        private string name, address, city, state, country;

        public string CustomerNo
        {
            get { return customerNo; }
            set { customerNo = value; }
        }
        public int PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }
        public string CustomerName
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public override string ToString()
        {
            return CustomerNo + "\t\t" + CustomerName + "\t\t" + Address + "\t\t" + City + "\t" + State + "\t\t" + PostalCode + "\t\t     "+Country;
        }
    }
}
