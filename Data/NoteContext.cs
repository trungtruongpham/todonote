using todonote.Models;
using Microsoft.EntityFrameworkCore;

namespace todonote.Data
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options){

        }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder moderbuilder){
            moderbuilder.Entity<Note>().ToTable("Note");
        }
    }
}