using System.ComponentModel.DataAnnotations;

namespace todonote.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}