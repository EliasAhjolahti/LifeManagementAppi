using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using LifeManagementApp.Models;
using Microsoft.Maui.Storage;
using System.IO;
using System.Linq;

namespace LifeManagementApp.Services
{
    public static class NotesStore
    {
        private const string FileName = "notes.json";

        public static ObservableCollection<Note> Notes { get; } = new();

        // Staattinen konstruktori – ajetaan kerran kun luokkaa käytetään ensimmäisen kerran
        static NotesStore()
        {
            // Lataa tiedostosta
            Load();

            // Aina kun collection muuttuu (add/remove), tallennetaan
            Notes.CollectionChanged += (_, __) => Save();
        }

        public static void Load()
        {
            try
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, FileName);

                if (!File.Exists(path))
                    return; // ei vielä tallennettua dataa

                string json = File.ReadAllText(path);
                var items = JsonSerializer.Deserialize<List<Note>>(json);

                if (items == null)
                    return;

                Notes.Clear();
                foreach (var note in items)
                {
                    Notes.Add(note);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading notes: {ex}");
            }
        }

        public static void Save()
        {
            try
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, FileName);

                var list = Notes.ToList();
                var json = JsonSerializer.Serialize(
                    list,
                    new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving notes: {ex}");
            }
        }
    }
}
