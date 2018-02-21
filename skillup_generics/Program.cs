using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using enumerator;
using System.Diagnostics.CodeAnalysis;
namespace skillup_generics
{

    class Program : Methods
    {
        public static Methods methodOb = new Methods();
        public static List<Employee> employeeList = new List<Employee>();
        public static List<Customer> customerList = new List<Customer>();
        static List<Order> orderList = new List<Order>();
        public static List<Product> productList = new List<Product>();
        static List<Orderdetails> orderdetailList = new List<Orderdetails>();
        static Typechecker tk = new Typechecker();
        static List<Orderdetails> tempList = new List<Orderdetails>();

        static void initaite()
        {
            employeeList.Add(new Employee() { EmployeeNo = "1", FirstName = "javed", LastName = "singh", Address = "12/g street", City = "vadodara", State = "guj", PostalCode = "390019" });
            employeeList.Add(new Employee() { EmployeeNo = "2", FirstName = "prasad", LastName = "rajput", Address = "134 amrapali", City = "vadodara", State = "guj", PostalCode = "370019" });
            employeeList.Add(new Employee() { EmployeeNo = "3", FirstName = "faizal", LastName = "moham", Address = "A501 richmondAp", City = "ahmadabad", State = "guj", PostalCode = "380101" });
            customerList.Add(new Customer() { CustomerNo = "10", CustomerName = "mihir", Address = "134 avadhut soc", City = "surat    ", State = "guj", PostalCode = 365010, Country = "India" });
            customerList.Add(new Customer() { CustomerNo = "11", CustomerName = "kevin", Address = "26 Jalaram soc", City = "surat    ", State = "guj", PostalCode = 365010, Country = "India" });
            customerList.Add(new Customer() { CustomerNo = "12", CustomerName = "pratik", Address = "F/56 nandji soc", City = "vadodara", State = "guj", PostalCode = 390016, Country = "India" });
            productList.Add(new Product() { ProductNo = "23", ProductName = "gas", UnitPrice = 32.50, IsActive = true });
            productList.Add(new Product() { ProductNo = "24", ProductName = "paper", UnitPrice = 5.0, IsActive = true });
            productList.Add(new Product() { ProductNo = "36", ProductName = "bat", UnitPrice = 120, IsActive = true });
            productList.Add(new Product() { ProductNo = "99", ProductName = "RC Car", UnitPrice = 850, IsActive = false });
        }

