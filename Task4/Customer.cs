using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task4
{
    public class Customer : IFormattable
    {
        public string Name;
        public string Phone;
        public decimal Revenue;

        public override string ToString()
        {
            return ToString("N,P,R");
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "N,P,R";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;
            StringBuilder tResult = new StringBuilder("Customer: ");
            foreach (string param in format.ToUpperInvariant().Split(','))
            {
                switch (param)
                {
                    case "N":
                        tResult.Append(Name.ToString(formatProvider)).Append(", ");
                        break;
                    case "P":
                        tResult.Append(Phone.ToString(formatProvider)).Append(", ");
                        break;
                    case "R":
                        tResult.Append(Revenue.ToString("C2", formatProvider)).Append(", ");
                        break;
                    default:
                        throw new FormatException($"The {param} format string is not supported.");
                }
            }
            string result = tResult.ToString();
            result = result.TrimEnd(',', ' ');
            result += '.';
            return result;
        }
    }
}
