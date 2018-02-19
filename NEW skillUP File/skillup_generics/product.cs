using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
   public class product
    {
        private string productNo;
        public string ProductNo
        {
            get { return productNo; }
            set { productNo = value; }
        }
        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        private double unitPrice;
        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public override string ToString()
        {
            return ProductNo.ToString() + "\t\t" + ProductName.ToString() + "\t\t" + UnitPrice.ToString() + "\t\t\t" + IsActive.ToString();
        }
    }
}
