using System.Collections.Generic;
using todonote.Models;

namespace todonote.Data
{
    public class SQLNoteRepository : INoteRepository
    {
        private readonly NoteContext context;
        public SQLNoteRepository(NoteContext context)
        {
            this.context = context;
        }
        public IEnumerable<Note> GetAllNote(){
            return context.Notes;
        }

        public Note Add(Note note){
            context.Notes.Add(note);
            context.SaveChanges();
            return note;
        }
        public Note GetNote(int id){
            return context.Notes.Find(id);
        }
        public Note Update(Note noteChange){
            var note = context.Notes.Attach(noteChange);
            note.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return noteChange;
        }

        public Note Delete(int id){
            Note note = context.Notes.Find(id);
            if(note != null){
                context.Notes.Remove(note);
                context.SaveChanges();
            }
            return note;
        }
    }
}