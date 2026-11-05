using IndustryLearnShip.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Menu
{
    internal class LevelMenu
    {
        public List<Common.ITask> Tasks = new List<Common.ITask>();
         private string LevelName = "NULL";
        public LevelMenu(string Name) 
        {
            LevelName = Name;
            MenuRunner._instance.ArrayLevels.Add(this);
        }
        /// <summary>
        /// Showing level Menu 
        /// </summary>
        public void Show() 
        {
            while (true) 
            {
                Console.WriteLine("--- Уровень 1: Базовый (задания 1–15) ---");
                for (int i = 0; i < Tasks.Count; i++) 
                {
                    ITask task = Tasks[i];
                    Console.WriteLine($"{i} : {task.Title}");
                }
                Console.WriteLine("Выберите задание (q- для выхода):");
                
                int TaskIndex = WriteIndexTask();
                //print TAsk info
                Console.WriteLine($"\n -----Задание : {Tasks[TaskIndex].Title}------");
                Console.WriteLine($"Описание: \n{Tasks[TaskIndex].Description}");
                Console.WriteLine("Требования:");
                foreach (string requir in Tasks[TaskIndex].Requirements) 
                {  
                    Console.WriteLine($"\t - {requir}");    
                }
                Console.WriteLine("[запуск решения]...\n");
                Tasks[TaskIndex].Run();
            }

        }
        private int WriteIndexTask()
        {
            string read = Console.ReadLine();
            int NumTask = -1;
            if (read == "q" )
            {
                Console.WriteLine("Выход вглавное меню...\n");
                MenuRunner._instance.Run();
            }
            try
            {
                NumTask = Convert.ToInt32(read);
                if (NumTask >= 0 && NumTask < Tasks.Count)
                {
                    return NumTask;
                }
            }
            catch { }

            Console.WriteLine("не коректный индекс , введите индекс повторно:");
            return WriteIndexTask();

        }
        public string GetName() 
        {
            return LevelName;
        }
        
    }
    
}
