using System;
using System.Collections.Generic;

namespace IndustryLearnShip.Models
{
    /// <summary>
    /// Represents a library reader who can borrow books.
    /// </summary>
    public class Reader
    {
        public const int MaxBooksPerReader = 3;

        public string Name { get; }
        public List<Book> BorrowedBooks { get; }

        public Reader(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Имя читателя не может быть пустым.", nameof(name));
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        /// <summary>
        /// Adds a book to the reader's borrowed list. Throws if the limit is exceeded.
        /// </summary>
        public void TakeBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (BorrowedBooks.Count >= MaxBooksPerReader)
            {
                throw new InvalidOperationException(
                    $"Читатель \"{Name}\" не может взять больше {MaxBooksPerReader} книг (лимит превышен).");
            }
            BorrowedBooks.Add(book);
        }

        /// <summary>
        /// Removes a book from the reader's borrowed list. Throws if the reader does not have it.
        /// </summary>
        public void ReturnBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (!BorrowedBooks.Remove(book))
            {
                throw new InvalidOperationException($"Читатель \"{Name}\" не брал книгу «{book.Title}».");
            }
        }

        public override string ToString()
        {
            return $"{Name} (взято книг: {BorrowedBooks.Count}/{MaxBooksPerReader})";
        }
    }
}