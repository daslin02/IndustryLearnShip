using System;
using System.Collections.Generic;
using System.Linq;

namespace IndustryLearnShip.Models
{
    /// <summary>
    /// Business logic layer for the to-do list.
    /// </summary>
    public class TaskService
    {
        private readonly TaskRepository _repository;
        private List<TaskItem> _tasks;

        public TaskService(TaskRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _tasks = _repository.LoadAll();
        }

        /// <summary>
        /// Adds a new task with the given title.
        /// </summary>
        public TaskItem Add(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Название задачи не может быть пустым.", nameof(title));
            }

            int newId = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
            TaskItem task = new TaskItem(newId, title);
            _tasks.Add(task);
            _repository.SaveAll(_tasks);
            return task;
        }

        /// <summary>
        /// Returns all tasks.
        /// </summary>
        public List<TaskItem> GetAll()
        {
            return new List<TaskItem>(_tasks);
        }

        /// <summary>
        /// Marks a task as done by its ID.
        /// </summary>
        public bool MarkAsDone(int id)
        {
            TaskItem task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;

            task.IsDone = true;
            _repository.SaveAll(_tasks);
            return true;
        }

        /// <summary>
        /// Deletes a task by its ID.
        /// </summary>
        public bool Delete(int id)
        {
            TaskItem task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;

            _tasks.Remove(task);
            _repository.SaveAll(_tasks);
            return true;
        }
    }
}