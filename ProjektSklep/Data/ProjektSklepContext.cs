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
        public DbSet<ProjektSklep.Models.Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //seed role
            List<IdentityRole> roles = new List<IdentityRole>();
            roles.Add(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            });
            roles.Add(new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
            });
            builder.Entity<IdentityRole>().HasData(roles);


            //create user
            var appuser1 = new Client
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Imie = "Admin",
                Nazwisko = "Admin",
                PhoneNumber = "123456789",
                Email = "Admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM"

            };
            var appuser2 = new Client
            {
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Imie = "Guest",
                Nazwisko = "Guest",
                PhoneNumber = "123456",
                Email = "Guest@guest.pl",
                NormalizedEmail = "GUEST@GUEST.PL"
            };
            var appuser3 = new Client
            {
                UserName = "marek200",
                NormalizedUserName = "MAREK200",
                Imie = "Marek",
                Nazwisko = "Kowalski",
                PhoneNumber = "123456",
                Email = "marek.kowalski@gmail.com",
                NormalizedEmail = "MAREK.KOWALSKI@GMAIL.COM"

            };

            List<Client> clients = new List<Client>();
            clients.Add(appuser1);
            clients.Add(appuser2);
            clients.Add(appuser3);


            //seed user
            builder.Entity<Client>().HasData(clients);

            //set user password
            PasswordHasher<Client> ph = new PasswordHasher<Client>();

            clients[0].PasswordHash = ph.HashPassword(clients[0], "admin");

            clients[1].PasswordHash = ph.HashPassword(clients[1], "guest");

            clients[2].PasswordHash = ph.HashPassword(clients[2], "marek200");


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roles.First(q => q.Name == "Admin").Id,
                UserId = clients[0].Id
                
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roles.First(q => q.Name == "User").Id,
                UserId = clients[1].Id

            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roles.First(q => q.Name == "User").Id,
                UserId = clients[2].Id

            });




            builder.Entity<Product>().HasOne<Client>(c => c.Client).WithMany(d => d.products).IsRequired();


        }



    }


}
