using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using enumerator;
namespace skillup_generics
{

    class Program : Methods
    {
        public static Methods methodOb = new Methods();
        public static List<employee> employeeList = new List<employee>();
        public static List<customer> customerList = new List<customer>();
        static List<order> orderList = new List<order>();
        public static List<product> productList = new List<product>();
        static List<orderdetails> orderdetailList = new List<orderdetails>();
        static typechecker tk = new typechecker();
        static List<orderdetails> tempList = new List<orderdetails>();
        static Dictionary<orderdetails, order> mixList = new Dictionary<orderdetails, order>();

        static void initaite()
        {
            employeeList.Add(new employee() { EmployeeNo = "1", FirstName = "javed", LastName = "singh", Address = "12/g street", City = "vadodara", State = "guj", PostalCode = "390019" });
            employeeList.Add(new employee() { EmployeeNo = "2", FirstName = "prasad", LastName = "rajput", Address = "134 amrapali", City = "vadodara", State = "guj", PostalCode = "370019" });
            employeeList.Add(new employee() { EmployeeNo = "3", FirstName = "faizal", LastName = "moham", Address = "A501 richmondAp", City = "ahmadabad", State = "guj", PostalCode = "380101" });
            customerList.Add(new customer() { CustomerNo = "10", CustomerName = "mihir", Address = "134 avadhut soc", City = "surat    ", State = "guj", PostalCode = 365010, Country = "India" });
            customerList.Add(new customer() { CustomerNo = "11", CustomerName = "kevin", Address = "26 Jalaram soc", City = "surat    ", State = "guj", PostalCode = 365010, Country = "India" });
            customerList.Add(new customer() { CustomerNo = "12", CustomerName = "pratik", Address = "F/56 nandji soc", City = "vadodara", State = "guj", PostalCode = 390016, Country = "India" });
            productList.Add(new product() { ProductNo = "23", ProductName = "gas", UnitPrice = 32.50, IsActive = true });
            productList.Add(new product() { ProductNo = "24", ProductName = "paper", UnitPrice = 5.0, IsActive = true });
            productList.Add(new product() { ProductNo = "36", ProductName = "bat", UnitPrice = 120, IsActive = true });
            productList.Add(new product() { ProductNo = "99", ProductName = "RC Car", UnitPrice = 850, IsActive = false });
        }

        static employee AddEmployee()
        {
            methodOb.PrintEmpDetails();
            string employee_no;

            do
            {
                Console.Write(constants.ENTEREMPLOYEENO);
                employee_no = Console.ReadLine();
            } while (tk.typeEmployee(employee_no));


            if (employee_no == "-1")
            {
                return null;
            }
            else
            {
                var employee = employeeList.Find(s => s.EmployeeNo == employee_no);
                return employee;
            }
        }

        static customer AddCutomer()
        {
            methodOb.PrintCusDetails();
            string customerno;
            do
            {
                Console.Write(constants.ENTERCUSTOMERNO);
                customerno = Console.ReadLine();
            } while (tk.typeCustomer(customerno));

            if (customerno == "-1")
            {
                return null;
            }
            else
            {
                var customer = customerList.Find(s => s.CustomerNo == customerno);
                return customer;
            }

        }

        static product AddProduct()
        {

            methodOb.PrintProDetails();
            string productno;
            do
            {
                Console.Write(constants.ENTERPRODUCTNO);
                productno = Console.ReadLine();
            } while (tk.typeProduct(productno));

            if (productno == "-1")
            {
                return null;
            }

            var product = productList.Find(s => s.ProductNo == productno);

            if (product.IsActive == true)
                return product;
            else
            {
                Console.WriteLine(constants.AVAILABLE);
                return AddProduct();
            }

        }

        static public bool IsOrderPlaced(string o_no)
        {

            for (int i = 0; i < orderList.Count; i++)
            {
                if (o_no == orderList[i].OrderNo)
                {
                    Console.Write(constants.EXIST);
                    return true;
                }

            }
            return false;
        }

