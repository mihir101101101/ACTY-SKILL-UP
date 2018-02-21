using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace skillup_generics
{
    
        public class Typechecker 
        {
            
            public Boolean typeCustomer(string typed)
            {
                Regex ob = new Regex("-?[0-9]");

                if (typed.Equals(""))
                {
                    Console.WriteLine(Constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed))
                    {
                        var c = Program.customerList.Find(s => s.CustomerNo == typed);
                        if (c == null)
                        {

                            Console.WriteLine(Constants.ENTERVALIDCUS);
                            return true;
                        }
                        if (c!=null || typed.Equals("-1"))
                        {
                            return false;
                        }
                        Console.WriteLine(Constants.ENTERVALIDCUS);
                        return true;
                    }
                    else {
                        Console.WriteLine(Constants.ENTERAGAIN);
                        return true;
                    }
                }
            }

            public Boolean typeEmployee(string typed)
            {
                Regex ob = new Regex("-?[0-9]");

                if (typed.Equals(""))
                {
                    Console.WriteLine(Constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed))
                    {
                        var e = Program.employeeList.Find(s => s.EmployeeNo == typed);
                        if (e == null)
                        {
                            Console.WriteLine(Constants.ENTERVALIDEMP);
                            return true;
                        }

                        if (e !=null || typed.Equals("-1"))
                        {
                            return false;
                        }
                        Console.WriteLine(Constants.ENTERVALIDEMP);
                        return true;
                    }

                    else
                    {
                        Console.WriteLine(Constants.ENTERAGAIN);
                        return true; 
                    }
                }
            }

            public Boolean typeProduct(string typed)
            {
                Regex ob = new Regex("^-?[0-9]+$");

                if (typed.Equals(""))
                {
                    Console.WriteLine(Constants.BLANKVALUE);
                    return true;
                }
                else
                {

                    if (ob.IsMatch(typed))
                    {
                        var p = Program.productList.Find(s => s.ProductNo.Equals(typed));
                        if(p == null)
                        {
                            Console.WriteLine(Constants.ENTERVALIDPRO);
                            return true;
                        }
                        if (p !=null || typed.Equals("-1") )
                        {
                            return false;
                        }
                        Console.WriteLine(Constants.ENTERVALIDPRO);
                        return true;
                    }

                    else
                    {
                        Console.WriteLine(Constants.ENTERAGAIN); 
                        return true; }
                }
            }

            public Boolean typeSave(string typed)
            {
                Regex ob = new Regex("^[a-zA-Z]+$");
                if (typed.Equals(""))
                {
                    Console.WriteLine(Constants.BLANKVALUE);
                    return true;
                }

                else
                {
                    if (ob.IsMatch(typed) && typed.Equals("y") || typed.Equals("Y") || typed.Equals("n") || typed.Equals("N") )
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(Constants.ENTERVALID); 
                        return true; }
                }
            }

            public Boolean typeDate(string typed)
            {
                Regex ob = new Regex("^(0[1-9]|[1|2][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)[0-9][0-9]$");

                if (typed.Equals("-1"))
                {
                    return false;
                }
                
                if (typed.Equals(""))
                {
                    Console.WriteLine(Constants.BLANKVALUE);
                    return true;
                }

                else
                {
                   try{
                         if (ob.IsMatch(typed))
                         {
                            Convert.ToDateTime(typed);
                            return false;
                         }
                      }

                   catch(FormatException e)
                   {
                        Console.WriteLine(e.Message + Constants.ENTERVALID);
                       return true;
                   }
                   
                    
                    {
                        Console.WriteLine(Constants.ENTERVALID);
                        return true;
                    }

                }
            }

            public Boolean typeStart(string typed)
            {
                Regex ob = new Regex("^[0-9]+$");
                if (typed.Equals(""))
                {
                    Console.WriteLine(Constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed))
                    {
                        return false;
                    }
                    else {
                        Console.WriteLine(Constants.ONLYNUMERIC);
                        return true; 
                    }
                }

            }

            public Boolean typeSecondStart(string typed)
            {
                Regex ob = new Regex("^-?[0-9]+$");
                if (typed.Equals(""))
                {
                    Console.WriteLine(Constants.BLANKVALUE);
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
                        Console.WriteLine(Constants.ONLYNUMERIC);
                        return true;
                    }
                }
            }

            public bool typeOrder(string typed)
            {
                Regex ob = new Regex("^[-]?[a-zA-Z0-9_]+$");
                if (typed == "")
                {
                   Console.WriteLine(Constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    if (typed.Equals("-1"))
                    {
                        return false;
                    }
                    
                    else if (ob.IsMatch(typed) && typed.Count()<10)
                    {
                        return false;
                    }
                    else if (!ob.IsMatch(typed))
                    {
                        Console.WriteLine(Constants.ALPHANUMERIC);
                    }
                    else
                    {
                        Console.WriteLine(Constants.ORNOLIMIT);   
                    }

                    return true;
                }
               
            }

            public bool typeQuantity(string typed)
            {
                Regex ob = new Regex("^[0-9]+$");
                if (typed == "")
                {
                    Console.WriteLine(Constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    try
                    {
                        if ((Convert.ToDouble(typed) % 1) > 0)
                            Console.WriteLine(Constants.NOTINFRACTION);
                        else if (ob.IsMatch(typed) && Convert.ToInt64(typed) <= 999 && Convert.ToInt64(typed) > 0)
                            return false;
                        else
                            Console.WriteLine(Constants.QUANTITYNOTZERO);
                        return true;
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("\n"+e.Message + "\n" + Constants.ENTERAGAIN);
                        return true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n" + e.Message + "\n" + Constants.ENTERAGAIN);
                        return true;
                    }
                }
            }

            public bool typeDiscount(string typed,double amount)
            {
                Regex ob = new Regex("^[0-9]*([.][0-9]+)?$");
                if (typed.Equals(""))
                {
                    Console.WriteLine(Constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed))
                    {
                        if (amount-(Convert.ToDouble(typed))>=0 && Convert.ToDouble(typed) <= 99999 && Convert.ToDouble(typed) >= 0)
                            return false;
                        else
                        {
                            Console.WriteLine(Constants.DISCOUNTEXCEED + amount);
                            return true; 
                        }
                    }
                    else
                        Console.WriteLine(Constants.ONLYNUMERIC);
                    return true;
                }
            }

            public bool typeAmount(string typed)
            {
                Regex ob = new Regex("^[0-9]*([.][0-9]+)?$");
                if (typed.Equals(""))
                {
                    Console.WriteLine(Constants.ENTERAGAIN);
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed))
                    {
                        
                        if (Convert.ToDouble(typed) <= 99999 && Convert.ToDouble(typed) >= 0)
                            return false;
                        else
                        {
                            Console.WriteLine(Constants.EXCEEDDATA);
                            return true;
                        }
                    }
                    else
                        Console.WriteLine(Constants.ONLYNUMERIC);
                    return true;
                }
            }

            public bool updatedQuantity(double grandtotal)
            {
                if (grandtotal > 0)
                {
                    return false;
                }
                Console.WriteLine(Constants.DISCOUNT);
                return true;
            }

        }
    }

