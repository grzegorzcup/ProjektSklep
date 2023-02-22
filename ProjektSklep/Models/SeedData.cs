using Microsoft.EntityFrameworkCore;
using ProjektSklep.Data;
using ProjektSklep.Controllers;
using System.Drawing.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ProjektSklep.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjektSklepContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<ProjektSklepContext>>()))
            {

                // sprawdzamy czy są już jakieś dane w bazie dla Movies.
                if (context.Products.Any())
                {
                    return; // jeżeli tak, to dane zostały już dodane.
                }
                
                var Elektronika = new Category { Kategoria = "Elektronika" };
                var Moda = new Category { Kategoria = "Moda" };
                var Dzieci = new Category { Kategoria = "Dzieci" };
                var Sport = new Category { Kategoria = "Sport" };
                var Muzyka = new Category { Kategoria = "Muzyka" };
                var Edukacja = new Category { Kategoria = "Edukacja" };
                var Motoryzacja = new Category { Kategoria = "Motoryzacja" };

                context.Categories.AddRange(Elektronika, Moda, Dzieci, Sport, Muzyka, Edukacja, Motoryzacja);
                context.SaveChanges();

                context.Products.AddRange(
                new Product
                {
                    Name = "Galaxy S22 Ultra 5G",
                    Description = "Telefon ",
                    Category = Elektronika,
                    Cena = 4000,
                    Client = context.Clients.First(c=>c.UserName == "Admin")
                    
                },
                new Product
                {
                    Name = "Jeansy",
                    Description = "Spodnie ",
                    Category = Moda,
                    Cena = 20,
                    Client = context.Clients.First(c => c.UserName == "Admin")
                },
                new Product
                {
                    Name = "Traktor zabawka",
                    Description = "Zabawka ",
                    Category = Dzieci,
                    Cena = 100,
                    Client = context.Clients.First(c => c.UserName == "Admin")

                },
                new Product
                {
                    Name = "Piła siatkowa",
                    Description = "Piłka ",
                    Category = Sport,
                    Cena=240.99,
                    Client = context.Clients.First(c => c.UserName == "Admin")
                }
                );
                context.SaveChanges();
            }
        }

    }
}
