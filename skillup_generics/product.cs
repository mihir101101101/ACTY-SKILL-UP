using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
    class product
    {
        private int productno;
        public int ProductNo
        {
            get { return productno; }
            set { productno = value; }
        }
        private string productname;
        public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }
        private double unitprice;
        public double UnitPrice
        {
            get { return unitprice; }
            set { unitprice = value; }
        }
        private bool isactive;
        public bool IsActive
        {
            get { return isactive; }
            set { isactive = value; }
        }

        public override string ToString()
        {
            return ProductNo.ToString() + "\t\t" + ProductName.ToString() + "\t\t" + UnitPrice.ToString() + "\t\t\t" + IsActive.ToString();
        }
    }
}
