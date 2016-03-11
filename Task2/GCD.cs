using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class Gcd
    {
        public static int Euclid(int num1, int num2)
        {
            if (num1 < 0 || num2 < 0)
                throw new ArgumentException("Передаваемые параметры должны быть больше нуля");
            while (num2 != 0)
            {
                int tmp = num1 % num2;
                num1 = num2;
                num2 = tmp;
            }
            return num1;
        }

        public static int Euclid(int num1, int num2, int num3)
        {
            return Euclid(Euclid(num1, num2), num3);
        }

        public static int Euclid(params int[] array)
        {
            if (array.Length < 2)
                throw new ArgumentException("Ожидалось два или более параметров.");
            int result = Euclid(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                result = Euclid(result, array[i]);
            }
            return result;
        }

        public static int Stein(int num1, int num2)
        {
            if (num1 < 0 || num2 < 0)
                throw new ArgumentException("Передаваемые параметры должны быть больше нуля");
            int k = 1;
            while ((num1 != 0) && (num2 != 0))
            {
                while ((num1 % 2 == 0) && (num2 % 2 == 0))
                {
                    num1 /= 2;
                    num2 /= 2;
                    k *= 2;
                }
                while (num1 % 2 == 0) num1 /= 2;
                while (num2 % 2 == 0) num2 /= 2;
                if (num1 >= num2)
                    num1 -= num2;
                else num2 -= num1;
            }
            return num2*k;
        }

        public static int Stein(int num1, int num2, int num3)
        {
            return Stein(Stein(num1, num2), num3);
        }

        public static int Stein(params int[] array)
        {
            if (array.Length < 2)
                throw new ArgumentException("Ожидалось два или более параметров.");
            int result = Stein(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                result = Stein(result, array[i]);
            }
            return result;
        }
    }
}
