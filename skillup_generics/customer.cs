using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace skillup_generics
{
    public class Customer
    {


        public string CustomerNo
        {
            get;
            set;
        }
        public int PostalCode
        {
            get;
            set;
        }
        public string CustomerName
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }

        public override string ToString()
        {
            return CustomerNo + "\t\t" + CustomerName + "\t\t" + Address + "\t\t" + City + "\t" + State + "\t\t" + PostalCode + "\t\t     "+Country;
        }
    }
}
