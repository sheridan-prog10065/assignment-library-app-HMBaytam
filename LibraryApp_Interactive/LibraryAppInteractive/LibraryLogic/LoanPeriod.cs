namespace LibraryAppInteractive;

public struct LoanPeriod
{
    #region Feilds

    private DateTime _borrowedOn;
    private DateTime _returnedOn;
    private DateTime _dueDate;

    #endregion

    #region Constructor

    public LoanPeriod(DateTime borrowedOn, DateTime returnedOn)
    {
        _borrowedOn = borrowedOn;
        _returnedOn = returnedOn;
    }

    #endregion

    #region Properties

    public DateTime BorrowedOn
    {
        get { return _borrowedOn; }
        set { _borrowedOn = value; }
    }

    public DateTime ReturnedOn
    {
        get { return _returnedOn; }
        set { _returnedOn = value; }
    }
    
    #endregion
}