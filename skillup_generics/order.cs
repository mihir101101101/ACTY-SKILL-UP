using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
    class order
    {
        private employee emp;
        private customer cust;
        private int or_no;
        private DateTime or_date;
        private string s_name, s_add, s_city, s_sate, s_con;
        private int s_pcode;
        private DateTime c_date, m_date;

        public int OrderNo
        {
            get { return or_no; }
            set { or_no = value; }
        }
        public int ShipPostalCode
        {
            get { return s_pcode; }
            set { s_pcode = value; }
        }
        public string ShipName
        {
            get { return s_name; }
            set { s_name = value; }
        }
        public string ShipAddress
        {
            get { return s_add; }
            set { s_add = value; }
        }
        public string ShipCity
        {
            get { return s_city; }
            set { s_city = value; }
        }
        public string ShipState
        {
            get { return s_sate; }
            set { s_sate = value; }
        }
        public string ShipCountry
        {
            get { return s_con; }
            set { s_con = value; }
        }
        public DateTime OrderDate
        {
            get { return or_date; }
            set { or_date = value; }
        }
        public DateTime CreatedDate
        {
            get { return c_date; }
            set { c_date = value; }
        }
        public DateTime ModifiedDate
        {
            get { return m_date; }
            set { m_date = value; }
        }

        public employee EmployeeDetail
        {
            get { return emp; }
            set { emp = value; }
        }

        public customer CustomerDetail
        {
            get { return cust; }
            set { cust = value; }
        }

    }
}
