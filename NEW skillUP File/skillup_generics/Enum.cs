using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enumerator
{
    public enum Operator
    {
        OrderEntry, LastOrderDetails, LastOrderUnitPrice, ShowOrder, LastOrderDetailsByCustomer, LastOrderDetailsByProduct,ShowAllDetailsOfOrder, Exit
    };
    public enum Operator2
    {

        Revert=-1,AddOrder,UpdateOrder,DeleteOrder
    };
}