        static public int? AddOrder()
        {
            order orderOb1 = new order();
            string orderNo;

            do
            {
                do
                {
                    Console.Write(constants.ENTERORDERNO);
                    orderNo = Console.ReadLine();
                } while (tk.typeOrder(orderNo));


            } while (IsOrderPlaced(orderNo));

            if (orderNo == "-1")
            {
                return null;
            }

            customer custmerOb = AddCutomer();

            if (custmerOb == null)
            {
                return null;
            }

            employee employeeOb = AddEmployee();

            if (employeeOb == null)
            {
                return null;
            }


            string date, save;
            bool state = true;
            orderOb1.OrderNo = orderNo;
            orderOb1.CustomerDetail = custmerOb;
            orderOb1.EmployeeDetail = employeeOb;

            do
            {
                Console.Write(constants.DATE);
                date = Console.ReadLine();

            } while (tk.typeDate(date));
            if (date == "-1")
            {
                return null;
            }
            orderOb1.OrderDate = date;
            orderOb1.ShipName = custmerOb.CustomerName;
            orderOb1.ShipAddress = custmerOb.Address;
            orderOb1.ShipCity = custmerOb.City;
            orderOb1.ShipState = custmerOb.State;
            orderOb1.ShipPostalCode = custmerOb.PostalCode;
            orderOb1.ShipCountry = custmerOb.Country;
            orderOb1.CreatedDate = DateTime.Now;
            orderOb1.ModifiedDate = null;
            orderList.Add(orderOb1);


            string key;
            do
            {
                orderdetails orderdetailsOb2 = new orderdetails();
                string value;
                bool flag = true;
                product productOb = AddProduct();

                if (productOb == null)
                {
                    orderList.Remove(orderList[orderList.Count - 1]);
                    return null;
                }

                do
                {
                    Console.Write(constants.ENTERPRICE);
                    value = Console.ReadLine();
                    if (value == "")
                    {
                        flag = false;
                        break;
                    }

                } while (tk.typeAmount(value));


                if (value == "-1")
                {
                    orderList.Remove(orderList[orderList.Count - 1]);
                    return null;
                }

                if (flag == true)
                {
                    orderdetailsOb2.UnitPrice = Convert.ToDouble(value);
                }
                else
                {
                    orderdetailsOb2.UnitPrice = productOb.UnitPrice;
                }
                do
                {
                    Console.Write(constants.ENTERQUANTITY);
                    value = Console.ReadLine();
                } while (tk.typeQuantity(value));

                if (value == "-1")
                {
                    orderList.Remove(orderList[orderList.Count - 1]);
                    return null;
                }
                orderdetailsOb2.Quantity = Convert.ToInt32(value);
                orderdetailsOb2.Amount = orderdetailsOb2.Quantity * orderdetailsOb2.UnitPrice;


                do
                {
                    Console.Write(constants.ENTERDISCOUNT);
                    value = Console.ReadLine();
                } while (tk.typeDiscount(value, orderdetailsOb2.Amount));
                if (value == "-1")
                {
                    orderList.Remove(orderList[orderList.Count - 1]);
                    return null;
                }

                orderdetailsOb2.DiscountAmount = Convert.ToDouble(value);
                orderdetailsOb2.GrandTotal = orderdetailsOb2.Amount - orderdetailsOb2.DiscountAmount;
                orderdetailsOb2.CreatedDate = orderOb1.CreatedDate;
                orderdetailsOb2.ModifiedDate = null;    
                orderdetailsOb2.ProductDetail = productOb;

                bool flag2 = false;
                foreach (orderdetails od in tempList)
                {
                    if (od.ProductDetail.ProductNo.Equals(productOb.ProductNo))
                    {
                        od.UnitPrice = orderdetailsOb2.UnitPrice;
                        od.Amount = orderdetailsOb2.Amount;
                        od.DiscountAmount = orderdetailsOb2.DiscountAmount;
                        od.Quantity = orderdetailsOb2.Quantity;
                        od.ModifiedDate = DateTime.Now;
                        flag2 = true;
                    }

                }

                if (flag2 == false)
                {
                    tempList.Add(orderdetailsOb2);
                }

                ShowOrder(tempList);

                do
                {
                    Console.Write(constants.ADDMORE);
                    key = Console.ReadLine().ToLower();
                } while (tk.typeSave(key));



            } while (!key.Equals("n"));


            do
            {
                Console.Write(constants.SAVE);
                save = Console.ReadLine();

            } while (tk.typeSave(save));

            if (save == "Y" || save == "y")
            {
                //do nothing
                foreach (var p in tempList)
                {
                    orderdetailList.Add(p);
                    mixList.Add(p, orderOb1);
                }

                orderList.Add(orderOb1);
                Console.Write(constants.SAVEDORDER);
                state = false;
                tempList.Clear();



                foreach (orderdetails pair in tempList)
                {
                    mixList.Add(pair, orderOb1);
                }

            }
            if (save == "N" || save == "n")
            {

                tempList.Clear();
                state = false;
            }



            while (state) ;

            return -1;


        }

