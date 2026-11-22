using IndustryLearnShip.Common;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.Level3
{
    [Common.TaskInfoAttribute("DB", 30)]
    internal class Task30_DbReport : ITask
    {
        public string Title => "C# + SQL: Мини-отчёт по отделам";
        public string Description => "Статистика по отделам.";
        public string[] Requirements => new[]
        {
            "LEFT JOIN + GROUP BY",
            "Обработка NULL",
            "Форматированный вывод"
        };

        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {
            SqlConnection conn = null;
            try
            {
                conn = await DbHelper.GetOpenConnectionAsync();

                string sql = @"
                    SELECT 
                        d.DepartmentName,
                        COUNT(e.EmployeeId) AS EmpCount,
                        ISNULL(AVG(e.Salary), 0) AS AvgSalary
                    FROM Departments d
                    LEFT JOIN Employees e ON d.DepartmentId = e.DepartmentId
                    GROUP BY d.DepartmentName
                    ORDER BY d.DepartmentName";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        Console.WriteLine("\n=== ОТЧЁТ ПО ОТДЕЛАМ ===");
                        Console.WriteLine($"{"Отдел",-20} | {"Сотр.",6} | {"Ср. ЗП",10}");
                        Console.WriteLine(new string('-', 45));

                        bool hasData = false;

                        while (await reader.ReadAsync())
                        {
                            hasData = true;
                            string deptName = reader.GetString(0);
                            int count = reader.GetInt32(1);
                            decimal avgSal = reader.GetDecimal(2);

                            string avgDisplay = count == 0 ? "N/A" : avgSal.ToString("N2");

                            Console.WriteLine($"{deptName,-20} | {count,6} | {avgDisplay,10}");
                        }

                        if (!hasData) Console.WriteLine("Нет данных.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }
    }
}