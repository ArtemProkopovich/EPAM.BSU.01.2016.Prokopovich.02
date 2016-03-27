using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task2
{
    public static class Gcd
    {
        private delegate int GCDDelegate(int a, int b);

        public static int Euclid(int num1, int num2, out TimeSpan elapsedTime)
        {
            return GCDTime(Euclid, num1, num2, out elapsedTime);
        }

        public static int Euclid(int num1, int num2)
        {
            if (num1 < 0 || num2 < 0)
                throw new ArgumentException("Передаваемые параметры должны быть больше нуля");
            if (num2 < num1)
            {
                int tmp = num1;
                num1 = num2;
                num2 = tmp;
            }
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
            return ThreeNumbersGCD(Euclid, num1, num2, num3);
        }

        public static int Euclid(params int[] array)
        {
            return ParamsGCD(Euclid, array);
        }

        public static int Stein(int num1, int num2, out TimeSpan elapsedTime)
        {
            return GCDTime(Stein, num1, num2, out elapsedTime);
        }

        public static int Stein(int num1, int num2)
        {
            if (num1 < 0 || num2 < 0)
                throw new ArgumentException("Передаваемые параметры должны быть больше нуля");
            int k = 1;
            if (num1 == 0)
                return num2;
            if (num2 == 0)
                return num1;
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
            return ThreeNumbersGCD(Stein, num1, num2, num3);
        }

        public static int Stein(params int[] array)
        {
            return ParamsGCD(Stein, array);
        }

        private static int GCDTime(GCDDelegate function, int num1, int num2, out TimeSpan elapsedTime)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int result = function(num1, num2);
            sw.Stop();
            elapsedTime = sw.Elapsed;
            return result;
        }

        private static int ThreeNumbersGCD(GCDDelegate function, int num1, int num2, int num3)
        {
            return function(function(num1, num2), num3);
        }

        private static int ParamsGCD(GCDDelegate function, params int[] array)
        {
            if (array.Length < 2)
                throw new ArgumentException("Ожидалось два или более параметров.");
            int result = function(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                result = function(result, array[i]);
            }
            return result;
        }
    }
}
