using System.Diagnostics;

namespace LibraryLogic;

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
        _bookAuthorList = new List<string>();
        _libAssetList = new List<LibraryAsset>();
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

    public int AvailableCopies
    {
        get
        {
            int count = 0;
            foreach (LibraryAsset asset in _libAssetList)
            {
                if (asset.Status == AssetStatus.Available)
                    count++;
            }
            return count;
        }
    }

    #endregion

    #region Methods

    public (bool, LibraryAsset) CheckAvailability()
    {
        LibraryAsset asset = findNextAvailableAsset();
        if (asset != null)
            return (true, asset);
        return (false, null);
    }

    public LibraryAsset BorrowBook()
    {
        LibraryAsset asset = findNextAvailableAsset();
        if (asset == null)
            return null;

        asset.Status = AssetStatus.Loaned;
        LoanPeriod loan = new LoanPeriod(DateTime.Now, DateTime.MinValue);
        loan.DueDate = DateTime.Now.AddDays(14);
        asset.Loan = loan;
        return asset;
    }

    public (TimeSpan, int, decimal) ReturnBook(int libID)
    {
        LibraryAsset asset = findLibraryAsser(libID);

        LoanPeriod loan = asset.Loan;
        loan.ReturnedOn = DateTime.Now;
        asset.Loan = loan;
        asset.Status = AssetStatus.Available;

        TimeSpan timeSpan = loan.ReturnedOn - loan.BorrowedOn;

        decimal fine = 0m;
        if (loan.ReturnedOn > loan.DueDate)
        {
            int daysOverdue = (int)(loan.ReturnedOn - loan.DueDate).TotalDays;
            fine = daysOverdue * 0.25m;
        }

        return (timeSpan, libID, fine);
    }

    public LibraryAsset ReserveBook()
    {
        LibraryAsset asset = findNextAvailableAsset();
        if (asset == null)
            return null;

        asset.Status = AssetStatus.Reserved;
        return asset;
    }

    private LibraryAsset findLibraryAsser(int libID)
    {
        foreach (LibraryAsset asset in _libAssetList)
        {
            if (asset.LibID == libID)
                return asset;
        }
        return null;
    }

    private LibraryAsset findNextAvailableAsset()
    {
        foreach (LibraryAsset asset in _libAssetList)
        {
            if (asset.Status == AssetStatus.Available)
                return asset;
        }
        return null;
    }
    
    public override string ToString()
    {
        return $"{_bookName}, ISBN:{_bookISBN}";
    }
    #endregion
}
