using System.Diagnostics;

namespace LibraryAppInteractive;

public class Book
{
    #region Feilds

    private string _bookName;
    private string _bookISBN;
    private List<string> _bookAuthorList;
    private List<LibraryAsset> _libAssetList;

    #endregion

    #region Constructors
    
    public Book(string bookName, string bookISBN)
    {
        _bookName = bookName;
        _bookISBN = bookISBN;
    }
    
    #endregion

    #region Properties

    public string Name
    {
        get { return _bookName; }
        set { _bookName = value; }
    }
    

    public string ISBN
    {
        get { return _bookISBN; }
        set { _bookISBN = value; }
    }

    public List<string> Authors
    {
        get { return _bookAuthorList; }
        set { _bookAuthorList = value; }
    }

    public List<LibraryAsset> Assets
    {
        get { return _libAssetList; }
        set { _libAssetList = value; }
    }

    #endregion

    #region Methods

    public (bool, LibraryAsset) CheckAvailability()
    {
        // TODO: Implement Logic
        // make sure the return type is (bool, LibraryAsset)
        Debug.Assert(false, "Logic not implemented");
    }

    public LibraryAsset BorrowBook()
    {
        // TODO: Implement Logic
        Debug.Assert(false, "Logic not implemented");
    }

    public (TimeSpan, int, decimal) ReturnBook(int libID)
    {
        // TODO: Implement Logic
        // make sure the return type is (TimeSpan, int, decimal)
        Debug.Assert(false, "Logic not implemented");
    }
    public LibraryAsset ReserveBook()
    {
        // TODO: Implement Logic
        Debug.Assert(false, "Logic not implemented");
    }

    private LibraryAsset findLibraryAsser(int libID)
    {
        // TODO: Implement Logic
        Debug.Assert(false, "Logic not implemented");
    }

    private LibraryAsset findNextAvailableAsset()
    {
        // TODO: Implement Logic
        Debug.Assert(false, "Logic not implemented");
    }

    #endregion
}