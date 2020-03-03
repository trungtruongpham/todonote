using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todonote.Models {
    public class NoteListManager : INoteListManager {
        private List<Note> _noteList;
        public int _numberOfNotes { get; set; }

        public NoteListManager () {
            _noteList = new List<Note> () {
                new Note {Content = "test", Author = "Pham Trung Troung" }
            };
            _numberOfNotes = _noteList.Count ();
        }
        public Note GetNote (int id) {
            return _noteList.FirstOrDefault (n => n.ID == id);
        }

        public IEnumerable<Note> GetAllNote () {
            return _noteList;
        }

        public void UpdateNote (Note newNote) {
            foreach (var item in _noteList.Where (x => x.ID == newNote.ID)) {
                item.Content = newNote.Content;
                item.Author = newNote.Author;
            }
        }
    }
}