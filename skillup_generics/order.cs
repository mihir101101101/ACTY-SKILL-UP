using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{

   public class Order 
    {
       Employee employee=null;
       Customer customer=null;
       List<Orderdetails> orderdetailList = new List<Orderdetails>();
       public List<Orderdetails> OrderDetailList
       {
           get { return orderdetailList; }
           set { orderdetailList.AddRange(value);} 
       }
       public string OrderNo
       {
           get;
           set;
       }
       public int ShipPostalCode
       {
           get;
           set;
       }
       public string ShipName
       {
           get;
           set;
       }
       public string ShipAddress
       {
           get;
           set;
       }
       public string ShipCity
       {
           get;
           set;
       }
       public string ShipState
       {
           get;
           set;
       }
       public string ShipCountry
       {
           get;
           set;
       }
       public DateTime OrderDate
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

       public Employee EmployeeDetail
       {
           get;
           set;
       }

       public Customer CustomerDetail
       {
           get;
           set;
       }

        public override string ToString()
        {
            return OrderNo + "\t\t" + employee.EmployeeNo + "\t\t" + employee.FirstName + "\t\t" + customer.CustomerNo + "\t\t" + customer.CustomerName + "\t\t" + ShipAddress + "\t\t";
        }
    }
}
