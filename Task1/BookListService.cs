using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task1
{
    public class BookListService : IEnumerable<Book>
    {
        /// <summary>
        /// List of Books.
        /// </summary>
        private List<Book> BookList;

        /// <summary>
        /// Constructor. Creates new BookList.
        /// </summary>
        public BookListService()
        {
            BookList = new List<Book>();
        }

        /// <summary>
        /// Add <see cref="book"> to BookList.
        /// </summary>
        /// <param name="book">Instance of Book</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <see cref="book"> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when <see cref="book"> is already in BookList.
        /// </exception>
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (BookList.Contains(book))
                throw new ArgumentException($"{book.ToString()} already exists.");
            BookList.Add(book);
        }

        /// <summary>
        /// Remove <see cref="book"> to BookList.
        /// </summary>
        /// <param name="book">Instance of Book</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <see cref="book"> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when <see cref="book"> is not in BookList.
        /// </exception>
        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (!BookList.Contains(book))
                throw new ArgumentException($"{book.ToString()} is not in list.");
            BookList.Remove(book);
        }

        public IEnumerator<Book> GetEnumerator() =>
            BookList.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
