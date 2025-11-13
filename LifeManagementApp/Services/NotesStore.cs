using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services
{
    public static class NotesStore
    {
        // Yksi ja sama lista koko sovelluksessa
        public static ObservableCollection<Note> Notes { get; } = new();
    }
}