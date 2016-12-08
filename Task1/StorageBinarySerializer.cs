using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class StorageBinarySerializer : IBookListStorage
    {
        /// <summary>
        /// File to store Book list.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Binary formatter.
        /// </summary>
        private BinaryFormatter formatter;

        /// <summary>
        /// Constructor. Initializes <see cref="formatter"> as BinaryFormatter.
        /// </summary>
        /// <param name="fileName">Path to file for storage.</param>
        /// <exception cref="ArgumentException">
        /// Throws when <see cref="fileName"> is null or empty.
        /// </exception>
        public StorageBinarySerializer(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException($"{fileName} is null or empty");
            this.fileName = fileName;
            formatter = new BinaryFormatter();
        }

        /// <summary>
        /// Saves <see cref="bookList"> to <see cref="fileName">
        /// </summary>
        /// <param name="bookList">List of Book</param>
        public void SaveBookList(IEnumerable<Book> bookList)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, bookList);
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
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                bookList = (List<Book>)formatter.Deserialize(fs);
            }
            return bookList;
        }
    }
}
