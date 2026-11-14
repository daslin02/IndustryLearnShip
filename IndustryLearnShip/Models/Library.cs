using System;
using System.Collections.Generic;
using System.Linq;

namespace IndustryLearnShip.Models
{
    /// <summary>
    /// Manages the process of issuing and returning books between the library and readers.
    /// </summary>
    public class Library
    {
        private readonly List<Book> _books;
        private readonly List<Reader> _readers;

        public Library()
        {
            _books = new List<Book>();
            _readers = new List<Reader>();
        }

        /// <summary>
        /// Adds a new book to the library.
        /// </summary>
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            _books.Add(book);
        }

        /// <summary>
        /// Registers a new reader.
        /// </summary>
        public void AddReader(Reader reader)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            _readers.Add(reader);
        }

        /// <summary>
        /// Issues a book to a reader.
        /// </summary>
        public void IssueBook(string bookTitle, string readerName)
        {
            Book book = FindBook(bookTitle);
            Reader reader = FindReader(readerName);

            book.Borrow();
            try
            {
                reader.TakeBook(book);
            }
            catch
            {
                book.Return();
                throw;
            }
        }

        /// <summary>
        /// Returns a book from a reader.
        /// </summary>
        public void ReturnBook(string bookTitle, string readerName)
        {
            Book book = FindBook(bookTitle);
            Reader reader = FindReader(readerName);

            reader.ReturnBook(book);
            book.Return();
        }

        /// <summary>
        /// Returns all books in the library.
        /// </summary>
        public IReadOnlyList<Book> GetAllBooks() => _books.AsReadOnly();

        /// <summary>
        /// Returns all registered readers.
        /// </summary>
        public IReadOnlyList<Reader> GetAllReaders() => _readers.AsReadOnly();

        private Book FindBook(string title)
        {
            Book book = _books.FirstOrDefault(b =>
                string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase));
            if (book == null) throw new KeyNotFoundException($"Книга \"{title}\" не найдена в библиотеке.");
            return book;
        }

        private Reader FindReader(string name)
        {
            Reader reader = _readers.FirstOrDefault(r =>
                string.Equals(r.Name, name, StringComparison.OrdinalIgnoreCase));
            if (reader == null) throw new KeyNotFoundException($"Читатель \"{name}\" не зарегистрирован.");
            return reader;
        }
    }
}