using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillup_generics
{
    public class orderdetails 
    {
        private product product;
        private int quantity;
        private double amount, unitPrice, grandTotal, discount;
        private DateTime createdDate;
        private DateTime ? modifiedDate;
        
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        public double GrandTotal
        {
            get { return grandTotal; }
            set { grandTotal = value; }
        }
        public double DiscountAmount
        {
            get { return discount; }
            set { discount = value; }
        }
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
        public DateTime ? ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }
        public product ProductDetail
        {
            get { return product; }
            set { product = value; }
        }

        public override string ToString()
        {
            return product.ProductNo+"\t\t"+product.ProductName+"\t\t"+UnitPrice+"\t\t"+Quantity+"\t\t"+Amount+"\t\t"+DiscountAmount+"\t\t"+GrandTotal +"\n";
        }
    }
}
