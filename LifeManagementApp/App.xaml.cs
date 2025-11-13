using Microsoft.Maui.Controls;

namespace LifeManagementApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Tämä korvaa vanhan MainPage = new AppShell();
        return new Window(new AppShell());
    }
}
