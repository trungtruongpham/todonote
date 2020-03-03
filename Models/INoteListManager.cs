using System.Collections.Generic;
namespace todonote.Models
{
    public interface INoteListManager
    {
         public Note GetNote(int id);
        public IEnumerable<Note> GetAllNote();
        public void UpdateNote(Note newNote);
    }
}