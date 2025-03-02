using System.ComponentModel.DataAnnotations;

namespace EasyAuth.Models.ViewModels
{
    public class RoleViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Role Name")]
        public string? Role { get; set; }
    }
}
