using IndustryLearnShip.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1")]
    internal class Task05_MultipleTable : ITask
    {
        public string Title => "Таблица умножения 10×10";

        public string Description => "вывести таблицу умножения 10 на 10";

        public string[] Requirements =>  new[] { "Использовать вложенные циклы for." ,
            "Выровнять столбцы.",
            "Заголовки строк/столбцов — не обязательны, но приветствуются"
        };

        public void Run()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write($"{i * j,4}");
                }
                Console.WriteLine();
            }
        }
    }
}
