using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
   public class Product
    {
       public string ProductNo
       {
           get;
           set;
       }

       public string ProductName
       {
           get;
           set;
       }

       public double UnitPrice
       {
           get;
           set;
       }

       public bool IsActive
       {
           get;
           set;
       }

        public override string ToString()
        {
            return ProductNo.ToString() + "\t\t" + ProductName.ToString() + "\t\t" + UnitPrice.ToString() + "\t\t\t" + IsActive.ToString();
        }
    }
}
