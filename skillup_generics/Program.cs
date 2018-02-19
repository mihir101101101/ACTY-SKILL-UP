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
            static List<employee> e_list = new List<employee>();
            static List<customer> c_list = new List<customer>();
            static List<order> order_list = new List<order>();
            static List<product> p_list = new List<product>();
            static List<orderdetails> orderdetails_list = new List<orderdetails>();
            static typechecker tk = new typechecker();
            static constants error = new constants();
            static List<orderdetails> temp = new List<orderdetails>();
            static Dictionary<orderdetails, order> mix = new Dictionary<orderdetails, order>();

           static void initaite()
            {
                e_list.Add(new employee() { EmployeeNo = "1", FirstName = "javed", LastName = "singh", Address = "12/g street", City = "vadodara", State = "guj", PostalCode = "390019" });
                e_list.Add(new employee() { EmployeeNo = "2", FirstName = "prasad", LastName = "rajput", Address = "134 amrapali", City = "vadodara", State = "guj", PostalCode = "370019" });
                e_list.Add(new employee() { EmployeeNo = "3", FirstName = "faizal", LastName = "moham", Address = "A501 richmondAp", City = "ahmadabad", State = "guj", PostalCode = "380101" });
                c_list.Add(new customer() { CustomerNo = "10", CustomerName = "mihir", Address = "134 avadhut soc", City = "surat    ", State = "guj",PostalCode = 365010, Country = "India" });
                c_list.Add(new customer() { CustomerNo = "11", CustomerName = "kevin", Address = "26 Jalaram soc", City = "surat    ", State = "guj", PostalCode = 365010, Country = "India" });
                c_list.Add(new customer() { CustomerNo = "12", CustomerName = "pratik", Address = "F/56 nandji soc", City = "vadodara", State = "guj", PostalCode = 390016, Country = "India" });
                p_list.Add(new product() { ProductNo = "23", ProductName = "gas", UnitPrice = 32.50 , IsActive= true});
                p_list.Add(new product() { ProductNo = "24", ProductName = "paper", UnitPrice = 5.0 , IsActive =true});
                p_list.Add(new product() { ProductNo = "36", ProductName = "bat", UnitPrice = 120 , IsActive= true});
                p_list.Add(new product() { ProductNo = "99", ProductName = "RC Car", UnitPrice = 850, IsActive = false });
            }

           static void print_emp_details()
           {
               Console.WriteLine(constants.EMPLOYEEDETAILS);
               for(int i=0 ; i < e_list.Count ; i++)
                   Console.WriteLine(e_list[i]);
           }

           static void print_cus_details()
           {
               Console.WriteLine(constants.CUSTOMERDETAILS);
               for(int i=0;i<c_list.Count;i++)
                   Console.WriteLine(c_list[i]);
               
           }

           static void print_pro_details()
           {
               Console.WriteLine(constants.PRODUCTDETAILS);
               for (int i = 0; i < p_list.Count ; i++ )
                   Console.WriteLine(p_list[i]);
           
           }

           static employee add_emploee()
           {
               print_emp_details();
               string employee_no;
               
               do
               {
                   Console.Write(constants.ENTEREMPLOYEENO);
                   employee_no = Console.ReadLine();
               } while (tk.type_e(employee_no));
               
               
               if (employee_no == "-1")
               {
                   return null;
               }
               else
               {
                   var e = e_list.Find(s => s.EmployeeNo == employee_no);
                   //for (int i = 0; i < e_list.Count; i++)
                   //{
                   //    employee e = e_list[i];
                   //    if (e.EmployeeNo == employee_no)
                   //        return e_list[i];
                   //}
                   return e;
               }
           }

           static customer add_customer()
           {
               print_cus_details();
               string CustomerNo;
               do
               {
                   Console.Write(constants.ENTERCUSTOMERNO);
                   CustomerNo = Console.ReadLine();
               } while (tk.type_c(CustomerNo));

               if (CustomerNo == "-1")
               {
                   return null;
               }
               else
               {
                   for (int i = 0; i < c_list.Count; i++)
                   {
                       customer c = c_list[i];
                       if (c.CustomerNo == CustomerNo)
                           return c_list[i];
                   }
               }
               return add_customer();
           }

           static product add_product()
           {
               
               print_pro_details();
               
               string p_no;
               do
               {
                   Console.Write(constants.ENTERPRODUCTNO);
                   p_no = Console.ReadLine();
               } while (tk.type_p(p_no));

               if (p_no == "-1")
               {
                   return null;
               }

               for (int i = 0; i < p_list.Count; i++)
               {

                   if (p_list[i].ProductNo == p_no)
                   {
                       if (p_list[i].IsActive == true)
                           return p_list[i];
                       else { Console.WriteLine(constants.AVAILABLE); }
                   }
                  
               }
               return add_product();

           }

           static public bool order_again(string o_no)
           {
           
                for (int i = 0; i < order_list.Count; i++)
                   {
                       if (o_no == order_list[i].OrderNo)
                       {
                           Console.Write(constants.EXIST);
                           return true;
                       }
               
                   }
                return false;
           }

          static public int ? add_order()
          {
               order o1 = new order();
               string o_no;
              
               do
               {
                   do
                   {
                       Console.Write(constants.ENTERORDERNO);
                       o_no = Console.ReadLine();
                   } while (tk.type_o(o_no));
                  

               } while (order_again(o_no));

               if (o_no == "-1")
               {
                   return null;
               }

               customer c = add_customer();
               
              if (c == null)
              {
                  return null;
              }
              
              employee e = add_emploee();

              if (e == null)
              {
                  return null;
              }

                       
                           string date, save;
                           bool state = true;
                           o1.OrderNo = o_no;
                           o1.CustomerDetail = c;
                           o1.EmployeeDetail = e;
                            
                           do
                           {
                               Console.Write("\nEnter order Date: in(dd/mm/yyyy) format: ");
                               date = Console.ReadLine();

                           } while (tk.type_date(date));
                           if (date == "-1")
                           {
                               return null;
                           }
                           o1.OrderDate = Convert.ToDateTime(date);
                           o1.ShipName = c.CustomerName;
                           o1.ShipAddress = c.Address;
                           o1.ShipCity = c.City;
                           o1.ShipState = c.State;
                           o1.ShipPostalCode = c.PostalCode;
                           o1.ShipCountry = c.Country;
                           o1.CreatedDate = DateTime.Now;
                           o1.ModifiedDate = DateTime.Now;

                           //order_list.Add(o1);

                            

                           string key;
                           do
                           {
                               orderdetails o2 = new orderdetails();
                               string q1;
                               bool flag = true;
                               product p1 = add_product();

                               if (p1 == null)
                               {
                                   order_list.Remove(order_list[order_list.Count-1]);
                                   return null; 
                               }

                               do
                               {
                                   Console.Write(constants.ENTERPRICE);
                                   q1 = Console.ReadLine();
                                   if (q1 == "")
                                   {
                                       flag = false;
                                       break;
                                   }

                               } while (tk.type_amount(q1));
                               if (q1 == "-1")
                               {
                                   order_list.Remove(order_list[order_list.Count-1]);
                                   return null;
                               }

                               if (flag == true)
                               {
                                   o2.UnitPrice = Convert.ToDouble(q1);
                               }
                               else
                               {
                                   o2.UnitPrice = p1.UnitPrice;
                               }
                               do
                               {
                                   Console.Write(constants.ENTERQUANTITY);
                                   q1 = Console.ReadLine();
                               } while (tk.type_q(q1));

                               if (q1 == "-1")
                               {
                                   order_list.Remove(order_list[order_list.Count-1]);
                                   return null;
                               }
                               o2.Quantity = Convert.ToInt32(q1);

                               o2.Amount = o2.Quantity * o2.UnitPrice;

                               
                                   do
                                   {
                                       Console.Write(constants.ENTERDISCOUNT);
                                       q1 = Console.ReadLine();
                                   } while (tk.type_dis(q1,o2.Amount));
                                   if (q1 == "-1")
                                   {
                                       order_list.Remove(order_list[order_list.Count-1]);
                                       return null; 
                                   }
                               
                               o2.DiscountAmount = Convert.ToDouble(q1);
                               o2.GrandTotal = o2.Amount - o2.DiscountAmount;
                              

                               o2.CreatedDate = o1.CreatedDate;
                               o2.ModifiedDate = o1.CreatedDate;
                               //o2.Ref_no = o_no;
                               o2.ProductDetail = p1;
                               //orderdetails_list.Add(o2);
                               temp.Add(o2);

                               show_order(temp);

                               do
                               {
                                   Console.Write(constants.ADDMORE);
                                   key = Console.ReadLine().ToLower();
                               } while (tk.type_save(key));

                               
                           } while (!key.Equals("n"));


                           do
                           {
                               Console.Write(constants.SAVE);
                               save = Console.ReadLine();
                           }while(tk.type_save(save));

                               if (save == "Y" || save == "y")
                               {
                                   //do nothing
                                   foreach(var p in temp)
                                   {
                                       orderdetails_list.Add(p);
                                       mix.Add(p, o1);
                                   }
                                  
                                   order_list.Add(o1);
                                   Console.Write(constants.SAVEDORDER);
                                   state = false;
                                   temp.Clear();



                                   foreach (orderdetails pair in temp)
                                   {
                                       mix.Add(pair, o1);
                                   }

                               }
                               if (save == "N" || save == "n")
                               {

                                   temp.Clear();
                                   state = false;
                               }
          

              
                            while (state);

                           return -1;

               
           }


          static void show_order(List<orderdetails> temp=null)
          {

              if (temp == null)
              {

                  bool isEmpty = !mix.Any();
                  if (isEmpty)
                  {
                      Console.WriteLine(constants.NODATA);
                  }
                  else
                  {
                      Console.WriteLine("\nOrder No.\tProduct No.\tProduct Name\tUnitPrice\tQuantity\tAmount\t\tDiscount Amount\t\tGrand Total\tCreated Date\t\t\tModified date");
                      foreach (KeyValuePair<orderdetails, order> pair in mix)
                      {


                          Console.WriteLine(pair.Value.OrderNo + "\t\t" + pair.Key.ProductDetail.ProductNo + "\t\t" + pair.Key.ProductDetail.ProductName + "\t\t" + String.Format("{0:0.00}", pair.Key.UnitPrice) + "\t\t" + pair.Key.Quantity + "\t\t" + String.Format("{0:0.00}", pair.Key.Amount) + "\t\t\t\t" + String.Format("{0:0.00}", pair.Key.DiscountAmount) + "\t\t" + String.Format("{0:0.00}", pair.Key.GrandTotal) + "\t\t" + pair.Key.CreatedDate + "\t\t" + pair.Key.ModifiedDate);


                      }


                  }
              }

              else
              {
                  Console.WriteLine("Product No.\tProduct Name\tUnitPrice\tQuantity\tAmount\t\tDiscount Amount\t\tGrand Total\tCreated Date\t\t\tModified date");
                  foreach (var i in temp)
                  {
                      Console.WriteLine(i.ProductDetail.ProductNo + "\t\t" + i.ProductDetail.ProductName + "\t\t" + String.Format("{0:0.00}", i.UnitPrice) + "\t\t" + i.Quantity + "\t\t" + String.Format("{0:0.00}", i.Amount) + "\t\t\t\t" + String.Format("{0:0.00}", i.DiscountAmount) + "\t\t" + String.Format("{0:0.00}", i.GrandTotal) + "\t\t" + i.CreatedDate + "\t\t" + i.ModifiedDate);
                  
                  }
              
              
              }
          }

          static void show_all_details()
          {
              bool isEmpty = (!orderdetails_list.Any() && !order_list.Any());
              if (isEmpty)
              {
                  Console.WriteLine(constants.NODATA);
              }
              else
              {

                  Console.WriteLine("OrderNO.\tEmployeeNO.\tFirstName\tCustomerNO.\tCustomerName\tShipAddress\t        ProductNo.\tProductName\tUnitPrice\tAmount\tDiscountAmount\tGrandTOtal");
                  for (int i = 0; i < order_list.Count; i++)
                  {
                      
                      for (int j = 0; j < orderdetails_list.Count; j++)
                      {
                          //if(order_list[i].OrderNo==orderdetails_list[j].Ref_no)
                          Console.Write(order_list[i]+"\t"+orderdetails_list[j]);
                      }
                  }
              }
          }

          static void update_order()
          {
              int quantity=0;
              string save;
              double amount=0, grandtotal=0;
              string qty;
              string temp="", temp2="";
              bool state = true;
              bool flas1 = true;
              bool flas2 = false;
              bool isEmpty = (!mix.Any());
              DateTime m=DateTime.Now;
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
                      } while (tk.type_o(temp));

                      
                      


                      foreach (KeyValuePair<orderdetails, order> pair in mix)
                      {
                          flas1 = true;
                          if (temp == pair.Value.OrderNo)
                          {
                              flas1 = false;
                              do
                              {
                                  Console.Write(constants.ENTERPRODUCTNO + " for which qty needs to be update : ");
                                  temp2 = Console.ReadLine();
                              } while (tk.type_p(temp2));

                              
                              
                                  
                                  foreach (KeyValuePair<orderdetails, order> pair2 in mix)
                                  {
                                                         
                           
                                              if (pair2.Key.ProductDetail.ProductNo == temp2)
                                              {
                                                  do
                                                  {
                                                      Console.Write(constants.ENTERQUANTITY);
                                                      qty = Console.ReadLine();
                                                  } while (tk.type_q(qty));

                                                  quantity = Convert.ToInt32(qty);
                                                  amount = quantity * pair2.Key.UnitPrice;
                                                  grandtotal = amount - pair2.Key.DiscountAmount;
                                                  m = DateTime.Now;
                                                  Console.Write(constants.UPDATEQUANTITY);
                                                  Console.WriteLine("\nOrder No.\tProduct No.\tProduct Name\tUnitPrice\tQuantity\tAmount\t\tDiscount Amount\t\tGrand Total\tCreated Date\t\t\tModified date");
                                                  Console.WriteLine(pair2.Value.OrderNo + "\t\t" + pair2.Key.ProductDetail.ProductNo + "\t\t" + pair2.Key.ProductDetail.ProductName + "\t\t" + String.Format("{0:0.00}", pair2.Key.UnitPrice) + "\t\t" + quantity + "\t\t" + String.Format("{0:0.00}", amount) + "\t\t\t\t" + String.Format("{0:0.00}", pair2.Key.DiscountAmount) + "\t\t" + String.Format("{0:0.00}", grandtotal) + "\t\t" + pair2.Key.CreatedDate + "\t\t" + m);
                                                  do
                                                  {
                                                      Console.WriteLine(constants.SAVE);
                                                      save = Console.ReadLine();
                                                  } while (tk.type_save(save));

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
                                                           break;
                                                     }
                                              }

                                             


                                  }

                                  if(flas2==false)
                                  {
                                      Console.WriteLine(temp2+constants.NOTEXIST);
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
                             

                      }while (state);

                 

                  }


           }

         
          
          static void delete_order(string ord_no = "0")
          {


              Dictionary<orderdetails, order> temp_delete = new Dictionary<orderdetails, order>();

                  string temp;

                  bool state = true;
                  string type_checker;

                  do
                  {
                      bool isEmpty = (!mix.Any());
                      if (isEmpty)
                      {
                          Console.WriteLine(constants.NODATAREMAINING);
                          break;
                      }

                      else
                      {
                          show_order();
                          do
                          {
                              Console.Write(constants.ENTERORDERNO);
                              type_checker = Console.ReadLine();
                          } while (tk.type_o(type_checker));

                          temp = type_checker;
                          bool f = false;
                          
                          do
                          {
                              f = false;
                              
                              foreach (KeyValuePair<orderdetails, order> pair in mix)
                              {
                                  
                                  if (temp == pair.Value.OrderNo)
                                  {
                                      
                                      temp_delete.Add(pair.Key, pair.Value);
                                      //flagger = true;

                                  }

                              }

                              Console.Write("\nDo you want to delete " + temp + " No. details-------------------> (Y/N) : ");
                              type_checker = Console.ReadLine();
                              if (type_checker == "y" || type_checker == "Y")
                              {

                                  foreach (KeyValuePair<orderdetails, order> pair in temp_delete)
                                  {
                                      mix.Remove(pair.Key);
                                  }


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


                          } while (f);

                          if (!f)
                          {
                              break;
                          }
                         }

                  } while (state);
                  
          
          }

          static void last_order_details()
          {
              bool isEmpty = (orderdetails_list.Count==0 && order_list.Count==0);
              if (isEmpty)
              {
                  Console.WriteLine(constants.NODATA);
              }
              else
              {
                  Console.WriteLine(constants.DETAILS);    
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
                  Console.WriteLine(constants.NODATA);
              }
              else
              {
                  Console.WriteLine("Order No.\tProduct No.\tUnitPrice");
                  
                  order or = order_list[order_list.Count - 1];
                  orderdetails od = orderdetails_list[orderdetails_list.Count - 1];
                  Console.WriteLine(or.OrderNo + "\t\t" + od.ProductDetail.ProductNo + "\t\t" + od.ProductDetail.UnitPrice);
                  
              }
          }

          //static void last_order_details_cus()
          //{
          //    bool isEmpty = (!orderdetails_list.Any() && !order_list.Any());
          //    bool IsExist = true;
          //    string CustomerNo;
          //    if (isEmpty)
          //    {
          //        Console.WriteLine(Lotsoferrors.Nodata);
          //    }
          //    else
          //    {
          //        do
          //        {
          //            Console.Write(Lotsoferrors.EnterCustomerNo);
          //            CustomerNo = Console.ReadLine();
          //        } while (tk.type_c(CustomerNo));
                  
          //        for (int i = (order_list.Count-1); i >= 0; i--)
          //        {
          //            if (CustomerNo == order_list[i].CustomerDetail.CustomerNo)
          //            {
          //                order or = order_list[i];
          //                Console.WriteLine(Lotsoferrors.Details);
          //                for (int j = (orderdetails_list.Count-1); j >= 0 ; j--)
          //                {
          //                    if (orderdetails_list[j].OrderRef.OrderNo == order_list[i].OrderNo)
          //                    {
          //                        orderdetails od = orderdetails_list[j];
          //                        Console.WriteLine(or.OrderNo + "\t\t" + od.ProductDetail.ProductNo + "\t\t" + od.ProductDetail.ProductName + "\t\t" + od.ProductDetail.UnitPrice + "\t\t" + od.Quantity + "\t\t" + od.Amount + "\t\t" + od.DiscountAmount + "     \t\t\t" + od.GrandTotal + "\t\t" + or.CreatedDate + "\t\t" + od.ModifiedDate);
          //                        break;
          //                    }
          //                }
          //                IsExist = false;
          //            }
          //        }
          //        if (IsExist == true)
          //        {
          //            Console.WriteLine(CustomerNo + Lotsoferrors.NotExist);
          //        }
          //    }
          //}

          static void last_order_u_price_pro()
          {
              bool isEmpty = (!mix.Any());
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
                  } while (tk.type_p(ProductNo));
                  
                    Console.WriteLine("Product No.\tUnitPrice");

                    mix.Reverse();

                    foreach (KeyValuePair<orderdetails, order> pair in mix)
                    {
                        if (ProductNo == pair.Key.ProductDetail.ProductNo)
                        { 
                            
                        }
                    
                    }

                    //for (int j = (orderdetails_list.Count-1); j >=0 ; j--)
                    // {
                    //     if (orderdetails_list[j].ProductDetail.ProductNo == ProductNo)
                    //          {
                    //              orderdetails od = orderdetails_list[j];
                    //              Console.WriteLine(od.ProductDetail.ProductNo+ "\t\t" + od.UnitPrice);
                    //              IsExist = false;
                    //              break;
                    //          }

                    //}
                    if (IsExist == true)
                        Console.WriteLine(ProductNo + constants.NOTEXIST);
                    
              }
          }

          static void Main(string[] args)
           
           {

            Program.initaite();
            bool internal_switch=true;
            typechecker tk= new typechecker();
            string n1,n2;
            while (true)
            {
               
                do
                {
                    Console.Write("\n\n\nEnter the option from the following :");
                    Console.Write("\n1. Order Entry\n2. Last order details\n3. last order's unit price\n4. Show order deatils\n5. Last Order details by Customer no\n6. Last order product unit price by product no.\n7. Show all details of Order\n8. exit\nEnter Option from above:  ");
                    n1 = Console.ReadLine();
                } while (tk.type_start(n1));
                
                
                switch (Convert.ToInt32(n1))
                { 
                    case 1:
                        do
                        {
                            do
                            {
                                Console.Write("\n----------------------------------------------:");
                                Console.Write("\n1. Add order\n2. Update order\n3. Delete order\n4. (-1) for Revert Back in Any data entry");
                                Console.Write("\n----------------------------------------------:\n\nEnter Option from above:  ");
                           
                                n2 = Console.ReadLine();
                            } while (tk.type_second_start(n2));

                                switch (Convert.ToInt32(n2))
                                { 
                                case 1:
                                    int ? p=add_order();
                                    if (p == null)
                                    {
                                        internal_switch = true;
                                    }
                                    break;
                                case 2:
                                    update_order();
                                    internal_switch = false;
                                    break;
                                case 3:
                                    delete_order();
                                    internal_switch = false;
                                    break;
                                case -1:
                                    internal_switch = false;
                                    break;
                                }

                        }while(internal_switch);

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
                    case 8:
                        Environment.Exit(0);
                        break;
                    case 5:
                        //last_order_details_cus();
                        break;
                    case 6:
                        last_order_u_price_pro();
                        break;
                    case 7:
                        show_all_details();
                        break;
                       
                }
               
            }

        }
    }
}