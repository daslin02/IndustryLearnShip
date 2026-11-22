using IndustryLearnShip.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IndustryLearnShip.Tasks.Level3
{
    [Common.TaskInfoAttribute("DB", 29)]
    internal class Task29_DbInsert : ITask
    {
        public string Title => "C# + SQL: Параметризованный INSERT";
        public string Description => "Добавить сотрудника через параметры.";
        public string[] Requirements => new[]
        {
            "Метод AddEmployee",
            "Параметры @name, @salary, @deptId",
            "SCOPE_IDENTITY()",
            "Обработка ошибок"
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

                Console.Write("Введите имя сотрудника: ");
                string name = Console.ReadLine();

                Console.Write("Введите зарплату: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
                {
                    Console.WriteLine("Некорректная зарплата.");
                    return;
                }

                Console.Write("Введите ID отдела (1-4): ");
                if (!int.TryParse(Console.ReadLine(), out int deptId))
                {
                    Console.WriteLine("Некорректный ID.");
                    return;
                }

                int? newId = await AddEmployeeAsync(conn, name, salary, deptId);

                if (newId.HasValue)
                {
                    Console.WriteLine($"\nУспех! Новый ID: {newId.Value}");

                    // Проверка
                    using (SqlCommand checkCmd = new SqlCommand("SELECT EmployeeName FROM Employees WHERE EmployeeId = @id", conn))
                    {
                        checkCmd.Parameters.Add("@id", SqlDbType.Int).Value = newId.Value;
                        var resultName = await checkCmd.ExecuteScalarAsync();
                        Console.WriteLine($"Проверка: Сотрудник {resultName} найден в БД.");
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Ошибка FK: Такого отдела не существует.");
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

        private async Task<int?> AddEmployeeAsync(SqlConnection conn, string name, decimal salary, int departmentId)
        {
            string sql = @"
                INSERT INTO Employees (EmployeeName, Salary, HireDate, DepartmentId)
                VALUES (@name, @salary, @hireDate, @deptId);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
                cmd.Parameters.Add("@salary", SqlDbType.Decimal).Value = salary;
                cmd.Parameters.Add("@hireDate", SqlDbType.Date).Value = DateTime.Today;
                cmd.Parameters.Add("@deptId", SqlDbType.Int).Value = departmentId;

                var result = await cmd.ExecuteScalarAsync();
                return result as int?;
            }
        }
    }
}