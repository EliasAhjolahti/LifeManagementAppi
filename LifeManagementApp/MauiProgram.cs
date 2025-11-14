using LifeManagementApp.ViewModels;
using LifeManagementApp.Views;
using LifeManagementApp.Interfaces;
using LifeManagementApp.Services;   
using Microsoft.Extensions.DependencyInjection;


namespace LifeManagementApp;

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

        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<IJokeService, JokeApiService>();

        // ViewModels
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddTransient<NotesViewModel>();

        // Views
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddTransient<NotesPage>();

        return builder.Build();
    }
}
