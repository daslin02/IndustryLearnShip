using IndustryLearnShip.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1")]
    internal class Task02_PrimitiveType : ITask
    {
        public string Title => "Переменные примитивных типов";

        public string Description => "для каждого типа переменной выводиться наименования типа и его значение";

        public string[] Requirements => new[] { "Объявить минимум: `int`, `long`, `double`, `float`, `decimal`, `bool`, `char`, `string`" ,
            "Для каждой переменной вывести значение и `GetType().Name`","decimal — с суффиксом m, float — с f"

        };

        public void Run()
        {
            int VInt = 156;
            long VLong = 123124124;
            double VDouble = 1.123d;
            float VFloat = .124790f;
            decimal VDecimal = 3;
            bool VBool = false;
            char VChar = 'C';
            string VString = "Hello world";


            Console.WriteLine($" VInt = {VInt}    ({VInt.GetType()})");
            Console.WriteLine($" VLong = {VLong}    ({VLong.GetType()})");
            Console.WriteLine($" VDouble = {VDouble}d   ({VDouble.GetType()})");
            Console.WriteLine($" VFloat = {VFloat}f ({VFloat.GetType()})");
            Console.WriteLine($" VDecimal = {VDecimal}m ({VDecimal.GetType()})");
            Console.WriteLine($" VBool = {VBool}    ({VBool.GetType()})");
            Console.WriteLine($" VChar = {VChar}    ({VChar.GetType()})");
            Console.WriteLine($" VString = {VString}    ({VString.GetType()})");

        }
    }
}
