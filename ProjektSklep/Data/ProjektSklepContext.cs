using Microsoft.EntityFrameworkCore;
using ProjektSklep.Models;
using Microsoft.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProjektSklep.Data
{
    public class ProjektSklepContext : IdentityDbContext<Client>
    {
        public ProjektSklepContext(DbContextOptions<ProjektSklepContext> options) : base(options) { }
        public DbSet<ProjektSklep.Models.Product> Products { get; set; } = default!;
        public DbSet<ProjektSklep.Models.Client> Clients { get; set; } = default!;
        public DbSet<ProjektSklep.Models.Order> Orders { get; set; } = default!;
        public DbSet<ProjektSklep.Models.Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                ConcurrencyStamp ="1",
                NormalizedName= "ADMIN",
            }, new IdentityRole
            {
                Name = "User",
                ConcurrencyStamp = "2",
                NormalizedName = "USER",
            }
            );

            //create user
            var appuser1 =new Client
            {
                UserName = "admin",
                Imie = "Admin",
                Nazwisko = "Admin",
                PhoneNumber = "Admin",
                Email = "Admin@admin.com"
            };
            var appuser2 = new Client
            {
                UserName = "guest",
                Imie = "Guest",
                Nazwisko = "Guest",
                PhoneNumber = "123456",
                Email = "Guest@guest.pl"
            };
            var appuser3 = new Client
            {
                UserName = "marek200",
                Imie = "Marek",
                Nazwisko = "Kowalski",
                PhoneNumber = "123456",
                Email = "marek.kowalski@gmail.com"
            };

            //set user password
            PasswordHasher<Client> ph = new PasswordHasher<Client>();

            appuser1.PasswordHash = ph.HashPassword(appuser1, "admin");

            appuser1.PasswordHash = ph.HashPassword(appuser1, "guest");

            appuser1.PasswordHash = ph.HashPassword(appuser1, "marek200");

            //seed user
            builder.Entity<Client>().HasData(appuser1);
            builder.Entity<Client>().HasData(appuser2);
            builder.Entity<Client>().HasData(appuser3);




        }



    }


}
