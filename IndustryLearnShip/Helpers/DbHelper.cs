using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace IndustryLearnShip.Common
{
    public static class DbHelper
    {
        private static string _connectionString;

        /// <summary>
        /// Получает строку подключения из файла connection.txt в корне приложения.
        /// </summary>
        public static string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(_connectionString))
                return _connectionString;

            // Ищем файл connection.txt в текущей директории или на уровень выше
            string path = "connection.txt";
            if (!File.Exists(path))
                path = Path.Combine("..", "connection.txt");

            if (!File.Exists(path))
                throw new FileNotFoundException("Файл connection.txt не найден. Создайте его в корне проекта и поместите туда строку подключения.");

            _connectionString = File.ReadAllText(path).Trim();
            return _connectionString;
        }

        /// <summary>
        /// Создает и открывает асинхронное соединение с базой данных.
        /// </summary>
        public static async Task<SqlConnection> GetOpenConnectionAsync()
        {
            var conn = new SqlConnection(GetConnectionString());
            await conn.OpenAsync();
            return conn;
        }
    }
}