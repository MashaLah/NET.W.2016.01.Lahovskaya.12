using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Book firstBook = new Book("Tolstoy", "War And Peace", 1869, "Historical Novel");
            Book secondBook = new Book("tolstoy", "war And peace", 1869, "historical novel");
            Book thirdBook = firstBook;
            Book fourthBook = new Book("Tolstoy", "Anna Karenina", 1873, "Novel");
            Book fifthBook = new Book("Vonnegut ", "Slaughterhouse Five", 1969, "Satirical Novel");

            Console.WriteLine($"{firstBook.ToString()} equals");
            Console.WriteLine($"{secondBook.ToString()}");
            Console.WriteLine(firstBook.Equals(secondBook));
            Console.WriteLine($"{firstBook.ToString()} equals");
            Console.WriteLine($"{ thirdBook.ToString()}");
            Console.WriteLine(firstBook.Equals(thirdBook));
            Console.WriteLine($"{firstBook.ToString()} equals");
            Console.WriteLine($"{ fourthBook.ToString()}");
            Console.WriteLine(firstBook.Equals(fourthBook));

            Console.WriteLine($"{firstBook.ToString()} compare to");
            Console.WriteLine($"{ secondBook.ToString()}");
            Console.WriteLine(firstBook.CompareTo(secondBook));
            Console.WriteLine($"{firstBook.ToString()} compare to");
            Console.WriteLine($"{ thirdBook.ToString()}");
            Console.WriteLine(firstBook.CompareTo(thirdBook));
            Console.WriteLine($"{firstBook.ToString()} compare to");
            Console.WriteLine($"{ fourthBook.ToString()}");
            Console.WriteLine(firstBook.CompareTo(fourthBook));
            Console.WriteLine($"{fifthBook.ToString()} compare to");
            Console.WriteLine($"{ fourthBook.ToString()}");
            Console.WriteLine(fifthBook.CompareTo(fourthBook));

            Console.WriteLine($"first {firstBook.GetHashCode()}");
            Console.WriteLine($"second {secondBook.GetHashCode()}");
            Console.WriteLine($"third {thirdBook.GetHashCode()}");
            Console.WriteLine($"fourth {fourthBook.GetHashCode()}");
            Console.WriteLine($"fifth {fifthBook.GetHashCode()}");

            BookListService bookList = new BookListService();
            bookList.AddBook(firstBook);
            bookList.AddBook(fourthBook);
            bookList.AddBook(fifthBook);

            Console.WriteLine();
            bookList.RemoveBook(firstBook);

            bookList.AddBook(firstBook);

            Console.WriteLine();
            Console.WriteLine("FindBookByTag");
            Console.WriteLine(bookList.FindBookByTag(x => x.Author == "Tolstoy"));
            Console.WriteLine(bookList.FindBookByTag(x => x.Genre.Contains("Satirical")));
            Console.WriteLine(bookList.FindBookByTag(x => x.Year < 2000));

            Console.WriteLine();
            Console.WriteLine("SortByTitle");
            bookList.SortBooksByTag((x, y) => x.Title.CompareTo(y.Title));

            Console.WriteLine();
            Console.WriteLine("SortByYear");
            bookList.SortBooksByTag((x, y) => x.Year.CompareTo(y.Year));

            Console.WriteLine();
            Console.WriteLine("SortByGenre");
            bookList.SortBooksByTag((x, y) => x.Genre.CompareTo(y.Genre));

            Console.ReadLine();
        }
    }
}
