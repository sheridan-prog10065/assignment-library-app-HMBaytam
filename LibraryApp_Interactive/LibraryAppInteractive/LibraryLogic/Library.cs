using System.Diagnostics;

namespace LibraryAppInteractive;

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

    private List<Book> _booklist;
    private int _libDGeneratorSeed;
    private const int DEFAULT_LIBD_START = 100;

    #endregion

    #region Constructor

    public Library()
    {
        // TODO: Implement Logic
        Debug.Assert(false, "Logic not implemented");
    }

    #endregion

    #region Methods

    private void CreateDefaultBooks()
    {
        // TODO: Implement Logic
        Debug.Assert(false, "Logic not implemented");
    }

    private int DetermineLibID()
    {
        // TODO: Implement Logic
        Debug.Assert(false, "Logic not implemented");
        return 1;
    }

    public Book RegisterBook(string bookName, string bookISBN, List<string> authors, BookType bookType, int nCopies)
    {
        // TODO: Implement Logic
        Debug.Assert(false, "Logic not implemented");
        return new Book(bookName, bookISBN);
    }
    
    public Book FindBookByName(string bookName)
    {
        // TODO: Implement Logic
        Debug.Assert(false, "Logic not implemented");
    }

    public Book FindBookByISBN(string bookISBN)
    {
        // TODO: Implement Logic
        Debug.Assert(false, "Logic not implemented");
    }
    
    #endregion

   
}