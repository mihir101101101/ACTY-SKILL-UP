using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
    public class Orderdetails 
    {
        public int Quantity
        {
            get;
            set;
        }
        public double Amount
        {
            get;
            set;
        }
        public double UnitPrice
        {
            get;
            set;
        }
        public double GrandTotal
        {
            get;
            set;
        }
        public double DiscountAmount
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public Product ProductDetail
        {
            get;
            set;
        }
        public string OrderNO
        {
            get;
            set;
        }
        public override string ToString()
        {
            return ProductDetail.ProductNo + "\t\t" + ProductDetail.ProductName + "\t\t" + UnitPrice + "\t\t" + Quantity + "\t\t" + Amount + "\t\t" + DiscountAmount + "\t\t" + GrandTotal + "\n";
        }
    }
}
