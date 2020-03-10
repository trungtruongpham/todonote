using todonote.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace todonote.Data
{
    public class NoteContext : IdentityDbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options){

        }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder moderbuilder){
            base.OnModelCreating(moderbuilder);
            moderbuilder.Entity<Note>().ToTable("Note");
        }
    }
}