        static void ShowOrder(List<orderdetails> temp = null)
        {

            if (temp == null)
            {

                bool isEmpty = !mixList.Any();
                if (isEmpty)
                {
                    Console.WriteLine(constants.NODATA);
                }
                else
                {
                    Console.WriteLine(constants.DETAILS);
                    foreach (KeyValuePair<orderdetails, order> pair in mixList)
                    {

                        Console.WriteLine(pair.Value.OrderNo + "\t\t" + pair.Key.ProductDetail.ProductNo + "\t\t" + pair.Key.ProductDetail.ProductName + "\t\t" + String.Format("{0:0.00}", pair.Key.UnitPrice) + "\t\t" + pair.Key.Quantity + "\t\t" + String.Format("{0:0.00}", pair.Key.Amount) + "\t\t\t\t" + String.Format("{0:0.00}", pair.Key.DiscountAmount) + "\t\t" + String.Format("{0:0.00}", pair.Key.GrandTotal) + "\t\t" + pair.Key.CreatedDate + "\t\t" + pair.Key.ModifiedDate);

                    }

                }
            }

            else
            {
                Console.WriteLine(constants.DETAILS);

                foreach (var i in temp)
                {
                    int j = 0;
                    Console.WriteLine(orderList[j].OrderNo + "\t\t" + i.ProductDetail.ProductNo + "\t\t" + i.ProductDetail.ProductName + "\t\t" + String.Format("{0:0.00}", i.UnitPrice) + "\t\t" + i.Quantity + "\t\t" + String.Format("{0:0.00}", i.Amount) + "\t\t\t\t" + String.Format("{0:0.00}", i.DiscountAmount) + "\t\t" + String.Format("{0:0.00}", i.GrandTotal) + "\t\t" + i.CreatedDate + "\t\t" + i.ModifiedDate);
                    j++;
                }


            }
        }

        static void ShowAllOrderDetails()
        {
            bool isEmpty = (!orderdetailList.Any() && !orderList.Any());
            if (isEmpty)
            {
                Console.WriteLine(constants.NODATA);
            }
            else
            {

                Console.WriteLine(constants.SHOWALL);
                foreach (KeyValuePair<orderdetails, order> pair in mixList)
                {
                    Console.Write(pair.Value.OrderNo + "\t\t" + pair.Value.EmployeeDetail.EmployeeNo + "\t\t" + pair.Value.EmployeeDetail.FirstName + "\t\t" + pair.Value.CustomerDetail.CustomerNo + "\t\t" + pair.Value.CustomerDetail.CustomerName + "\t\t" + pair.Value.ShipAddress + "\t\t" + pair.Key);

                }
            }
        }

        static void UpdateOrder()
        {
            int quantity = 0;
            string save;
            double amount = 0, grandtotal = 0;
            string qty;
            string temp = "", temp2 = "";
            bool state = true;
            bool flas1 = true;
            bool flas2 = false;
            bool isEmpty = (!mixList.Any());
            DateTime m = DateTime.Now;
            if (isEmpty)
            {
                Console.WriteLine(constants.NODATA);
            }

            else
            {
                do
                {
                    do
                    {
                        Console.Write(constants.ENTERORDERNO);
                        temp = Console.ReadLine();
                    } while (tk.typeOrder(temp));





                    foreach (KeyValuePair<orderdetails, order> pair in mixList)
                    {
                        flas1 = true;
                        if (temp == pair.Value.OrderNo)
                        {
                            flas1 = false;
                            do
                            {
                                Console.Write(constants.ENTERPRODUCTNO + constants.QUANTITYDETAILS);
                                temp2 = Console.ReadLine();
                            } while (tk.typeProduct(temp2));




                            foreach (KeyValuePair<orderdetails, order> pair2 in mixList)
                            {


                                if (pair2.Key.ProductDetail.ProductNo == temp2)
                                {
                                    do
                                    {
                                        Console.Write(constants.ENTERQUANTITY);
                                        qty = Console.ReadLine();
                                    } while (tk.typeQuantity(qty));

                                    quantity = Convert.ToInt32(qty);
                                    amount = quantity * pair2.Key.UnitPrice;
                                    grandtotal = amount - pair2.Key.DiscountAmount;
                                    m = DateTime.Now;
                                    Console.Write(constants.UPDATEQUANTITY + "\n");
                                    Console.WriteLine(constants.DETAILS);
                                    Console.WriteLine(pair2.Value.OrderNo + "\t\t" + pair2.Key.ProductDetail.ProductNo + "\t\t" + pair2.Key.ProductDetail.ProductName + "\t\t" + String.Format("{0:0.00}", pair2.Key.UnitPrice) + "\t\t" + quantity + "\t\t" + String.Format("{0:0.00}", amount) + "\t\t\t\t" + String.Format("{0:0.00}", pair2.Key.DiscountAmount) + "\t\t" + String.Format("{0:0.00}", grandtotal) + "\t\t" + pair2.Key.CreatedDate + "\t\t" + m);
                                    do
                                    {
                                        Console.Write(constants.SAVE);
                                        save = Console.ReadLine();
                                    } while (tk.typeSave(save));

                                    if (save == "y" || save == "Y")
                                    {

                                        pair2.Key.Quantity = quantity;
                                        pair2.Key.Amount = amount;
                                        pair2.Key.GrandTotal = grandtotal;
                                        pair2.Key.ModifiedDate = m;
                                        state = false;
                                        flas2 = true;

                                    }

                                    else if (save == "n" || save == "N")
                                    {
                                        state = false;
                                        flas2 = true;
                                        break;
                                    }

                                }




                            }

                            if (flas2 == false)
                            {
                                Console.WriteLine(temp2 + constants.NOTEXIST);
                                state = true;
                                break;
                            }

                            break;


                        }

                    }


                    if (flas1 == true)
                    {
                        Console.WriteLine(temp + constants.NOTEXIST);
                    }


                } while (state);



            }


        }

