using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace Task4
{
    public class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Customer customer = null;
            if (!(arg is Customer))
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of '{format}' is invalid.", e);
                }
            customer = (Customer)arg;
            if (String.IsNullOrEmpty(format)) return customer.ToString("N,P,R", formatProvider);
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;
            string result = "";
            foreach (string param in format.ToUpperInvariant().Split(','))
            {
                bool isFound = false;
                switch (param)
                {
                    case "N":
                        result += "Name: " +  customer.Name.ToString(CultureInfo.CurrentCulture) + ", ";
                        isFound = true;
                        break;
                    case "P":
                        result += "Phone: " + customer.Phone.ToString(CultureInfo.CurrentCulture) + ", ";
                        isFound = true;
                        break;
                    case "R":
                        result += "Revenue: " + customer.Revenue.ToString(CultureInfo.CurrentCulture) + ", ";
                        isFound = true;
                        break;
                }
                Regex revenueRegex = new Regex(@"\A[R](:[A-Z]-?[0-9]?)$");
                if (revenueRegex.IsMatch(param))
                {
                    result += "Revenue: " + customer.Revenue.ToString(param.Remove(0, 2), CultureInfo.CurrentCulture) + ", ";
                    isFound = true;
                }
                if (!isFound)
                    throw new FormatException($"The {param} format string is not supported.");
            }
            result = result.TrimEnd(',', ' ');
            result += ".";
            return result;
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
}
