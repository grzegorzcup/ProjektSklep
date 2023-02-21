using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using Microsoft.Identity;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace ProjektSklep.Models
{
    public class Client : IdentityUser
    {

        [Display(Name ="Login")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public override string? UserName { get; set; }

        [Display(Name ="Imie")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string? Imie { get; set;}

        [Display(Name = "Nazwisko")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string? Nazwisko { get; set; }
    }
}
