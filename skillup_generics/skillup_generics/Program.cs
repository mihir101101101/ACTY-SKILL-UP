using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace skillup_generics
{

   public class typechecker
    {
        public Boolean type_c(string typed)
        {
            Regex ob = new Regex("[^0-9]");

            if (typed == "")
            {
                return true;
            }
            else
            {

                if (ob.IsMatch(typed))
                {
                    return true;
                }
                else if (Convert.ToInt32(typed) == 10 || Convert.ToInt32(typed) == 11 || Convert.ToInt32(typed) == 12)
                {
                    return false;
                }
                else { return true; }
            }
        }

        public Boolean type_e(string typed)
        {
            Regex ob = new Regex("[^0-9]");

            if (typed == "")
            {
                return true;
            }
            else
            {

                if (ob.IsMatch(typed))
                {
                    return true;
                }
                else if (Convert.ToInt32(typed) == 1 || Convert.ToInt32(typed) == 2 || Convert.ToInt32(typed) == 3)
                {
                    return false;
                }
                else { return true; }
            }
        }

        public Boolean type_p(string typed)
        {
            Regex ob = new Regex("[^0-9]");

            if (typed == "")
            {
                return true;
            }
            else
            {

                if (ob.IsMatch(typed))
                {
                    return true;
                }
                else if (Convert.ToInt32(typed) == 23 || Convert.ToInt32(typed) == 24 || Convert.ToInt32(typed) == 36 || typed=="99")
                {
                    return false;
                }
                else { return true; }
            }
        }

        public Boolean type_save(string typed)
        {
            Regex ob = new Regex("[^0-9]");
            if (typed == "")
            {
                Console.WriteLine("Invalid Input: (Enter valid Input) ");
                return true;
            }

            else
            {

                if (ob.IsMatch(typed))
                {
                    return true;
                }
                else if (Convert.ToInt32(typed) == 1 || Convert.ToInt32(typed) == 0)
                {
                    return false;
                }
                else { return true; }
            }
        }

        public Boolean type_date(string typed)
        {
            Regex ob = new Regex("^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)[0-9][0-9]");
            if (typed == "")
            {
                Console.WriteLine("Invalid Input: (Enter valid Input) ");
                return true;
            }

            else
            {

                if (ob.IsMatch(typed))
                {
                    return false;
                }
                else 
                { 
                    return true; 
                }

            }
        }

        public Boolean type_start(string typed)
        {
            Regex ob = new Regex("[^0-9]");
            if (typed == "")
            {
                Console.WriteLine("Enter Again--------------->");
                return true;
            }
            else
            {

                if (ob.IsMatch(typed))
                {
                    return true;
                }
                else if (Convert.ToInt32(typed) == 1 || Convert.ToInt32(typed) == 2 || Convert.ToInt32(typed) == 3 || Convert.ToInt32(typed) == 4 || typed == "5" || typed=="6" || typed=="7")
                {
                    return false;
                }
                else { return true; }
            }
        
        }

        public bool type_o(string typed)
        {
            Regex ob = new Regex("[^0-9]");
            if (typed == "")
            {
                Console.WriteLine("Enter Again--------------->");
                return true;
            }
            else 
            {
                if (!ob.IsMatch(typed) && Convert.ToInt64(typed)<= 999999)
                    return false;
                else
                    return true;
            }
        }

        public bool type_q(string typed)
        {
            Regex ob = new Regex("^[0-9]?");
            if (typed == "")
            {
                Console.WriteLine("Enter Again--------------->");
                return true;
            }
            else
            {
                if (ob.IsMatch(typed) && Convert.ToInt64(typed) <= 999 && Convert.ToInt64(typed) > 0)
                    return false;
                else
                    return true;
            }
        }

        public bool type_dis(string typed)
        {
            Regex ob = new Regex("^[0-9]*([.][0-9]+)?$");
            if (typed == "")
            {
                Console.WriteLine("Enter Again--------------->");
                return true;
            }
            else
            {
                if (ob.IsMatch(typed))
                {
                    if (Convert.ToDouble(typed) <= 99999 && Convert.ToDouble(typed) >= 0)
                        return false;
                    else { return true; }
                }
                else
                    Console.WriteLine("Enter Again--------------->");
                    return true;
            }
        }
    }

    class order
    {
        public employee emp;
        public customer cust;
        public int or_no;
        public DateTime or_date;
        public string s_name,s_add,s_city,s_sate,s_con;
        public int s_pcode;
        public DateTime c_date,m_date;

    }
        
    class orderdetails
    {
        public product pro;
        public int ref_or_no;
        public int quan;
        public double amount,u_price;
        public double gt;
        public double dis;
        public DateTime c_date, m_date;
        
    }

    class employee
    {
        public int emp_no,emp_p;
        public string emp_fname,emp_lname,emp_add,emp_city,emp_s;
    }

    class customer
    {
        public int c_no,c_pcode;
        public string c_name,c_add,c_city,c_state,c_con;
    }

    class product
    {
        public int p_no;
        public string p_name;
        public double unit_p;
        public bool IsActive;

    }

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
                e_list.Add(new employee() { emp_no = 1, emp_fname = "javed", emp_lname = "singh", emp_add = "12/g street", emp_city = "vadodara", emp_s = "guj", emp_p = 390019 });
                e_list.Add(new employee() { emp_no = 2, emp_fname = "prasad", emp_lname = "rajput", emp_add = "134 amrapali", emp_city = "vadodara", emp_s = "guj", emp_p = 370019 });
                e_list.Add(new employee() { emp_no = 3, emp_fname = "faizal", emp_lname = "moham", emp_add = "A501 richmondAp", emp_city = "ahmadabad", emp_s = "guj", emp_p = 380101 });
                c_list.Add(new customer() { c_no = 10, c_name = "mihir", c_add = "134 avadhut soc", c_city = "surat    ", c_state = "guj",c_pcode = 365010, c_con = "India" });
                c_list.Add(new customer() { c_no = 11, c_name = "kevin", c_add = "26 Jalaram soc", c_city = "surat    ", c_state = "guj", c_pcode = 365010, c_con = "India" });
                c_list.Add(new customer() { c_no = 12, c_name = "pratik", c_add = "F/56 nandji soc", c_city = "vadodara", c_state = "guj", c_pcode = 390016, c_con = "India" });
                p_list.Add(new product() { p_no = 023, p_name = "gas", unit_p = 32.50 , IsActive= true});
                p_list.Add(new product() { p_no = 024, p_name = "paper", unit_p = 5.0 , IsActive =true});
                p_list.Add(new product() { p_no = 036, p_name = "bat", unit_p = 120 , IsActive= true});
                p_list.Add(new product() { p_no = 099, p_name = "RC Car", unit_p = 850, IsActive = false });
            }

           static void print_emp_details()
           {
               Console.WriteLine("\n\nEmployee No.\tFirst Name\tLast Name\tAddress\t\t\tCity\t\tState\tPostal Code");
               foreach (var i in e_list)
               {
                   Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t{5}\t{6}", i.emp_no, i.emp_fname,i.emp_lname,i.emp_add,i.emp_city,i.emp_s,i.emp_p);
               }

           }

           static void print_cus_details()
           {
               Console.WriteLine("\n\nCustomer No.\tCustomer Name\tAddress\t\t\tCity\t\tState\t\tPostal Code\t\tCountry");
               foreach (var i in c_list)
               {
                   Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t{4}\t\t{5}\t\t     {6}", i.c_no, i.c_name,i.c_add,i.c_city,i.c_state,i.c_pcode,i.c_con);
               }
           }

           static void print_pro_details()
           {
               Console.WriteLine("\n\nProduct No.\tProduct Name\tProduct Unit Prize\tIsAvailable");
               foreach (var i in p_list)
               {
                   Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t\t{3}", i.p_no, i.p_name, i.unit_p,i.IsActive);
               }
           
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
                   if (e.emp_no == e_no)
                       return e_list[i];
               }
               return add_emploee();
           
           }

           static customer add_customer()
           {
               print_cus_details();
               string c1;
               int c_no;
               do
               {
                   Console.Write("\nEnter customer No:");
                   c1 = Console.ReadLine();
               } while (tk.type_c(c1));

               c_no = Convert.ToInt32(c1);
               for (int i = 0; i < c_list.Count; i++)
               {
                   customer c = c_list[i];
                   if (c.c_no == c_no)
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

                   if (p_list[i].p_no == p_no)
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
                   if (o_no == order_list[i].or_no)
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


                o1.or_no = o_no;
                o1.cust = c;
                o1.emp = e;
                do
                {
                    Console.Write("\nEnter order Date: in(dd/mm/yyyy) format: ");
                    date = Console.ReadLine();

                } while (tk.type_date(date));

                o1.or_date = Convert.ToDateTime(date);
                o1.s_name = c.c_name;
                o1.s_add = c.c_add;
                o1.s_city = c.c_city;
                o1.s_sate = c.c_state;
                o1.s_pcode = c.c_pcode;
                o1.s_con = c.c_con;
                o1.c_date = DateTime.Now;
                o1.m_date = DateTime.Now;
                
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
                      o2.u_price = Convert.ToDouble(q1);
                  }
                  else {
                      o2.u_price = p1.unit_p;
                  }
                  do{
                     Console.Write("\nEnter the product quantity :");
                     q1 = Console.ReadLine();
                  }while(tk.type_q(q1));

                     
                  o2.quan = Convert.ToInt32(q1);
                  
                  o2.amount = o2.quan * o2.u_price;

                    do{
                    Console.Write("\nEnter the discount amount : ");
                    q1 = Console.ReadLine();
                    }while(tk.type_dis(q1));

                  o2.dis = Convert.ToDouble(q1);
                  o2.gt = o2.amount - o2.dis;
                  o2.c_date = o1.c_date;
                  o2.m_date = DateTime.Now;
                  o2.ref_or_no = o_no;
                  o2.pro = p1;

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
                         if (o_no == order_list[i].or_no)
                         {
                             for (int j = 0; j < orderdetails_list.Count; j++)
                             {
                                 if (o_no == orderdetails_list[i].ref_or_no)
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
                      int order_no = or.or_no;

                      for (int i = 0; i < orderdetails_list.Count; i++)
                      {
                          orderdetails od = orderdetails_list[i];
                          if (order_no == od.ref_or_no)
                          {
                              Console.WriteLine(or.or_no + "\t\t" + od.pro.p_no + "\t\t" + od.pro.p_name + "\t\t" + od.u_price + "\t\t" + od.quan + "\t\t" + od.amount + "\t\t" + od.dis + "     \t\t\t" + od.gt + "\t\t" + or.c_date + "\t\t" + od.m_date);
                          }


                      }

                  }
              }
          }

          static void update_order()
          {
              int temp,temp2,qty;
              bool state=true;
              do
              {
              Console.Write("\nEnter the order no: ");
              temp = Convert.ToInt32(Console.ReadLine());
              for (int i = 0; i < order_list.Count; i++)
              {
                  
                  if (temp == order_list[i].or_no)
                  {
                        while (state)
                        {
                              Console.Write("\nEnter the product no for which qty needs to be update : ");
                              temp2 = Convert.ToInt32(Console.ReadLine());
                              for (int j = 0; j < orderdetails_list.Count; j++)
                              {
                                if (temp2 == orderdetails_list[j].pro.p_no && temp == orderdetails_list[j].ref_or_no)
                                {
                                  Console.Write("\nEnter the qty: ");
                                  qty = Convert.ToInt32(Console.ReadLine());
                                  orderdetails_list[j].quan = qty;
                                  orderdetails_list[j].amount = orderdetails_list[j].quan * orderdetails_list[j].u_price;
                                  orderdetails_list[j].gt = orderdetails_list[j].amount - orderdetails_list[j].dis;
                                  orderdetails_list[j].m_date = DateTime.Now;
                                  Console.Write("\nQuantity has been updated--------------->");
                                  state = false;
                                  break;
                                 }
                              }
                              
                         }
                  }
                   
              }

              }while(state);
          
          }

          static void delete_order()
          {
              int temp;
              bool state = true;
              do
              {
                  Console.Write("\nEnter the order no:");
                  temp = Convert.ToInt32(Console.ReadLine());
                  for (int i = 0; i < order_list.Count; i++)
                  {
                      if (temp == order_list[i].or_no)
                      {
                          for (int j = 0; j < orderdetails_list.Count; j++)
                          {
                              if (temp == orderdetails_list[i].ref_or_no)
                              {
                                  orderdetails_list.Remove(orderdetails_list[i]);

                              }
                          }
                          order_list.Remove(order_list[i]);
                          state = false;
                          break;
                      }
                      else {
                          Console.WriteLine("Enter valid Order NO :----------->");
                          state = true;
                      }
                  }


              } while (state);
          
          }

          static void last_order_details()
          {
              bool isEmpty = (!orderdetails_list.Any() && !order_list.Any());
              if (isEmpty)
              {
                  Console.WriteLine("There is no record----------------->");
              }
              else
              {
                  Console.WriteLine("Order No.\tProduct No.\tProduct Name\tUnitPrice\tQuantity\tAmount\t     Discount Amount\t\tGrand Total\tCreated Date\t\t\tModified date");
                  
                  order or = order_list[order_list.Count - 1];
                  orderdetails od = orderdetails_list[orderdetails_list.Count - 1];
                  Console.WriteLine(or.or_no + "\t\t" + od.pro.p_no + "\t\t" + od.pro.p_name + "\t\t" + od.pro.unit_p + "\t\t" + od.quan + "\t\t" + od.amount + "\t\t" + od.dis + "     \t\t\t" + od.gt + "\t\t" + or.c_date + "\t\t" + od.m_date);
                  
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
                  Console.WriteLine(or.or_no + "\t\t" + od.pro.p_no + "\t\t" + od.pro.unit_p);
                  
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
                      if (cus_no == order_list[i].cust.c_no)
                      {
                          order or = order_list[i];
                          Console.WriteLine("Order No.\tProduct No.\tProduct Name\tUnitPrice\tQuantity\tAmount\t     Discount Amount\t\tGrand Total\tCreated Date\t\t\tModified date");
                          for (int j = (orderdetails_list.Count-1); j >= 0 ; j--)
                          {
                              if (orderdetails_list[j].ref_or_no == order_list[i].or_no)
                              {
                                  orderdetails od = orderdetails_list[j];
                                  Console.WriteLine(or.or_no + "\t\t" + od.pro.p_no + "\t\t" + od.pro.p_name + "\t\t" + od.pro.unit_p + "\t\t" + od.quan + "\t\t" + od.amount + "\t\t" + od.dis + "     \t\t\t" + od.gt + "\t\t" + or.c_date + "\t\t" + od.m_date);
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
                              if (orderdetails_list[j].pro.p_no == pro_no)
                              {
                                  orderdetails od = orderdetails_list[j];
                                  Console.WriteLine(od.pro.p_no + "\t\t" + od.pro.unit_p);
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