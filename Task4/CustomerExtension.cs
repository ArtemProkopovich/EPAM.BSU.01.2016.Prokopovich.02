using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace Task4
{
    public static class CustomerExtension
    {
        public static string ToFormatString(this Customer customer)
        {
            return ToFormatString(customer, "N,P,R");
        }

        public static string ToFormatString(this Customer customer, string format)
        {
            return ToFormatString(customer, format, CultureInfo.CurrentCulture);
        }

        public static string ToFormatString(this Customer customer, string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) return customer.ToString("N,P,R", formatProvider);
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;
            string result = "";
            foreach (string param in format.ToUpperInvariant().Split(','))
            {
                bool isFound = false;
                switch (param)
                {
                    case "N":
                        result += customer.Name.ToString(formatProvider) + ", ";
                        isFound = true;
                        break;
                    case "P":
                        result += customer.Phone.ToString(formatProvider) + ", ";
                        isFound = true;
                        break;
                    case "R":
                        result += customer.Revenue.ToString(formatProvider) + ", ";
                        isFound = true;
                        break;
                }
                Regex revenueRegex = new Regex(@"\A[R](:[A-Z]-?[0-9]?)$");
                if (revenueRegex.IsMatch(param))
                {
                    result += customer.Revenue.ToString(param.Remove(0, 2), formatProvider) + ", ";
                    isFound = true;
                }
                if (!isFound)
                    throw new FormatException($"The {param} format string is not supported.");
            }
            result = result.TrimEnd(',', ' ');
            result += ".";
            return result;
        }
    }
}
