using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using LifeManagementApp.Interfaces;
using Microsoft.Maui.Controls;

namespace LifeManagementApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IJokeService _jokeService;

        private string _jokeOfTheDay = "Loading joke...";

        public string JokeOfTheDay
        {
            get => _jokeOfTheDay;
            set => SetProperty(ref _jokeOfTheDay, value);
        }

        public ICommand OpenNotesCommand { get; }
        public ICommand LoadJokeCommand { get; }

        public HomeViewModel(IJokeService jokeService)
        {
            _jokeService = jokeService;

            OpenNotesCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("///NotesPage");
            });

            LoadJokeCommand = new Command(async () => await LoadJokeAsync());

            _ = LoadJokeAsync();
        }

        private async Task LoadJokeAsync()
        {
            try
            {
                var jokes = await _jokeService.GetJokesAsync(1);
                JokeOfTheDay = jokes.FirstOrDefault()?.ToString() ?? "No joke today 🙃";
            }
            catch (Exception ex)
            {
                JokeOfTheDay = $"Error loading joke: {ex.Message}";
            }
        }
    }
}
