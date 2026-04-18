using LibraryLogic;

namespace LibraryAppInteractive;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<Library>();
        builder.Services.AddTransient<LibraryAdminPage>();
        builder.Services.AddTransient<LibraryBrowsePage>();

        return builder.Build();
    }
}
