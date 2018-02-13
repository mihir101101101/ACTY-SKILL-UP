using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
    class customer
    {
        private int c_no, c_pcode;
        private string c_name, c_add, c_city, c_state, c_con;

        public int CustomerNo
        {
            get { return c_no; }
            set { c_no = value; }
        }
        public int PostalCode
        {
            get { return c_pcode; }
            set { c_pcode = value; }
        }
        public string CustomerName
        {
            get { return c_name; }
            set { c_name = value; }
        }
        public string Address
        {
            get { return c_add; }
            set { c_add = value; }
        }
        public string City
        {
            get { return c_city; }
            set { c_city = value; }
        }
        public string State
        {
            get { return c_state; }
            set { c_state = value; }
        }
        public string Country
        {
            get { return c_con; }
            set { c_con = value; }
        }

    }
}
