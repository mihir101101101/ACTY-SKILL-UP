using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
    interface IAllMethods
    {
        void PrintEmpDetails();
        void PrintCusDetails();
        void PrintProDetails();
        

    }


    class Methods : IAllMethods
    {
        public void PrintEmpDetails()
        {
            Console.WriteLine(constants.EMPLOYEEDETAILS);
            for (int i = 0; i < Program.employeeList.Count; i++)
                Console.WriteLine(Program.employeeList[i]);
        }

        public void PrintCusDetails()
        {
            Console.WriteLine(constants.CUSTOMERDETAILS);
            for (int i = 0; i < Program.customerList.Count; i++)
                Console.WriteLine(Program.customerList[i]);

        }

        public void PrintProDetails()
        {
            Console.WriteLine(constants.PRODUCTDETAILS);
            for (int i = 0; i < Program.productList.Count; i++)
                Console.WriteLine(Program.productList[i]);

        }
       
    }
}
