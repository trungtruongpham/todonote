using Microsoft.AspNetCore.Http;

namespace todonote.ViewModels
{
    public class NoteCreateViewModel
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public IFormFile Photo { get; set; }
    }
}