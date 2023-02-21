using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSklep.Models
{
    public class Login
    {
        [Required]
        public string? userName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}