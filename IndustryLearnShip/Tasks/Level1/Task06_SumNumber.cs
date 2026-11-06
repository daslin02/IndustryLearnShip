using IndustryLearnShip.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1")]
    internal class Task06_SumNumber : ITask
    {
        public string Title => "Сумма цифр";

        public string Description => "Найти сумму цифр ввёденного числа";

        public string[] Requirements => new[] { "Способ 1 (строка): число → ToString() → пройти по символам → int.Parse каждой цифры.",
            "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }.",
            "Оба способа оформить отдельными методами.",
            "Отрицательные числа — брать модуль"
        };

        public void Run()
        {
            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"Способ 1 (строка): {MethodOne(number)}");
            Console.WriteLine($"Способ 2 (арифметика): {MethodTwo(number)}");
        }

        private int MethodOne(int i)
        {
            int sum = 0;
            string str = Math.Abs(i).ToString();
            foreach (char c in str)
            {
                sum += int.Parse(c.ToString());
            }
            return sum;
        }

        private int MethodTwo(int i)
        {
            int sum = 0;
            int n = Math.Abs(i);
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
    }
}
