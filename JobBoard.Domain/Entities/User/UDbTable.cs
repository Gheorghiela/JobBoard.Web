using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Domain.Entities.User
{
    public class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Username must be less than 30 characters")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Password must be more than 8 characters")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [StringLength(30)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
         public DateTime LastLogin { get; set; }

        [StringLength(30)]
        public string LastIp { get; set; }

        public URole Level { get; set; }

    }
}
