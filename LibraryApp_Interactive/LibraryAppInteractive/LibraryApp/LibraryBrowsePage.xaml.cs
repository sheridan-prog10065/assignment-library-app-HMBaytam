using LibraryLogic;

namespace LibraryAppInteractive;

public partial class LibraryBrowsePage : ContentPage
{
    private Library _library;

    public LibraryBrowsePage(Library library)
    {
        _library = library;
        InitializeComponent();
        _lstVehicleInventory.ItemsSource = library.Books;
    }

    private async void OnBorrowBook(object sender, EventArgs e)
    {
        Book selectedBook = _lstVehicleInventory.SelectedItem as Book;
        if (selectedBook == null)
        {
            await DisplayAlert("No Selection", "Please select a book to borrow.", "OK");
            return;
        }

        LibraryAsset asset = selectedBook.BorrowBook();
        if (asset == null)
        {
            await DisplayAlert("Unavailable", $"\"{selectedBook.Name}\" has no available copies.", "OK");
            return;
        }

        await DisplayAlert("Borrowed", $"\"{selectedBook.Name}\" borrowed! Due back by {asset.Loan.DueDate:d}.", "OK");

        RefreshLoansList();
    }

    private async void OnReturnBook(object sender, EventArgs e)
    {
        LibraryAsset selectedAsset = _lstBooks.SelectedItem as LibraryAsset;
        if (selectedAsset == null)
        {
            await DisplayAlert("No Selection", "Please select a loaned book to return.", "OK");
            return;
        }

        Book book = selectedAsset.Book;
        (TimeSpan duration, int libID, decimal fine) = book.ReturnBook(selectedAsset.LibID);

        string message = $"\"{book.Name}\" returned after {(int)duration.TotalDays} day(s).";
        if (fine > 0)
            message += $"\nLate fine: ${fine:F2}";

        await DisplayAlert("Returned", message, "OK");

        RefreshLoansList();
    }

    private void RefreshLoansList()
    {
        List<LibraryAsset> loanedAssets = new List<LibraryAsset>();
        foreach (Book book in _library.Books)
        {
            foreach (LibraryAsset asset in book.Assets)
            {
                if (asset.Status == AssetStatus.Loaned)
                    loanedAssets.Add(asset);
            }
        }
        _lstBooks.ItemsSource = null;
        _lstBooks.ItemsSource = loanedAssets;
    }
}