        static Employee AddEmployee()
        {
            methodOb.PrintEmpDetails();
            string employee_no;

            do
            {
                Console.Write(Constants.ENTEREMPLOYEENO);
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

        static Customer AddCutomer()
        {
            methodOb.PrintCusDetails();
            string customerno;
            do
            {
                Console.Write(Constants.ENTERCUSTOMERNO);
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

        static Product AddProduct()
        {

            methodOb.PrintProDetails();
            string productno;
            do
            {
                Console.Write(Constants.ENTERPRODUCTNO);
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
                Console.WriteLine(Constants.AVAILABLE);
                return AddProduct();
            }

        }

        static public bool IsOrderPlaced(string o_no)
        {
            foreach (Order pair in orderList)
            {

                if (o_no == pair.OrderNo)
                {
                    Console.Write(Constants.EXIST+o_no);
                    return true;
                }
            }
            
            return false;
        }

        static public bool IsOrderExist(string o_no)
        {
            foreach (Order pair in orderList)
            {

                if (o_no == pair.OrderNo)
                {
                    return true;
                }
            }

            Console.WriteLine(o_no+Constants.NOTEXIST);
            return false;
        }

        static public int? AddOrder()
        {
            Order orderOb1 = new Order();
            string orderNo;

            do
            {
                do
                {
                    Console.Write(Constants.ENTERORDERNO);
                    orderNo = Console.ReadLine();
                } while (tk.typeOrder(orderNo));


            } while (IsOrderPlaced(orderNo));

            if (orderNo == "-1")
            {
                return null;
            }

            Customer custmerOb = AddCutomer();

            if (custmerOb == null)
            {
                return null;
            }

            Employee employeeOb = AddEmployee();

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
                Console.Write(Constants.DATE);
                date = Console.ReadLine();

            } while (tk.typeDate(date));
            if (date == "-1")
            {
                return null;
            }

            orderOb1.OrderDate = Convert.ToDateTime(date);
            orderOb1.ShipName = custmerOb.CustomerName;
            orderOb1.ShipAddress = custmerOb.Address;
            orderOb1.ShipCity = custmerOb.City;
            orderOb1.ShipState = custmerOb.State;
            orderOb1.ShipPostalCode = custmerOb.PostalCode;
            orderOb1.ShipCountry = custmerOb.Country;
            orderOb1.CreatedDate = DateTime.Now;
            orderOb1.ModifiedDate = null;
           


            string key;
            do
            {
                Orderdetails orderdetailsOb2 = new Orderdetails();
                string value;
                bool flag = true;
                Product productOb = AddProduct();

                if (productOb == null)
                {
                    orderList.Remove(orderList[orderList.Count - 1]);
                    return null;
                }

                do
                {
                    Console.Write(Constants.ENTERPRICE);
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
                    Console.Write(Constants.ENTERQUANTITY);
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
                    Console.Write(Constants.ENTERDISCOUNT);
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
                orderdetailsOb2.OrderNO = orderNo;


                bool flag2 = false;
                foreach (Orderdetails od in tempList)
                {
                    if (od.ProductDetail.ProductNo.Equals(productOb.ProductNo))
                    {
                        od.UnitPrice = orderdetailsOb2.UnitPrice;
                        od.Amount = orderdetailsOb2.Amount;
                        od.GrandTotal = orderdetailsOb2.GrandTotal;
                        od.DiscountAmount = orderdetailsOb2.DiscountAmount;
                        od.Quantity = orderdetailsOb2.Quantity;
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
                    Console.Write(Constants.ADDMORE);
                    key = Console.ReadLine().ToLower();
                } while (tk.typeSave(key));



            } while (!key.Equals("n"));


            do
            {
                Console.Write(Constants.SAVE);
                save = Console.ReadLine();

            } while (tk.typeSave(save));

            if (save == "Y" || save == "y")
            {
                
                
                orderList.Add(orderOb1);
                foreach (var p in tempList)
                {
                    orderdetailList.Add(p);
                    orderOb1.OrderDetailList.Add(p);
                }

                
                Console.Write(Constants.SAVEDORDER);
                state = false;
                tempList.Clear();

                
            }
            if (save == "N" || save == "n")
            {

                tempList.Clear();
                state = false;
            }



            while (state) ;

            return -1;


        }

        static void ShowOrder(List<Orderdetails> temp = null)
        {

            if (temp == null)
            {

                bool isEmpty = !orderList.Any();
                if (isEmpty)
                {
                    Console.WriteLine(Constants.NODATA);
                }
                else
                {
                    Console.WriteLine(Constants.DETAILS);
                    foreach (Order pair in orderList)
                    {
                        foreach(Orderdetails j in pair.OrderDetailList)
                        {
                        Console.WriteLine(pair.OrderNo + "\t\t" + j.ProductDetail.ProductNo + "\t\t" + j.ProductDetail.ProductName + "\t\t" + String.Format("{0:0.00}", j.UnitPrice) + "\t\t" + j.Quantity + "\t\t" + String.Format("{0:0.00}", j.Amount) + "\t\t\t\t" + String.Format("{0:0.00}", j.DiscountAmount) + "\t\t" + String.Format("{0:0.00}", j.GrandTotal) + "\t\t" + j.CreatedDate + "\t\t" + j.ModifiedDate);
                        }
                    }

                }
            }

            else
            {
                Console.WriteLine(Constants.DETAILS);

                
                    foreach (Orderdetails i in temp)
                    {
                        Console.WriteLine( i.OrderNO+ "\t\t" + i.ProductDetail.ProductNo + "\t\t" + i.ProductDetail.ProductName + "\t\t" + String.Format("{0:0.00}", i.UnitPrice) + "\t\t" + i.Quantity + "\t\t" + String.Format("{0:0.00}", i.Amount) + "\t\t\t\t" + String.Format("{0:0.00}", i.DiscountAmount) + "\t\t" + String.Format("{0:0.00}", i.GrandTotal) + "\t\t" + i.CreatedDate + "\t\t" + i.ModifiedDate);
                    }
                


            }
        }

        static void ShowAllOrderDetails()
        {
            bool isEmpty = (!orderdetailList.Any() && !orderList.Any());
            if (isEmpty)
            {
                Console.WriteLine(Constants.NODATA);
            }
            else
            {

                Console.WriteLine(Constants.SHOWALL);
                 foreach (Order pair in orderList)
                    {
                        foreach (Orderdetails j in pair.OrderDetailList)
                        {
                            Console.Write(pair.OrderNo + "\t\t" + pair.EmployeeDetail.EmployeeNo + "\t\t" + pair.EmployeeDetail.FirstName + "\t\t" + pair.CustomerDetail.CustomerNo + "\t\t" + pair.CustomerDetail.CustomerName + "\t\t" + pair.ShipAddress + "\t\t\t" + j.ToString());
                        }  
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
            bool flag1 = true;

            bool isEmpty = (!orderList.Any());
            DateTime m ;
            if (isEmpty)
            {
                Console.WriteLine(Constants.NODATA);
            }

            else
            {
                do
                {
                    do
                    {
                        Console.Write(Constants.ENTERORDERNO);
                        temp = Console.ReadLine();
                    } while (tk.typeOrder(temp) || !IsOrderExist(temp));


                    while (state)
                    {
                        foreach (Order pair in orderList)
                        {
                            flag1 = true;
                            do
                            {
                                Console.Write(Constants.ENTERPRODUCTNO + Constants.QUANTITYDETAILS);
                                temp2 = Console.ReadLine();
                            } while (tk.typeProduct(temp2));

                            foreach (Orderdetails j in pair.OrderDetailList)
                            {
                                if (temp == pair.OrderNo && temp2 == j.ProductDetail.ProductNo)
                                {
                                    flag1 = false;
                                    do
                                    {
                                        do
                                        {
                                            Console.Write(Constants.ENTERQUANTITY);
                                            qty = Console.ReadLine();
                                        } while (tk.typeQuantity(qty));

                                        quantity = Convert.ToInt32(qty);
                                        amount = quantity * j.UnitPrice;
                                        grandtotal = amount - j.DiscountAmount;

                                    } while (tk.updatedQuantity(grandtotal));

                                    m = DateTime.Now;

                                    Console.WriteLine(Constants.DETAILS);
                                    Console.WriteLine(pair.OrderNo + "\t\t" + j.ProductDetail.ProductNo + "\t\t" + j.ProductDetail.ProductName + "\t\t" + String.Format("{0:0.00}", j.UnitPrice) + "\t\t" + quantity + "\t\t" + String.Format("{0:0.00}", amount) + "\t\t\t\t" + String.Format("{0:0.00}", j.DiscountAmount) + "\t\t" + String.Format("{0:0.00}", grandtotal) + "\t\t" + j.CreatedDate + "\t\t" + m);
                                    do
                                    {
                                        Console.Write(Constants.SAVE);
                                        save = Console.ReadLine();
                                    } while (tk.typeSave(save));

                                    if (save == "y" || save == "Y")
                                    {

                                        j.Quantity = quantity;
                                        j.Amount = amount;
                                        j.GrandTotal = grandtotal;
                                        j.ModifiedDate = m;
                                        state = false;
                                        Console.WriteLine(Constants.UPDATEQUANTITY);
                                        break;
                                    }

                                    else if (save == "n" || save == "N")
                                    {
                                        state = false;
                                        break;
                                    }
                                }
                            }
                            
                           

                        }
                    }
                    if (flag1)
                    {
                        Console.WriteLine(temp2 + Constants.NOTEXIST);
                    }
                } while (state);



            }


        }
    
        static void DeleteOrder()
        {
            List<Order> temp_delete = new List<Order>();
            string temp;

            bool state = true;
            string type_checker;

            do
            {
                bool isEmpty = (!orderList.Any());
                if (isEmpty)
                {
                    Console.WriteLine(Constants.NODATAREMAINING);
                    break;
                }

                else
                {
                    ShowOrder();
                    do
                    {
                        Console.Write(Constants.ENTERORDERNO);
                        type_checker = Console.ReadLine();
                    } while (tk.typeOrder(type_checker));

                    temp = type_checker;
                    bool f = false;

                    do
                    {
                        f = false;

                        foreach (Order pair in orderList)
                        {
                            foreach (Orderdetails j in pair.OrderDetailList)
                            {
                                if (temp == pair.OrderNo)
                                {
                                    temp_delete.Add(pair);
                                    f = true;
                                }
                            }

                        }
                        
                        if (f)
                        {
                            Console.Write(Constants.DELETEORDERNO + temp + ": ");
                            type_checker = Console.ReadLine();
                            if (type_checker == "y" || type_checker == "Y")
                            {

                                foreach (Order pair in temp_delete)
                                {
                                    orderList.Remove(pair);
                                }
                                temp_delete.Clear();
                                f = false;

                            }
                            else if (type_checker == "N" || type_checker == "n")
                            {
                                f = false;
                                break;
                            }
                            else
                            {
                                Console.Write(Constants.ENTERVALID);
                                continue;
                            }

                        }

                        else
                        {
                            Console.WriteLine("\nOrder no. " + temp + Constants.NOTEXIST);
                            f = true;
                            break;
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
                Console.WriteLine(Constants.NODATA);
            }
            else
            {
                Console.WriteLine(Constants.DETAILS);
                Order or = orderList[orderList.Count - 1];
                Orderdetails od = orderdetailList[orderdetailList.Count - 1];
                Console.WriteLine(or.OrderNo + "\t\t" + od.ProductDetail.ProductNo + "\t\t" + od.ProductDetail.ProductName + "\t\t" + od.ProductDetail.UnitPrice + "\t\t" + od.Quantity + "\t\t" + od.Amount + "\t\t" + od.DiscountAmount + "     \t\t\t" + od.GrandTotal + "\t\t" + or.CreatedDate + "\t\t" + od.ModifiedDate);

            }
        }

        static void LastOrderUnitPrice()
        {
            bool isEmpty = (!orderdetailList.Any() && !orderList.Any());
            if (isEmpty)
            {
                Console.WriteLine(Constants.NODATA);
            }
            else
            {
                Console.WriteLine("Order No.\tProduct No.\tUnitPrice");

                Order or = orderList[orderList.Count - 1];
                Orderdetails od = orderdetailList[orderdetailList.Count - 1];
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
                Console.WriteLine(Constants.NODATA);
            }
            else
            {
                do
                {
                    Console.Write(Constants.ENTERCUSTOMERNO);
                    CustomerNo = Console.ReadLine();
                } while (tk.typeCustomer(CustomerNo));
                orderList.Reverse();
                foreach (Order i in orderList)
                {
                    foreach (Orderdetails j in i.OrderDetailList)
                    {
                        if (CustomerNo == i.CustomerDetail.CustomerNo)
                        {
                            Console.WriteLine(Constants.DETAILS);
                            Console.WriteLine(i.OrderNo + "\t\t" + j.ProductDetail.ProductNo + "\t\t" + j.ProductDetail.ProductName + "\t\t" + j.ProductDetail.UnitPrice + "\t\t" + j.Quantity + "\t\t" + j.Amount + "\t\t" + j.DiscountAmount + "     \t\t\t" + j.GrandTotal + "\t\t" + j.CreatedDate + "\t\t" + j.ModifiedDate);
                            IsExist = false;
                            
                        }
                    }
                    break;
                }
                orderList.Reverse();
                if (IsExist == true)
                {
                    Console.WriteLine(CustomerNo + Constants.NOTEXIST);
                }
                //mix.Reverse();
            }
        }

        static void LastOrderUnitPriceProduct()
        {
            bool isEmpty = (!orderList.Any());
            bool IsExist = true;
            string ProductNo;
            if (isEmpty)
            {
                Console.WriteLine(Constants.NODATA);
            }
            else
            {
                do
                {
                    Console.Write(Constants.ENTERPRODUCTNO);
                    ProductNo = Console.ReadLine();
                } while (tk.typeProduct(ProductNo));



                orderList.Reverse();
                foreach (Order i in orderList)
                {
                    foreach (Orderdetails j in i.OrderDetailList)
                    {
                        if (ProductNo == j.ProductDetail.ProductNo)
                        {
                            Console.WriteLine(Constants.ONLYPRODUCTPRICE);
                            Console.WriteLine(j.ProductDetail.ProductNo + "\t\t" + j.UnitPrice);
                            IsExist = false;
                            
                        }
                    }
                    break;
                }

                orderList.Reverse();
                if (IsExist == true)
                    Console.WriteLine(ProductNo + Constants.NOTEXIST);

            }
        }

        static void Main(string[] args)
        {

            Program.initaite();
            bool internal_switch = true;
            Typechecker tk = new Typechecker();
            string n1, n2;
            while (true)
            {
                Menu1 operatorOb1;
                
                do
                {
                    Console.Write("\n\n\nEnter the option from the following :");
                    Console.Write("\n1. Order Entry\n2. Last order details\n3. last order's unit price\n4. Show order details\n5. Last Order details by Customer no\n6. Last order product unit price by product no.\n7. Show all details of Order\n8. exit\nEnter Option from above:  ");
                    n1 = Console.ReadLine();
                } while (tk.typeStart(n1));


                operatorOb1 = (Menu1)(Convert.ToInt32(n1) - 1);


                switch (operatorOb1)
                {
                    case Menu1.OrderEntry:
                        do
                        {
                            do
                            {
                                Console.Write("\n----------------------------------------------:");
                                Console.Write("\n1. Add order\n2. Update order\n3. Delete order\n4. (-1) for Revert Back in Any data entry");
                                Console.Write("\n----------------------------------------------:\n\nEnter Option from above:  ");

                                n2 = Console.ReadLine();
                            } while (tk.typeSecondStart(n2));

                            Menu2 operatorOb2 = (Menu2)(Convert.ToInt32(n2) - 1);

                            switch (operatorOb2)
                            {
                                case Menu2.AddOrder:
                                    int? p = AddOrder();
                                    if (p == null)
                                    {
                                        internal_switch = true;
                                    }
                                    break;
                                case Menu2.UpdateOrder:
                                    UpdateOrder();
                                    internal_switch = false;
                                    break;
                                case Menu2.DeleteOrder:
                                    DeleteOrder();
                                    internal_switch = false;
                                    break;
                                case Menu2.Revert:
                                    internal_switch = false;
                                    break;
                                default:
                                    Console.WriteLine(Constants.ENTERVALID);
                                    break;
                            }

                        } while (internal_switch);

                        break;

                    case Menu1.LastOrderDetails:
                        LastOrderDetails();
                        break;
                    case Menu1.LastOrderUnitPrice:
                        LastOrderUnitPrice();
                        break;
                    case Menu1.ShowOrder:
                        ShowOrder();
                        break;
                    case Menu1.Exit:
                        Environment.Exit(0);
                        break;
                    case Menu1.LastOrderDetailsByCustomer:
                        LastOrderDetailsCustomer();
                        break;
                    case Menu1.LastOrderDetailsByProduct:
                        LastOrderUnitPriceProduct();
                        break;
                    case Menu1.ShowAllDetailsOfOrder:
                        ShowAllOrderDetails();
                        break;
                    default:
                        Console.WriteLine(Constants.ENTERVALID);
                        break;

                }

            }

        }
    }
}