using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ValLib
{
    public class Validation_Class
    {

        public static Boolean EM_Check(string email)
        {
            string format = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, format, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }

            public static Boolean PH_Check(string phone)
        {
            phone = phone.Trim();
            if (phone != "")
            {
                if (phone[0].Equals('+') && phone[1].Equals('7'))
                {
                    string cell = phone.Remove(0, 1);
                    if (cell.Length == 11 & cell.All(char.IsDigit))
                        return true;
                    else return false;
                }
                else return false;
            }
            else return false;
        }

            public static Boolean FIO_Check(string fio)
        {
            fio = fio.Trim().Replace("  ", " ");
            string[] words = fio.Split(' ');
            if (words.Length == 2 || words.Length == 3)
            {
                int c = 0;
                foreach (string i in words)
                {
                   if (char.IsUpper(i[0]))
                    {
                        c++;
                    }
                }

                if (words.Length == c) return true;
                else return false;
            }
            else return false;

        }

        public static Boolean DR_Check(string dr)
        {
            dr = dr.Trim();
            if (dr.Any(char.IsLetter))
                return false;
            else
            {
                string[] words = dr.Split('.');
                DateTime dt;
                if (words.Length == 3 & DateTime.TryParse(dr, out dt))
                {
                    if (Int32.Parse(words[2]) <= DateTime.Now.Year)
                    {
                        return true;
                    }
                    else return false;
                    
                    
                }
                else return false;
            }
        }
        }
}
