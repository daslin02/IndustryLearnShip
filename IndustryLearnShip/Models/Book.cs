using System;

namespace IndustryLearnShip.Models
{
    /// <summary>
    /// Represents a book in the library.
    /// </summary>
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public bool IsAvailable { get; private set; }

        public Book(string title, string author)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Название книги не может быть пустым.", nameof(title));
            if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Автор книги не может быть пустым.", nameof(author));

            Title = title;
            Author = author;
            IsAvailable = true;
        }

        /// <summary>
        /// Marks the book as borrowed (unavailable).
        /// </summary>
        public void Borrow()
        {
            if (!IsAvailable) throw new InvalidOperationException($"Книга \"{Title}\" уже выдана.");
            IsAvailable = false;
        }

        /// <summary>
        /// Marks the book as returned (available).
        /// </summary>
        public void Return()
        {
            if (IsAvailable) throw new InvalidOperationException($"Книга \"{Title}\" уже в библиотеке.");
            IsAvailable = true;
        }

        public override string ToString()
        {
            string status = IsAvailable ? "доступна" : "выдана";
            return $"«{Title}» ({Author}) — {status}";
        }
    }
}