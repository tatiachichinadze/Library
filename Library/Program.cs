
using System.Security.Cryptography.X509Certificates;

class Book

{

    public string Title { get; set; }

    public string Author { get; set; }

    public int Year { get; set; }

    public string Genre { get; set; }

    public string Publisher { get; set; }

    public string Language { get; set; }

    public int Pages { get; set; }

    public Book(string title, string author, int year, string genre, string publisher, string language, int pages)

    {
        Title = title;
        Author = author;
        Year = year;
        Genre = genre;
        Publisher = publisher;
        Language = language;
        Pages = pages;
    }

}


class Library

{

    private List<Book> books = new List<Book>();

    public void BookTitlesAndAuthors()
    {
        Console.WriteLine("Books in the library:");

        foreach (var book in books)
        {
            Console.WriteLine($"{book.Title} ; {book.Author}");
        }
    }


    public int Count => books.Count;

    public void AddBook(Book book)
    {
        books.Add(book);
        Library library = new Library();
    }

    public void RemoveBook(Book book)

    {
        books.Remove(book);
    }

    public List<Book> FindBooksByTitle(string title)
    {
        return books.FindAll(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

}

class Program

{

    static void Main()

    {

        Library library = new Library();

        library.AddBook(new Book("The Unbearable Lightness of Being", "Milan Kundera", 1984, "Philosophical Fiction", "Harper & Row", "English", 320));
        library.AddBook(new Book("Jane Eyre", "Charlotte Brontë", 1847, "Gothic Fiction", "Smith, Elder & Co.", "English", 500));
        library.AddBook(new Book("The Man Who Laughs", "Victor Hugo", 1869, "Historical Fiction", "Léon Gozlan", "English", 400));
        library.AddBook(new Book("Jane Eyre", "author", 1900, "Genre", "Publisher", "language", 200));

        library.BookTitlesAndAuthors();

        Console.WriteLine("Enter the details of the new book:");


        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("Year: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        Console.Write("Publisher: ");
        string publisher = Console.ReadLine();

        Console.Write("Language: ");
        string language = Console.ReadLine();

        Console.Write("Pages: ");
        int pages = int.Parse(Console.ReadLine());

        Book newBook = new Book(title, author, year, genre, publisher, language, pages);
        library.AddBook(newBook);

        Console.WriteLine($"Added new book: {newBook.Title} by {newBook.Author}");
        Console.WriteLine($"Total books after addition: {library.Count}");
        library.BookTitlesAndAuthors();

        Console.Write("Enter the title of the book to search: ");
        string searchTitle = Console.ReadLine();

        List<Book> foundBooks = library.FindBooksByTitle(searchTitle);

        if (foundBooks.Count > 0)
        {
            Console.WriteLine($"Found {foundBooks.Count} book(s) with the title '{searchTitle}':");
            foreach (var book in foundBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }
        else
        {
            Console.WriteLine("No books found with that title.");

        }
        Console.Write("Enter the title of the book to remove: ");
        string removeTitle = Console.ReadLine();

        List<Book> booksToRemove = library.FindBooksByTitle(removeTitle);

        if (booksToRemove.Count > 0)
        {
            foreach (var book in booksToRemove)
            {
                library.RemoveBook(book);
                Console.WriteLine($"Removed book: {book.Title} by {book.Author}");
            }
        }
        else
        {
            Console.WriteLine("No books found with that title.");
        }


        Console.WriteLine($"Total books after removal: {library.Count}");
        library.BookTitlesAndAuthors();
    }
}

