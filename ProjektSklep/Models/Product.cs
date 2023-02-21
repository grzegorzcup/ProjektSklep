using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace ProjektSklep.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Display(Name ="Nazwa Produktu")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [DataType(DataType.Text)]
        public string? Description { get; set; }
        [Required]
        public double Cena { get; set; }
        public Category? Category { get; set; }

        public  Client Client { get; set; } 

        public int ClientID { get; set; }

    }
}
