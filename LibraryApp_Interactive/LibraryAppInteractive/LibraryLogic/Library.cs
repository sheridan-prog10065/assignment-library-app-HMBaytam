using System.Collections.ObjectModel;

namespace LibraryLogic;

/// <summary>
/// Defines the Library class used to manage the library books and assets.
///
/// NOTE: A single object/instance of this class (called a "singleton") is created and shared automatically
/// with the two pages in the application through the process of Dependency Injection handled and configured
/// in MauiProgram class.
/// </summary>
public class Library
{
    #region Feilds

    private ObservableCollection<Book> _booklist;
    private int _libDGeneratorSeed;
    private const int DEFAULT_LIBD_START = 100;

    #endregion

    #region Properties

    public ObservableCollection<Book> Books
    {
        get { return _booklist; }
    }

    #endregion

    #region Constructor

    public Library()
    {
        _booklist = new ObservableCollection<Book>();
        _libDGeneratorSeed = DEFAULT_LIBD_START;
        CreateDefaultBooks();
    }

    #endregion

    #region Methods

    private void CreateDefaultBooks()
    {
        RegisterBook("The Great Gatsby", "978-0743273565", new List<string> { "F. Scott Fitzgerald" }, BookType.Paper, 2);
        RegisterBook("Clean Code", "978-0132350884", new List<string> { "Robert C. Martin" }, BookType.Paper, 2);
        RegisterBook("Dune", "978-0441013593", new List<string> { "Frank Herbert" }, BookType.Paper, 2);
    }

    private int DetermineLibID()
    {
        return ++_libDGeneratorSeed;
    }

    public Book RegisterBook(string bookName, string bookISBN, List<string> authors, BookType bookType, int nCopies)
    {
        Book book = new Book(bookName, bookISBN);
        book.Authors = authors;

        List<LibraryAsset> assets = new List<LibraryAsset>();
        for (int i = 0; i < nCopies; i++)
        {
            LibraryAsset asset = new LibraryAsset(DetermineLibID(), book);
            assets.Add(asset);
        }
        book.Assets = assets;

        _booklist.Add(book);
        return book;
    }

    public Book FindBookByName(string bookName)
    {
        foreach (Book book in _booklist)
        {
            if (string.Equals(book.Name, bookName, StringComparison.OrdinalIgnoreCase))
                return book;
        }
        return null;
    }

    public Book FindBookByISBN(string bookISBN)
    {
        foreach (Book book in _booklist)
        {
            if (book.ISBN == bookISBN)
                return book;
        }
        return null;
    }
    
    #endregion
}
