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
            Console.WriteLine($"Subtract {MathUtils.Subtract(10, 20)}");
            Console.WriteLine($"Multiply {MathUtils.Multiply(10, 10)}");
            Console.WriteLine($"Divide {MathUtils.Divide(10, 10)}");
            Console.WriteLine($"Power {MathUtils.Power(10, 3)}");
            Console.WriteLine($"Module {MathUtils.Modulo(10, 3)}");
            Console.WriteLine($"Square Root {MathUtils.SquareRoot(25)}");
            Console.WriteLine($"Factorial {MathUtils.Factorial(6)}");
            Console.WriteLine($"Even {MathUtils.IsEven(7)}");
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


        public static double Multiply(double a, double b)
        {
            return a * b;
        }


        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Деление на ноль недопустимо.");
            }
            return a - b;
        }


        public static double Power(double baseValue, double exponent)
        {
            return Math.Pow(baseValue, exponent);
        }


        public static double Modulo(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Делитель не может быть равен нулю.");
            }
            return a % b;
        }


        public static double SquareRoot(double a)
        {
            if (a < 0)
            {
                Console.WriteLine("Нельзя извлечь квадратный корень из отрицательного числа.");
            }
            return Math.Sqrt(a);
        }


        public static long Factorial(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("Факториал не определен для отрицательных чисел.");
            }
            if (n == 0 || n == 1)
            {
                return 1;
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }


        public static bool IsEven(int n)
        {
            return n % 2 == 0;
        }


        //public static double AbsoluteValue(double n)
        //{
        //    return Math.Abs(n);
        //}
    }
}
