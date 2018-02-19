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
            
            public Boolean typeCustomer(string typed)
            {
                Regex ob = new Regex("-?[0-9]");

                if (typed == "")
                {
                    Console.WriteLine(constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed))
                    {
                        if (typed == "10" || typed == "11" || typed == "12" || typed == "-1")
                        {
                            return false;
                        }
                        Console.WriteLine(constants.ENTERVALID);
                        return true;
                    }
                    else {
                        Console.WriteLine(constants.ENTERAGAIN);
                        return true;
                    }
                }
            }

            public Boolean typeEmployee(string typed)
            {
                Regex ob = new Regex("-?[0-9]");

                if (typed == "")
                {
                    Console.WriteLine(constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed))
                    {
                        if (typed == "1" || typed == "2" || typed == "3" || typed=="-1")
                        {
                            return false;
                        }
                        Console.WriteLine(constants.ENTERVALID);
                        return true;
                    }

                    else
                    {
                        Console.WriteLine(constants.ENTERAGAIN);
                        return true; 
                    }
                }
            }

            public Boolean typeProduct(string typed)
            {
                Regex ob = new Regex("^-?[0-9]+$");

                if (typed == "")
                {
                    Console.WriteLine(constants.BLANKVALUE);
                    return true;
                }
                else
                {

                    if (ob.IsMatch(typed))
                    {
                        if (typed == "23" || typed == "24" || typed == "36" || typed == "99" || typed == "-1" )
                        {
                            return false;
                        }
                        Console.WriteLine(constants.ENTERVALID);
                        return true;
                    }

                    else
                    {
                        Console.WriteLine(constants.ENTERAGAIN); 
                        return true; }
                }
            }

            public Boolean typeSave(string typed)
            {
                Regex ob = new Regex("^[a-zA-Z]+$");
                if (typed == "")
                {
                    Console.WriteLine(constants.BLANKVALUE);
                    return true;
                }

                else
                {
                    if (ob.IsMatch(typed) && typed == "y" || typed== "Y" || typed == "n" || typed == "N" )
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(constants.ENTERVALID); 
                        return true; }
                }
            }

            public Boolean typeDate(string typed)
            {
                Regex ob = new Regex("^(0[1-9]|[1|2][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)[0-9][0-9]$");

                if (typed == "-1")
                {
                    return false;
                }
                
                if (typed == "")
                {
                    Console.WriteLine(constants.BLANKVALUE);
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
                        Console.WriteLine(constants.ENTERVALID);
                        return true;
                    }

                }
            }

            public Boolean typeStart(string typed)
            {
                Regex ob = new Regex("^[0-9]+$");
                if (typed == "")
                {
                    Console.WriteLine(constants.ENTERAGAIN);
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed) && typed == "1" || typed == "2" || typed == "3" || typed == "4" || typed == "5" || typed == "6" || typed == "7" || typed == "8")
                    {
                        return false;
                    }
                    else {
                        Console.WriteLine(constants.ENTERVALID);
                        return true; 
                    }
                }

            }

            public Boolean typeSecondStart(string typed)
            {
                Regex ob = new Regex("^[-|*][0-9]+$");
                if (typed == "")
                {
                    Console.WriteLine(constants.ENTERAGAIN);
                    return true;
                }
                else 
                {
                    if (ob.IsMatch(typed) || (typed == "1" || typed == "2" || typed == "3" || typed == "0"))
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(constants.ENTERVALID);
                        return true;
                    }
                }
            }

            public bool typeOrder(string typed)
            {
                Regex ob = new Regex("^[-]?[a-zA-Z0-9_]+$");
                if (typed == "")
                {
                   Console.WriteLine(constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    if (typed == "-1")
                    {
                        return false;
                    }
                    
                    else if (ob.IsMatch(typed) && typed.Count()<10)
                    {
                        return false;
                    }
                    else if (!ob.IsMatch(typed))
                    {
                        Console.WriteLine(constants.ALPHANUMERIC);
                    }
                    else
                    {
                        Console.WriteLine("Order no. value Not more than 10 character");   
                    }

                    return true;
                }
               
            }

            public bool typeQuantity(string typed)
            {
                Regex ob = new Regex("^[0-9]+$");
                if (typed == "")
                {
                    Console.WriteLine(constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    try
                    {
                        if ((Convert.ToDouble(typed) % 1) > 0)
                            Console.WriteLine(constants.NOTINFRACTION);
                        else if (ob.IsMatch(typed) && Convert.ToInt64(typed) <= 999 && Convert.ToInt64(typed) > 0)
                            return false;
                        else
                            Console.WriteLine(constants.QUANTITYNOTZERO);
                        return true;
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("\n"+e.Message + "\n" + constants.ENTERAGAIN);
                        return true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n" + e.Message + "\n" + constants.ENTERAGAIN);
                        return true;
                    }
                }
            }

            public bool typeDiscount(string typed,double amount)
            {
                Regex ob = new Regex("^[0-9]*([.][0-9]+)?$");
                if (typed == "")
                {
                    Console.WriteLine(constants.BLANKVALUE);
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed))
                    {
                        if (amount-(Convert.ToDouble(typed))>0 && Convert.ToDouble(typed) <= 99999 && Convert.ToDouble(typed) >= 0)
                            return false;
                        else
                        {
                            Console.WriteLine("Discount not to be exceed from " + amount);
                            return true; 
                        }
                    }
                    else
                        Console.WriteLine("Numeric value Only (Enter Again--------------->) ");
                    return true;
                }
            }

            public bool typeAmount(string typed)
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
                        else
                        {
                            Console.WriteLine("Not more than 99999");
                            return true;
                        }
                    }
                    else
                        Console.WriteLine("Numeric value Only (Enter Again--------------->) ");
                    return true;
                }
            }
            
        }
    }