        static void DeleteOrder(string ord_no = "0")
        {


            Dictionary<orderdetails, order> temp_delete = new Dictionary<orderdetails, order>();

            string temp;

            bool state = true;
            string type_checker;

            do
            {
                bool isEmpty = (!mixList.Any());
                if (isEmpty)
                {
                    Console.WriteLine(constants.NODATAREMAINING);
                    break;
                }

                else
                {
                    ShowOrder();
                    do
                    {
                        Console.Write(constants.ENTERORDERNO);
                        type_checker = Console.ReadLine();
                    } while (tk.typeOrder(type_checker));

                    temp = type_checker;
                    bool f = false;

                    do
                    {
                        f = false;

                        foreach (KeyValuePair<orderdetails, order> pair in mixList)
                        {

                            if (temp == pair.Value.OrderNo)
                            {

                                temp_delete.Add(pair.Key, pair.Value);
                                f = true;

                            }

                        }
                        if (f)
                        {
                            Console.Write(constants.DELETEORDERNO + temp + ": ");
                            type_checker = Console.ReadLine();
                            if (type_checker == "y" || type_checker == "Y")
                            {

                                foreach (KeyValuePair<orderdetails, order> pair in temp_delete)
                                {
                                    mixList.Remove(pair.Key);
                                }
                                f = false;

                            }
                            else if (type_checker == "N" || type_checker == "n")
                            {
                                f = false;
                                break;
                            }
                            else
                            {
                                Console.Write(constants.ENTERVALID);
                                continue;
                            }

                        }

                    } while (f);

                    if (!f)
                    {
                        break;
                    }
                }

            } while (state);


        }

        static void LastOrderDetails()
        {
            bool isEmpty = (orderdetailList.Count == 0 && orderList.Count == 0);
            if (isEmpty)
            {
                Console.WriteLine(constants.NODATA);
            }
            else
            {
                Console.WriteLine(constants.DETAILS);
                order or = orderList[orderList.Count - 1];
                orderdetails od = orderdetailList[orderdetailList.Count - 1];
                Console.WriteLine(or.OrderNo + "\t\t" + od.ProductDetail.ProductNo + "\t\t" + od.ProductDetail.ProductName + "\t\t" + od.ProductDetail.UnitPrice + "\t\t" + od.Quantity + "\t\t" + od.Amount + "\t\t" + od.DiscountAmount + "     \t\t\t" + od.GrandTotal + "\t\t" + or.CreatedDate + "\t\t" + od.ModifiedDate);

            }
        }

        static void LastOrderUnitPrice()
        {
            bool isEmpty = (!orderdetailList.Any() && !orderList.Any());
            if (isEmpty)
            {
                Console.WriteLine(constants.NODATA);
            }
            else
            {
                Console.WriteLine("Order No.\tProduct No.\tUnitPrice");

                order or = orderList[orderList.Count - 1];
                orderdetails od = orderdetailList[orderdetailList.Count - 1];
                Console.WriteLine(or.OrderNo + "\t\t" + od.ProductDetail.ProductNo + "\t\t" + od.ProductDetail.UnitPrice);

            }
        }

