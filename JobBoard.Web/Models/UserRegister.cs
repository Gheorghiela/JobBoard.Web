using System.ComponentModel.DataAnnotations;

namespace JobBoard.Web.Models
{
    public class UserRegister
    {
        [Required]
        [Display(Name = "Nume de utilizator")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}