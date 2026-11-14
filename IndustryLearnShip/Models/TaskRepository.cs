using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace IndustryLearnShip.Models
{
    /// <summary>
    /// Handles persistence of TaskItem objects to a JSON file.
    /// </summary>
    public class TaskRepository
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public TaskRepository(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        /// <summary>
        /// Loads all tasks from the JSON file. Returns an empty list if the file does not exist.
        /// </summary>
        public List<TaskItem> LoadAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<TaskItem>();
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<TaskItem>>(json, _jsonOptions)
                       ?? new List<TaskItem>();
            }
            catch (JsonException)
            {
                return new List<TaskItem>();
            }
        }

        /// <summary>
        /// Saves all tasks to the JSON file, overwriting the previous content.
        /// </summary>
        public void SaveAll(List<TaskItem> tasks)
        {
            string json = JsonSerializer.Serialize(tasks, _jsonOptions);
            File.WriteAllText(_filePath, json);
        }
    }
}