        static void LastOrderDetailsCustomer()
        {
            bool isEmpty = (!orderdetailList.Any() && !orderList.Any());
            bool IsExist = true;
            string CustomerNo;
            if (isEmpty)
            {
                Console.WriteLine(constants.NODATA);
            }
            else
            {
                do
                {
                    Console.Write(constants.ENTERCUSTOMERNO);
                    CustomerNo = Console.ReadLine();
                } while (tk.typeCustomer(CustomerNo));

                foreach (KeyValuePair<orderdetails, order> pair in mixList.Reverse())
                {
                    if (CustomerNo == pair.Value.CustomerDetail.CustomerNo)
                    {
                        Console.WriteLine(constants.DETAILS);
                        Console.WriteLine(pair.Value.OrderNo + "\t\t" + pair.Key.ProductDetail.ProductNo + "\t\t" + pair.Key.ProductDetail.ProductName + "\t\t" + pair.Key.ProductDetail.UnitPrice + "\t\t" + pair.Key.Quantity + "\t\t" + pair.Key.Amount + "\t\t" + pair.Key.DiscountAmount + "     \t\t\t" + pair.Key.GrandTotal + "\t\t" + pair.Value.CreatedDate + "\t\t" + pair.Key.ModifiedDate);
                        IsExist = false;
                        break;
                    }

                }

                if (IsExist == true)
                {
                    Console.WriteLine(CustomerNo + constants.NOTEXIST);
                }
                //mix.Reverse();
            }
        }

        static void LastOrderUnitPriceProduct()
        {
            bool isEmpty = (!mixList.Any());
            bool IsExist = true;
            string ProductNo;
            if (isEmpty)
            {
                Console.WriteLine(constants.NODATA);
            }
            else
            {
                do
                {
                    Console.Write(constants.ENTERPRODUCTNO);
                    ProductNo = Console.ReadLine();
                } while (tk.typeProduct(ProductNo));




                foreach (KeyValuePair<orderdetails, order> pair in mixList.Reverse())
                {
                    if (ProductNo == pair.Key.ProductDetail.ProductNo)
                    {
                        Console.WriteLine(constants.ONLYPRODUCTPRICE);
                        Console.WriteLine(pair.Key.ProductDetail.ProductNo + "\t\t" + pair.Key.UnitPrice);
                        IsExist = false;
                        break;
                    }

                }


                if (IsExist == true)
                    Console.WriteLine(ProductNo + constants.NOTEXIST);

            }
        }

        static void Main(string[] args)
        {

            Program.initaite();
            bool internal_switch = true;
            typechecker tk = new typechecker();
            string n1, n2;
            while (true)
            {
                Operator operatorOb1;
                do
                {
                    Console.Write("\n\n\nEnter the option from the following :");
                    Console.Write("\n1. Order Entry\n2. Last order details\n3. last order's unit price\n4. Show order details\n5. Last Order details by Customer no\n6. Last order product unit price by product no.\n7. Show all details of Order\n8. exit\nEnter Option from above:  ");
                    n1 = Console.ReadLine();
                } while (tk.typeStart(n1));

                operatorOb1 = (Operator)(Convert.ToInt32(n1) - 1);
                switch (operatorOb1)
                {
                    case Operator.OrderEntry:
                        do
                        {
                            do
                            {
                                Console.Write("\n----------------------------------------------:");
                                Console.Write("\n1. Add order\n2. Update order\n3. Delete order\n4. (-1) for Revert Back in Any data entry");
                                Console.Write("\n----------------------------------------------:\n\nEnter Option from above:  ");

                                n2 = Console.ReadLine();
                            } while (tk.typeSecondStart(n2));

                            Operator2 operatorOb2 = (Operator2)(Convert.ToInt32(n2) - 1);

                            switch (operatorOb2)
                            {
                                case Operator2.AddOrder:
                                    int? p = AddOrder();
                                    if (p == null)
                                    {
                                        internal_switch = true;
                                    }
                                    break;
                                case Operator2.UpdateOrder:
                                    UpdateOrder();
                                    internal_switch = false;
                                    break;
                                case Operator2.DeleteOrder:
                                    DeleteOrder();
                                    internal_switch = false;
                                    break;
                                case Operator2.Revert:
                                    internal_switch = false;
                                    break;
                            }

                        } while (internal_switch);

                        break;

                    case Operator.LastOrderDetails:
                        LastOrderDetails();
                        break;
                    case Operator.LastOrderUnitPrice:
                        LastOrderUnitPrice();
                        break;
                    case Operator.ShowOrder:
                        ShowOrder();
                        break;
                    case Operator.Exit:
                        Environment.Exit(0);
                        break;
                    case Operator.LastOrderDetailsByCustomer:
                        LastOrderDetailsCustomer();
                        break;
                    case Operator.LastOrderDetailsByProduct:
                        LastOrderUnitPriceProduct();
                        break;
                    case Operator.ShowAllDetailsOfOrder:
                        ShowAllOrderDetails();
                        break;

                }

            }

        }
    }
}