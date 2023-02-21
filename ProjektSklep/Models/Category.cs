using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjektSklep.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Kategoria { get; set; }

        public IEnumerable<Product> Products { get; set; }

        


        /*public enum Category
        {
            Elektronika,
            Moda,
            Dzieci,
            Sport,
            Muzyka,
            Edukacja,
            Motoryzacja
        }*/
    }
    
}
