using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookListService
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
        /// Add instance of Book to BookList.
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
    }
}
