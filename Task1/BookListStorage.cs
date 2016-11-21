using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookListStorage : IBookListStorage 
    {
        /// <summary>
        /// File to store Book list.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fileName">Path to file for storage.</param>
        /// <exception cref="ArgumentException">
        /// Throws when <see cref="fileName"> is null or empty.
        /// </exception>
        public BookListStorage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException($"{fileName} is null or empty");
            this.fileName = fileName;
        }

        /// <summary>
        /// Saves <see cref="bookList"> to <see cref="fileName">
        /// </summary>
        /// <param name="bookList">List of Book</param>
        public void SaveBookList(IEnumerable<Book> bookList)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                foreach (Book book in bookList)
                {
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Year);
                    writer.Write(book.Genre);
                }
            }
        }

        /// <summary>
        /// Load list of Book from <see cref="fileName">.
        /// </summary>
        /// <exception cref="FileNotFoundException">
        /// Throws when file doesn't exists.
        /// </exception> 
        /// <returns>List of Book.</returns>
        public IEnumerable<Book> LoadBookList()
        {
            List<Book> bookList = new List<Book>();
            if (!File.Exists(fileName))
                throw new FileNotFoundException($"File {nameof(fileName)} not found.");
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (reader.PeekChar() != -1)
                {
                    string Author = reader.ReadString();
                    string Title = reader.ReadString();
                    int Year = reader.ReadInt32();
                    string Genre = reader.ReadString();
                    bookList.Add(new Book(Author, Title, Year, Genre));
                }
            }
            return bookList;
        }
    }
}
