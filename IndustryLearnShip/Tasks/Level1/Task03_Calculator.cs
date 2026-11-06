using IndustryLearnShip.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1")]
    internal class Task03_Calculator : ITask
    {
        public string Title => "Калькулятор ";

        public string Description => "калькулятор консольный с обработкой деления на ноль";

        public string[] Requirements => new[] { "Оператор обрабатывать через `switch`" ,
            "При делении на ноль — вывести сообщение об ошибке, не ронять приложение",
            "Некорректный оператор — вывести «Неизвестная операция»",
            "Ввод чисел — через `double.Parse` или `TryParse`"
        };

        public void Run()
        {
            Console.WriteLine("Ведите A:");
            string A = Console.ReadLine();
            Console.WriteLine("Ведите B:");
            string B = Console.ReadLine();
            double a;
            double b;
            try 
            {
                a = Convert.ToDouble(A);
                b = Convert.ToDouble(B);
            }
            catch 
            {
                Console.WriteLine("введены не коректные числа или не числа");
                return;
            }
            Console.WriteLine("Введите опертор (+ , - , * , / ):");
            string opertor = Console.ReadLine();
            switch (opertor)
            {
                case "+":
                    Console.WriteLine($"Результат: {a} + {b} = {a + b}");
                    break;

                case "-":
                    Console.WriteLine($"Результат: {a} - {b} = {a - b}");
                    break;

                case "*":
                    Console.WriteLine($"Результат: {a} * {b} = {a * b}");
                    break;

                case "/":
                    if (b == 0)
                    {
                        Console.WriteLine("Ошибка: деление на ноль невозможно!");
                    }
                    else
                    {
                        Console.WriteLine($"Результат: {a} / {b} = {a / b}");
                    }
                    break;

                default:
                    Console.WriteLine("❌ Неизвестная операция");
                    break;
            }
        }
    }
}
