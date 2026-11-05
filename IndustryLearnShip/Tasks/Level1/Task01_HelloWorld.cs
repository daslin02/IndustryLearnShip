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

        string ITask.Description => "Print in console Hello World And current Time";

        string[] ITask.Requirements => new[] {"Print Hello world" , "PrintTime"};

        void ITask.Run()
        {
            Console.WriteLine($"Hello world Time: {DateTime.Now}");
        }
    }
}
