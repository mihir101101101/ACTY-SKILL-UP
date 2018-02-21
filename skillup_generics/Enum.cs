using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enumerator
{
    public enum Menu1
    {
        OrderEntry = 0 , LastOrderDetails = 1 , LastOrderUnitPrice = 2, ShowOrder, LastOrderDetailsByCustomer, LastOrderDetailsByProduct, ShowAllDetailsOfOrder, Exit
    };
    public enum Menu2
    {

        Revert=-1,AddOrder,UpdateOrder,DeleteOrder
    };
}
