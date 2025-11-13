using System.Collections.ObjectModel;
using System.Windows.Input;
using LifeManagementApp.Models;
using Microsoft.Maui.Controls;

namespace LifeManagementApp.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {
        private string _newTitle = string.Empty;
        private string _newText = string.Empty;

        public ObservableCollection<Note> Notes { get; } = new();

        public string NewTitle
        {
            get => _newTitle;
            set => SetProperty(ref _newTitle, value);
        }

        public string NewText
        {
            get => _newText;
            set => SetProperty(ref _newText, value);
        }

        public ICommand AddNoteCommand { get; }
        public ICommand DeleteNoteCommand { get; }

        public NotesViewModel()
        {
            // Testidata: näkyykö edes tämä listassa?
            Notes.Add(new Note
            {
                Title = "Testi",
                Text = "Tämä on testimuistiinpano",
                CreatedAt = DateTime.Now
            });

            AddNoteCommand = new Command(AddNote);
            DeleteNoteCommand = new Command<Note>(DeleteNote);
        }

        private void AddNote()
        {
            if (string.IsNullOrWhiteSpace(NewTitle) &&
                string.IsNullOrWhiteSpace(NewText))
                return;

            Notes.Add(new Note
            {
                Title = NewTitle,
                Text = NewText,
                CreatedAt = DateTime.Now
            });

            NewTitle = string.Empty;
            NewText = string.Empty;
        }

        private void DeleteNote(Note note)
        {
            if (note == null)
                return;

            if (Notes.Contains(note))
                Notes.Remove(note);
        }
    }
}
