using IndustryLearnShip.Common;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.Level3
{
    [Common.TaskInfoAttribute("DB", 28)]
    internal class Task28_DbSelect : ITask
    {
        public string Title => "C# + SQL: Подключение и SELECT";
        public string Description => "Подключиться к PracticeDB и вывести список сотрудников.";
        public string[] Requirements => new[]
        {
            "NuGet: Microsoft.Data.SqlClient",
            "Строка подключения из connection.txt",
            "Асинхронное открытие (OpenAsync)",
            "Чтение через SqlDataReader"
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
                Console.WriteLine("Подключение к базе данных...");
                conn = await DbHelper.GetOpenConnectionAsync();
                Console.WriteLine("Соединение установлено.");

                string sql = "SELECT EmployeeName, Salary FROM Employees ORDER BY Salary DESC";

                // Обычный using вместо await using
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        Console.WriteLine("\n--- Список сотрудников ---");
                        Console.WriteLine($"{"Имя",-25} {"Зарплата",10}");
                        Console.WriteLine(new string('-', 40));

                        while (await reader.ReadAsync())
                        {
                            string name = reader["EmployeeName"].ToString();
                            decimal salary = Convert.ToDecimal(reader["Salary"]);
                            Console.WriteLine($"{name,-25} {salary,10:N2}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Ошибка SQL ({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}