using IndustryLearnShip.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1" , 7)]
    internal class Task07_ReverseStr : ITask
    {
        public string Title => " Реверс строки без LINQ";

        public string Description => "реверсинг строки ";

        public string[] Requirements => new[] { "Не использовать Array.Reverse и LINQ" ,
            "Реализовать через цикл for от конца к началу (или через char[] и swap)",
            "Пустая строка и строка из одного символа — обрабатываются корректно."
        };

        public void Run()
        {
            Console.Write("Введите строку ");
            string line = Console.ReadLine();

            string result = "";
            if ((line.Length) <= 1) 
            {
                Console.WriteLine($"{line} > {line}");
                return;
            }
            for (int i = line.Length - 1; i >= 0; i--) 
            {
                result += line[i];
            }
            Console.WriteLine($"{line} > {result}");
        }
    }
}
