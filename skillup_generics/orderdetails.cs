using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
    class orderdetails
    {
        private product pro;
        private int ref_or_no;
        private int quan;
        private double amount, u_price, gt, dis;
        private DateTime c_date, m_date;

        public int Ref_no
        {
            get { return ref_or_no; }
            set { ref_or_no = value; }
        }
        public int Quantity
        {
            get { return quan; }
            set { quan = value; }
        }
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public double UnitPrice
        {
            get { return u_price; }
            set { u_price = value; }
        }
        public double GrandTotal
        {
            get { return gt; }
            set { gt = value; }
        }
        public double DiscountAmount
        {
            get { return dis; }
            set { dis = value; }
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

        public product ProductDetail
        {
            get { return pro; }
            set { pro = value; }
        }

    }
}
