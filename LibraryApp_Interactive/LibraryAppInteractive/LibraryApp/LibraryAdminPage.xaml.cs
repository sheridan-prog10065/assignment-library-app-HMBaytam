using LibraryLogic;

namespace LibraryAppInteractive;

public partial class LibraryAdminPage : ContentPage
{
    private Library _library;

    public LibraryAdminPage(Library library)
    {
        _library = library;
        InitializeComponent();
        _lstBooks.ItemsSource = library.Books;
    }

    private async void OnRegisterBook(object sender, EventArgs e)
    {
        string name = _entryName.Text?.Trim();
        string isbn = _entryISBN.Text?.Trim();
        string authorsRaw = _entryAuthors.Text?.Trim();
        int bookTypeIndex = _pickerBookType.SelectedIndex;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(isbn) ||
            string.IsNullOrEmpty(authorsRaw) || bookTypeIndex < 0)
        {
            await DisplayAlert("Missing Info", "Please fill in all fields and select a book type.", "OK");
            return;
        }

        if (_library.FindBookByISBN(isbn) != null)
        {
            await DisplayAlert("Duplicate ISBN", $"A book with ISBN '{isbn}' already exists.", "OK");
            return;
        }

        BookType bookType = (BookType)(bookTypeIndex + 1);
        List<string> authors = new List<string>();
        foreach (string author in authorsRaw.Split(','))
            authors.Add(author.Trim());

        _library.RegisterBook(name, isbn, authors, bookType, 1);

        _entryName.Text = string.Empty;
        _entryISBN.Text = string.Empty;
        _entryAuthors.Text = string.Empty;
        _pickerBookType.SelectedIndex = -1;

        _lstBooks.ItemsSource = null;
        _lstBooks.ItemsSource = _library.Books;
    }
}
