using todonote.Models;
using System.Linq;

namespace todonote.Data
{
    public class DbInitializer
    {
        public static void Initialize(NoteContext context){
            context.Database.EnsureCreated();

            if(context.Notes.Any()){
                return; 
            }

            var notes = new Note[]
            {
                new Note{Content="Test database", Author="Pham Trung Truong"},
                new Note{Content="Test database", Author="Pham Trung Truong"},
                new Note{Content="Test database", Author="Pham Trung Truong"},
                new Note{Content="Test database", Author="Pham Trung Truong"},
                new Note{Content="Test database", Author="Pham Trung Truong"},
            };

            foreach(Note n in notes){
                context.Notes.Add(n);
            }
            context.SaveChanges();
        }
    }
}