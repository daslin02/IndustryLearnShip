using IndustryLearnShip.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1")]
    internal class Task01_HelloWorld : Common.ITask
    {
        string ITask.Title => "Hellow world";

        string ITask.Description => "выводит ";

        string[] ITask.Requirements => new[] {"Вывод Hello world" , "Вывод текущего времени"};

        void ITask.Run()
        {
            Console.WriteLine($"Hello world Дата и Время: {DateTime.Now}");
        }
    }
}
