using LifeManagementApp.ViewModels;

namespace LifeManagementApp.Views;

public partial class NotesPage : ContentPage
{
    public NotesPage()
    {
        InitializeComponent();
        BindingContext = new NotesViewModel(); // TÄRKEÄ!
    }
}
