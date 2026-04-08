namespace LibraryAppInteractive;

public class LibraryAsset
{
    #region Feilds

    private Book _book;
    private int _libID;
    private AssetStatus _status;
    private LoanPeriod _loanPeriod;

    #endregion

    #region Constructor

    public LibraryAsset(int libID, Book book)
    {
        _libID = libID;
        _book = book;
    }

    #endregion

    #region Properties

    public int LibID
    {
        get { return _libID; }
        set { _libID = value; }
    }

    public AssetStatus Status
    {
        get { return _status; }
        set { _status = value; }
    }

    public LoanPeriod Loan
    {
        get { return _loanPeriod; }
        set { _loanPeriod = value; }
    }

    #endregion

}