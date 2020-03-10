using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace todonote.ViewModels
{
    public class NoteCreateViewModel
    {
        [Required]
        public string Content { get; set; }
         [Required]
        [MaxLength(50, ErrorMessage = "Author cannot exceed 50 characters")]
        public string Author { get; set; }
        public IFormFile Photo { get; set; }
    }
}