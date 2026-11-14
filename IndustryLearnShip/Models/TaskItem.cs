using System;

namespace IndustryLearnShip.Models
{
    /// <summary>
    /// Represents a single task in the to-do list.
    /// </summary>
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; }

        public TaskItem() { }

        public TaskItem(int id, string title)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            IsDone = false;
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            string status = IsDone ? "[✓]" : "[ ]";
            return $"{status} #{Id}: {Title}";
        }
    }
}