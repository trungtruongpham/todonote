using System.Collections.Generic;
using todonote.Models;



namespace todonote.Data
{
    public interface INoteRepository
    {
        Note GetNote(int id);
        IEnumerable<Note> GetAllNote();
        Note Add(Note note);
        Note Update(Note noteChange);
        Note Delete(int id);
    } 
}