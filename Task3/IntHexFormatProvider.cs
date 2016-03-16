using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task3
{
    public class IntHexFormatProvider: IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is int && (string.IsNullOrEmpty(format) || format.ToUpper(CultureInfo.InvariantCulture) == "H"))
            {
                return "0x" + IntToHex((int) arg);
            }
            else
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of '{format}' is invalid.", e);
                }
            }
        }

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        private string IntToHex(int number)
        {
            if (number == 0)
                return "0";
            bool neg = number < 0;
            number = Math.Abs(number);
            char A = 'A';
            string result = "";
            while (number != 0)
            {
                int mod = number % 16;
                if (mod < 10)
                    result += mod;
                else
                    result += (char)(A + mod - 10);
                number /= 16;
            }
            if (neg)
                result += '-';
            result = new string(result.Reverse().ToArray());
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
