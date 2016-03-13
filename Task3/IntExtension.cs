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
            bool neg = number < 0;
            number = Math.Abs(number);
            char A = 'A';
            string result = "";
            while (number != 0)
            {
                int mod = number%16;
                if (mod < 10)
                    result += mod;
                else
                    result += (char) (A + mod - 10);
                number /= 16;
            }
            if (neg)
                result += '-';
            result = new string (result.Reverse().ToArray());
            return result;
        }
    }
}
