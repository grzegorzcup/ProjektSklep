using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace ProjektSklep.Models
{
    public class Client
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }

        [Display(Name ="Login")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Display(Name ="Hasło")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Display(Name ="Imie")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Imie { get; set;}

        [Display(Name = "Nazwisko")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Nazwisko { get; set; }

        [Display(Name = "Numer Telefonu")]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }

        [Display(Name ="Email")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Required(ErrorMessage = "Proszę podać poprawny eamil!")]
        public string Email { get; set; }

    }
}
