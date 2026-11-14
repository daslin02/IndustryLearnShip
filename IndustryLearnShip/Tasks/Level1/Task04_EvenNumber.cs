using IndustryLearnShip.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1" , 4 )]
    internal class Task04_EvenNumber : ITask
    {
        public string Title => "чётность чисел";

        public string Description => "Проверка чисел на чётность 2 способами";

        public string[] Requirements => new[] { "Способ 1: через % 2 == 0." ,
            "пособ 2: через тернарный оператор ? :",
            "Оба способа реализовать отдельными методами.",
            "Вывести результат обоих способов."
        };

        public void Run()
        {
            Console.WriteLine("Ведите A:");
            string A = Console.ReadLine();
            int a;
            try
            {
                a = Convert.ToInt32(A);
            }
            catch
            {
                Console.WriteLine("введенно не коректнное число или не числа");
                return;
            }
            bool ResultA = Baseif(a);
            string evenStr = "чётное число";
            string NoevenStr = "не чётное число";

            Console.WriteLine($"1. способ через IF : {A} -- {(ResultA? evenStr :NoevenStr )} ");
            bool ResultB = Terif(a);
            Console.WriteLine($"2. способ через тернарный оператор : {A} -- {(ResultB ? evenStr : NoevenStr)}");

        }
        private bool Baseif(int a) 
        {
            if (a % 2 == 0) return true;
            return false;
        }
        private bool Terif(int a)
        {
            bool result =  (a % 2 == 0 )?   true :  false ; 
            return result;
        }
    }
}
