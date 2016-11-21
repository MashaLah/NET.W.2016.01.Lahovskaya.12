using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task1
{
    public class BookListService
    {
        /// <summary>
        /// List of Books.
        /// </summary>
        private List<Book> bookList;

        /// <summary>
        /// Constructor. Creates new BookList.
        /// </summary>
        public BookListService()
        {
            bookList = new List<Book>();
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
            if (bookList.Contains(book))
                throw new ArgumentException($"{book.ToString()} already exists.");
            bookList.Add(book);
        }

        /// <summary>
        /// Removes <see cref="book"> to BookList.
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
            if (!bookList.Contains(book))
                throw new ArgumentException($"{book.ToString()} is not in list.");
            bookList.Remove(book);
        }

        /// <summary>
        /// Searches for first element that matches the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="condition">
        /// The Predicat delegate that defines the conditions of the element to search for.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <see cref="condition"> is null.
        /// </exception>
        /// <returns>
        /// First element that matches the conditions defined by the specified predicate, if found; 
        /// otherwise, null.
        /// </returns>
        public Book FindBookByTag(Predicate<Book> condition)
        {
            if (condition==null) throw new ArgumentNullException(nameof(condition));
            return bookList.Find(condition);
        }

        /// <summary>
        /// Sorts BookList by tag.
        /// </summary>
        /// <param name="condition">Tag to compare.</param>
        /// <exception cref="ArgumentNullException">
        /// <see cref="condition"> is null.
        /// </exception>
        public void SortBooksByTag(Comparison<Book> condition)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));
            bookList.Sort(condition);
        }

        /// <summary>
        /// Save <see cref="bookList"> in storage.
        /// </summary>
        /// <param name="storage">Storage.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <see cref="storage"> is null.
        /// </exception>
        public void Save(IBookListStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException(nameof(storage));
            storage.SaveBookList(bookList);
        }

        /// <summary>
        /// Load collection to <see cref="bookList"> from storage.
        /// </summary>
        /// <param name="storage">Storage.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <see cref="storage"> is null.
        /// </exception>
        public void Load(IBookListStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException(nameof(storage));
            bookList = new List<Book>(storage.LoadBookList());
        }
    }
}
