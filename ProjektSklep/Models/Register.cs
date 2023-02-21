using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSklep.Models
{
    public class Register
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }


        [Required]
        public string? Password { get; set; }
    }
}