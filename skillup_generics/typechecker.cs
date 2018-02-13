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
                    else if (Convert.ToInt32(typed) == 23 || Convert.ToInt32(typed) == 24 || Convert.ToInt32(typed) == 36 || typed == "99")
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
                Regex ob = new Regex("^(0[1-9]|[1|2][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)[0-9][0-9]");
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
                Regex ob = new Regex("^[0-9]+$");
                if (typed == "")
                {
                    Console.WriteLine("Enter Again--------------->");
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed) && Convert.ToInt32(typed) == 1 || Convert.ToInt32(typed) == 2 || Convert.ToInt32(typed) == 3 || Convert.ToInt32(typed) == 4 || typed == "5" || typed == "6" || typed == "7")
                    {
                        return false;
                    }
                    else { return true; }
                }

            }

            public bool type_o(string typed)
            {
                Regex ob = new Regex("^[0-9]+$");
                if (typed == "")
                {
                    Console.WriteLine("Enter Again--------------->");
                    return true;
                }
                else
                {
                    if (ob.IsMatch(typed) && Convert.ToInt64(typed) <= 999999)
                        return false;
                    else
                        Console.WriteLine("Enter Again--------------->");
                        return true;
                }
            }

            public bool type_q(string typed)
            {
                Regex ob = new Regex("^[0-9]+$");
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
                        Console.WriteLine("Enter Again--------------->");
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
    }

