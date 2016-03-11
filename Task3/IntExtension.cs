using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class IntExtension
    {
        public static string HexFormat(this int number)
        {
            if (number == 0)
                return "0";
            char A = 'A';
            string result = "";
            while (number != 0)
            {
                int mod = number%16;
                result += (mod < 10) ? mod : (char) (A + mod - 10);
                number /= 16;
            }
            return result;
        }
    }
}
