using System.ComponentModel.DataAnnotations;

namespace EasyAuth.Models.ViewModels
{
    public class TokenViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide token")]
        public string? Token { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide role")]
        public string? Role { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide expires date")]
        public DateTime Expires {  get; set; }
    }
}
