using System.ComponentModel.DataAnnotations;

namespace ProjektSklep.Models
{
    public class Category
    {
        [Key]
        public string Kategoria { get; set; }
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
