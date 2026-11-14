using IndustryLearnShip.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.level3
{
    [Common.TaskInfoAttribute("Level-3", 50)]
    public class Task50_Bisect : ITask
    {
        public string Title => "Test Bisect";

        public string Description => " найти «плохой» коммит через git bisect.";

        public string[] Requirements => new[] { "" };

        public void Run()
        {
            Console.WriteLine($"Сложение {MathUtils.Add(10, 10)}");
            Console.WriteLine($"Сложение {MathUtils.Subtract(10, 20)}");
        }

    }
    public class MathUtils
    {

        public static double Add(double a, double b)
        {
            return a + b;
        }


        public static double Subtract(double a, double b)
        {
            return a - b;
        }


        //public static double Multiply(double a, double b)
        //{
        //    return a * b;
        //}


        //public static double Divide(double a, double b)
        //{
        //    if (b == 0)
        //    {
        //        throw new DivideByZeroException("Деление на ноль недопустимо.");
        //    }
        //    return a / b;
        //}


        //public static double Power(double baseValue, double exponent)
        //{
        //    return Math.Pow(baseValue, exponent);
        //}


        //public static double Modulo(double a, double b)
        //{
        //    if (b == 0)
        //    {
        //        throw new DivideByZeroException("Делитель не может быть равен нулю.");
        //    }
        //    return a % b;
        //}


        //public static double SquareRoot(double a)
        //{
        //    if (a < 0)
        //    {
        //        throw new ArgumentException("Нельзя извлечь квадратный корень из отрицательного числа.");
        //    }
        //    return Math.Sqrt(a);
        //}


        //public static long Factorial(int n)
        //{
        //    if (n < 0)
        //    {
        //        throw new ArgumentException("Факториал не определен для отрицательных чисел.");
        //    }
        //    if (n == 0 || n == 1)
        //    {
        //        return 1;
        //    }

        //    long result = 1;
        //    for (int i = 2; i <= n; i++)
        //    {
        //        result *= i;
        //    }
        //    return result;
        //}


        //public static bool IsEven(int n)
        //{
        //    return n % 2 == 0;
        //}


        //public static double AbsoluteValue(double n)
        //{
        //    return Math.Abs(n);
        //}
    }
}
