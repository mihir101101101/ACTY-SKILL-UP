using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace skillup_generics
{
   static class Program

   {
            static IList<employee> e_list = new List<employee>();
            static IList<customer> c_list = new List<customer>();
            static IList<order> order_list = new List<order>();
            static IList<product> p_list = new List<product>();
            static IList<orderdetails> orderdetails_list = new List<orderdetails>();
            static typechecker tk = new typechecker();

           static void initaite()
            {
                e_list.Add(new employee() { EmployeeNo = 1, FirstName = "javed", LastName = "singh", Address = "12/g street", City = "vadodara", State = "guj", PostalCode = 390019 });
                e_list.Add(new employee() { EmployeeNo = 2, FirstName = "prasad", LastName = "rajput", Address = "134 amrapali", City = "vadodara", State = "guj", PostalCode = 370019 });
                e_list.Add(new employee() { EmployeeNo = 3, FirstName = "faizal", LastName = "moham", Address = "A501 richmondAp", City = "ahmadabad", State = "guj", PostalCode = 380101 });
                c_list.Add(new customer() { CustomerNo = 10, CustomerName = "mihir", Address = "134 avadhut soc", City = "surat    ", State = "guj",PostalCode = 365010, Country = "India" });
                c_list.Add(new customer() { CustomerNo = 11, CustomerName = "kevin", Address = "26 Jalaram soc", City = "surat    ", State = "guj", PostalCode = 365010, Country = "India" });
                c_list.Add(new customer() { CustomerNo = 12, CustomerName = "pratik", Address = "F/56 nandji soc", City = "vadodara", State = "guj", PostalCode = 390016, Country = "India" });
                p_list.Add(new product() { ProductNo = 023, ProductName = "gas", UnitPrice = 32.50 , IsActive= true});
                p_list.Add(new product() { ProductNo = 024, ProductName = "paper", UnitPrice = 5.0 , IsActive =true});
                p_list.Add(new product() { ProductNo = 036, ProductName = "bat", UnitPrice = 120 , IsActive= true});
                p_list.Add(new product() { ProductNo = 099, ProductName = "RC Car", UnitPrice = 850, IsActive = false });
            }

           static void print_emp_details()
           {
               Console.WriteLine("\n\nEmployee No.\tFirst Name\tLast Name\tAddress\t\t\tCity\t\tState\tPostal Code");
               foreach (var i in e_list)
               {
                   Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t{5}\t{6}", i.EmployeeNo, i.FirstName,i.LastName,i.Address,i.City,i.State,i.PostalCode);
               }

           }

           static void print_cus_details()
           {
               Console.WriteLine("\n\nCustomer No.\tCustomer Name\tAddress\t\t\tCity\t\tState\t\tPostal Code\t\tCountry");
               foreach (var i in c_list)
               {
                   Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t{4}\t\t{5}\t\t     {6}", i.CustomerNo, i.CustomerName,i.Address,i.City,i.State,i.PostalCode,i.Country);
               }
           }

           static void print_pro_details()
           {
               Console.WriteLine("\n\nProduct No.\tProduct Name\tProduct Unit Prize\tIsAvailable");
               for (int i = 0; i < 4 ; i++ )
                   Console.WriteLine(p_list[i]);
           
           }

           static employee add_emploee()
           {
               print_emp_details();
               string e1;
               int e_no;
               do
               {
                   Console.Write("\nEnter employee No:");
                   e1 = Console.ReadLine();
               } while (tk.type_e(e1));
               e_no = Convert.ToInt32(e1);

               for (int i = 0; i < e_list.Count; i++)
               {
                   employee e = e_list[i];
                   if (e.EmployeeNo == e_no)
                       return e_list[i];
               }
               return add_emploee();
           
           }

           static customer add_customer()
           {
               print_cus_details();
               string c1;
               int CustomerNo;
               do
               {
                   Console.Write("\nEnter customer No:");
                   c1 = Console.ReadLine();
               } while (tk.type_c(c1));

               CustomerNo = Convert.ToInt32(c1);
               for (int i = 0; i < c_list.Count; i++)
               {
                   customer c = c_list[i];
                   if (c.CustomerNo == CustomerNo)
                       return c_list[i];
               }
               return add_customer();
           }

           static product add_product()
           {
               
               print_pro_details();
               string p1;
               int p_no;
               do
               {
                   Console.Write("\nEnter Product no: ");
                   p1 = Console.ReadLine();
               } while (tk.type_p(p1));

               p_no = Convert.ToInt32(p1);

               for (int i = 0; i < p_list.Count; i++)
               {

                   if (p_list[i].ProductNo == p_no)
                   {
                       if (p_list[i].IsActive == true)
                           return p_list[i];
                       else { Console.WriteLine("product is not available please enter valid data:-----------------"); }
                   }
                  
               }
               return add_product();

           }

           static public bool order_again(int o_no)
       {
           
            for (int i = 0; i < order_list.Count; i++)
               {
                   if (o_no == order_list[i].OrderNo)
                   {
                       Console.Write("\nALready entered----------->");
                       return true;
                   }
               
               }
            return false;
       }

          static public void add_order()
           {
               order o1 = new order();
               int o_no;
               string oa1;
               do
               {

                   do
                   {
                       Console.Write("\nEnter the order no: ");
                       oa1 = Console.ReadLine();
                   } while (tk.type_o(oa1));
                   o_no = Convert.ToInt32(oa1);
               } while (order_again(o_no));

                customer c = add_customer();
                employee e = add_emploee();
                string date,save;
                bool state=true;
                o1.OrderNo = o_no;
                o1.CustomerDetail = c;
                o1.EmployeeDetail = e;

                do
                {
                    Console.Write("\nEnter order Date: in(dd/mm/yyyy) format: ");
                    date = Console.ReadLine();

                } while (tk.type_date(date));

                o1.OrderDate = Convert.ToDateTime(date);
                o1.ShipName = c.CustomerName;
                o1.ShipAddress = c.Address;
                o1.ShipCity = c.City;
                o1.ShipState = c.State;
                o1.ShipPostalCode = c.PostalCode;
                o1.ShipCountry = c.Country;
                o1.CreatedDate = DateTime.Now;
                o1.ModifiedDate = DateTime.Now;
                
                order_list.Add(o1);
                string key;
                 do
                {
                  orderdetails o2 = new orderdetails();
                  string q1;
                  bool flag=true;
                  product p1 = add_product();

                  do
                  {
                      Console.Write("\nENter UNit Price: ");
                      q1 = Console.ReadLine();
                      if (q1 == "")
                      {
                          flag = false;
                          break;
                      }

                  } while (tk.type_dis(q1));
                  if (flag == true)
                  {
                      o2.UnitPrice = Convert.ToDouble(q1);
                  }
                  else {
                      o2.UnitPrice = p1.UnitPrice;
                  }
                  do{
                     Console.Write("\nEnter the product quantity :");
                     q1 = Console.ReadLine();
                  }while(tk.type_q(q1));

                     
                  o2.Quantity = Convert.ToInt32(q1);
                  
                  o2.Amount = o2.Quantity * o2.UnitPrice;

                    do{
                    Console.Write("\nEnter the discount amount : ");
                    q1 = Console.ReadLine();
                    }while(tk.type_dis(q1));

                  o2.DiscountAmount = Convert.ToDouble(q1);
                  o2.GrandTotal = o2.Amount - o2.DiscountAmount;
                  o2.CreatedDate = o1.CreatedDate;
                  o2.ModifiedDate = o1.CreatedDate;
                  o2.Ref_no = o_no;
                  o2.ProductDetail = p1;

                  orderdetails_list.Add(o2);
                  show_order();
                  do
                  {
                      Console.Write("\n\nWant to add another details: for YES press 1 for NO press 0 :------------------>");
                      key = Console.ReadLine();
                  } while (tk.type_save(key));

                } while ((Convert.ToInt32(key))!=0);

              
              do{
                 Console.Write("\nDo you want to Save or not: type(yes/YES) for save or (no/NO) for not:------------------>");
                 save = Console.ReadLine();
                 if (save == "YES" || save == "yes")
                 {
                     //do nothing
                     Console.Write("\nOrder has been saved:---------->");
                     state = false;
                 }
                 else if (save == "NO" || save == "no")
                 {
                 
                     for (int i = 0; i < order_list.Count; i++)
                     {
                         if (o_no == order_list[i].OrderNo)
                         {
                             for (int j = 0; j < orderdetails_list.Count; j++)
                             {
                                 if (o_no == orderdetails_list[i].Ref_no)
                                 {
                                     orderdetails_list.Remove(orderdetails_list[i]);

                                 }
                             }
                             order_list.Remove(order_list[i]);
                             state = false;
                             break;
                         }

                     }
                     state = false;
                 }

                 else
                 {
      
                     Console.Write("Enter again:-------------->");
                     state = true;
                 }

              }while(state);


           }

          static void show_order()
          {
              bool isEmpty = (!orderdetails_list.Any() && !order_list.Any());
              if (isEmpty)
              {
                  Console.WriteLine("There is no record----------------->");
              }
              else
              {
                  Console.WriteLine("Order No.\tProduct No.\tProduct Name\tUnitPrice\tQuantity\tAmount\t     Discount Amount\t\tGrand Total\tCreated Date\t\t\tModified date");
                  for (int j = 0; j < order_list.Count; j++)
                  {
                      order or = order_list[j];
                      int order_no = or.OrderNo;

                      for (int i = 0; i < orderdetails_list.Count; i++)
                      {
                          orderdetails od = orderdetails_list[i];
                          if (order_no == od.Ref_no)
                          {
                              Console.WriteLine(or.OrderNo + "\t\t" + od.ProductDetail.ProductNo + "\t\t" + od.ProductDetail.ProductName + "\t\t" + od.UnitPrice + "\t\t" + od.Quantity + "\t\t" + od.Amount + "\t\t" + od.DiscountAmount + "     \t\t\t" + od.GrandTotal + "\t\t" + or.CreatedDate + "\t\t" + od.ModifiedDate);
                          }


                      }

                  }
              }
          }

          static void update_order()
          {
              int temp,temp2,qty;
              bool state=true;

              bool isEmpty = (!orderdetails_list.Any() && !order_list.Any());
              if (isEmpty)
              {
                  Console.WriteLine("There is no record----------------->");
              }

              else
              {
                  do
                  {
                      Console.Write("\nEnter the order no: ");
                      temp = Convert.ToInt32(Console.ReadLine());
                      for (int i = 0; i < order_list.Count; i++)
                      {

                          if (temp == order_list[i].OrderNo)
                          {
                              while (state)
                              {
                                  Console.Write("\nEnter the product no for which qty needs to be update : ");
                                  temp2 = Convert.ToInt32(Console.ReadLine());
                                  for (int j = 0; j < orderdetails_list.Count; j++)
                                  {
                                      if (temp2 == orderdetails_list[j].ProductDetail.ProductNo && temp == orderdetails_list[j].Ref_no)
                                      {
                                          Console.Write("\nEnter the qty: ");
                                          qty = Convert.ToInt32(Console.ReadLine());
                                          orderdetails_list[j].Quantity = qty;
                                          orderdetails_list[j].Amount = orderdetails_list[j].Quantity * orderdetails_list[j].UnitPrice;
                                          orderdetails_list[j].GrandTotal = orderdetails_list[j].Amount - orderdetails_list[j].DiscountAmount;
                                          orderdetails_list[j].ModifiedDate = DateTime.Now;
                                          Console.Write("\nQuantity has been updated--------------->");
                                          state = false;
                                          break;
                                      }
                                  }

                              }
                          }

                      }

                  } while (state);
              }
          
          }

          static void delete_order()
          {
              int temp;
             
              bool state = true;
            
                do
                {
                         bool isEmpty = (!orderdetails_list.Any() && !order_list.Any());
                         if (isEmpty)
                         {
                             Console.WriteLine("There is no record remaining ----------------->");
                             break;
                         }

                         else
                         {

                             Console.Write("\nEnter the order no:");
                             temp = Convert.ToInt32(Console.ReadLine());
                             
                             IList<orderdetails> temp_orderdetails = new List<orderdetails>();

                             foreach (var j in orderdetails_list)
                             {
                                 if (temp == j.Ref_no)
                                 {
                                     temp_orderdetails.Add(j);
                                 }
                             }


                             foreach (var j in temp_orderdetails)
                             {
                                 orderdetails_list.Remove(j);
                             }

                             foreach (var i in order_list)
                             {
                                 if (temp == i.OrderNo)
                                 {
                                     order_list.Remove(i);
                                     Console.Write("\norder no " + temp + " has been deleted---------------->");
                                     state = false;
                                     break;
                                 }

                             }

                         }  


                  } while (state);
              
              }
 
          static void last_order_details()
          {
              bool isEmpty = (orderdetails_list.Count==0 && order_list.Count==0);
              if (isEmpty)
              {
                  Console.WriteLine("There is no record----------------->");
              }
              else
              {
                  Console.WriteLine("Order No.\tProduct No.\tProduct Name\tUnitPrice\tQuantity\tAmount\t     Discount Amount\t\tGrand Total\tCreated Date\t\t\tModified date");
                  
                  order or = order_list[order_list.Count - 1];
                  orderdetails od = orderdetails_list[orderdetails_list.Count - 1];
                  Console.WriteLine(or.OrderNo + "\t\t" + od.ProductDetail.ProductNo + "\t\t" + od.ProductDetail.ProductName + "\t\t" + od.ProductDetail.UnitPrice + "\t\t" + od.Quantity + "\t\t" + od.Amount + "\t\t" + od.DiscountAmount + "     \t\t\t" + od.GrandTotal + "\t\t" + or.CreatedDate + "\t\t" + od.ModifiedDate);
                  
              }
          }

          static void last_order_u_price()
          {
              bool isEmpty = (!orderdetails_list.Any() && !order_list.Any());
              if (isEmpty)
              {
                  Console.WriteLine("There is no record----------------->");
              }
              else
              {
                  Console.WriteLine("Order No.\tProduct No.\tUnitPrice");
                  
                  order or = order_list[order_list.Count - 1];
                  orderdetails od = orderdetails_list[orderdetails_list.Count - 1];
                  Console.WriteLine(or.OrderNo + "\t\t" + od.ProductDetail.ProductNo + "\t\t" + od.ProductDetail.UnitPrice);
                  
              }
          }

          static void last_order_details_cus()
          {
              bool isEmpty = (!orderdetails_list.Any() && !order_list.Any());
              string c1;
              if (isEmpty)
              {
                  Console.WriteLine("There is no record----------------->");
              }
              else
              {
                  do
                  {
                      Console.Write("\nEnter the Customer No. :");
                      c1 = Console.ReadLine();
                  } while (tk.type_c(c1));
                  int cus_no=Convert.ToInt32(c1);
                  for (int i = (order_list.Count-1); i >= 0; i--)
                  {
                      if (cus_no == order_list[i].CustomerDetail.CustomerNo)
                      {
                          order or = order_list[i];
                          Console.WriteLine("Order No.\tProduct No.\tProduct Name\tUnitPrice\tQuantity\tAmount\t     Discount Amount\t\tGrand Total\tCreated Date\t\t\tModified date");
                          for (int j = (orderdetails_list.Count-1); j >= 0 ; j--)
                          {
                              if (orderdetails_list[j].Ref_no == order_list[i].OrderNo)
                              {
                                  orderdetails od = orderdetails_list[j];
                                  Console.WriteLine(or.OrderNo + "\t\t" + od.ProductDetail.ProductNo + "\t\t" + od.ProductDetail.ProductName + "\t\t" + od.ProductDetail.UnitPrice + "\t\t" + od.Quantity + "\t\t" + od.Amount + "\t\t" + od.DiscountAmount + "     \t\t\t" + od.GrandTotal + "\t\t" + or.CreatedDate + "\t\t" + od.ModifiedDate);
                              }
                          }
                      }
                  }
              }
          }

          static void last_order_u_price_pro()
          {
              bool isEmpty = (!orderdetails_list.Any() && !order_list.Any());
              string p1;
              if (isEmpty)
              {
                  Console.WriteLine("There is no record----------------->");
              }
              else
              {
                  do
                  {
                      Console.Write("\nEnter the Product No. :");
                      p1 = Console.ReadLine();
                  } while (tk.type_p(p1));
                  int pro_no = Convert.ToInt32(p1);

                  
                    Console.WriteLine("Product No.\tUnitPrice");

                    for (int j = (orderdetails_list.Count-1); j >=0 ; j--)
                     {
                              if (orderdetails_list[j].ProductDetail.ProductNo == pro_no)
                              {
                                  orderdetails od = orderdetails_list[j];
                                  Console.WriteLine(od.ProductDetail.ProductNo+ "\t\t" + od.ProductDetail.UnitPrice);
                                  break;
                              }
                    }
              }
          }

           static void Main(string[] args)
           
           {

            Program.initaite();

            typechecker tk= new typechecker();
            string n1,n2;
            while (true)
            {
               
                do
                {
                    Console.Write("\n\n\nEnter the option from the following :");
                    Console.Write("\n1. Order Entry\n2. Last order details\n3. last order's unit price\n4. Show order deatils\n5. exit\n6. Last Order unit price by Customer no\n7. Last order product unit price by product no.\n");
                    n1 = Console.ReadLine();
                } while (tk.type_start(n1));
                
                
                switch (Convert.ToInt32(n1))
                { 
                    case 1:

                        do
                        {
                            Console.Write("\n----------------------------------------------:");
                            Console.Write("\n1. Add order\n2. Update order\n3. Delete order");
                            Console.Write("\n----------------------------------------------:\n");
                            n2 = Console.ReadLine();
                        } while (tk.type_start(n2));

                        switch (Convert.ToInt32(n2))
                        { 
                            case 1:
                                add_order();
                                break;
                            case 2:
                                update_order();
                                break;
                            case 3:
                                delete_order();
                                break;
                        }
                        break;

                    case 2:
                        last_order_details();
                        break;
                    case 3:
                        last_order_u_price();
                        break;
                    case 4:
                        show_order();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    case 6:
                        last_order_details_cus();
                        break;
                    case 7:
                        last_order_u_price_pro();
                        break;
                       
                }
               
            }

        }
    }
}