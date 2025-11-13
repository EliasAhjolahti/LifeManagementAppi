using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifeManagementApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand OpenNotesCommand { get; }

        public HomeViewModel()
        {
            OpenNotesCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("///NotesPage");
            });
        }
    }
}

