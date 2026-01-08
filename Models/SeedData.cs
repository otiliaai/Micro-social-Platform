using MicroSocialPlatform.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MicroSocialPlatform.Models
{
    public static class SeedData
    {
<<<<<<< HEAD
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Daca exista deja roluri, nu mai seed-uim
                if (context.Roles.Any())
                {
                    return;
                }

                // CREARE ROLURI
                context.Roles.AddRange(
                    new IdentityRole { Id = "role-admin", Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id = "role-user", Name = "User", NormalizedName = "USER" }
                );

                var hasher = new PasswordHasher<ApplicationUser>();

                // CREARE UTILIZATORI
                context.Users.AddRange(
                    new ApplicationUser
                    {
                        Id = "admin-id",
                        UserName = "admin@test.com",
                        Email = "admin@test.com",
                        NormalizedEmail = "ADMIN@TEST.COM",
                        NormalizedUserName = "ADMIN@TEST.COM",
                        FirstName = "Admin",
                        LastName = "System",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Admin1!"),
                        Description = "System Administrator Account",
                        ProfileImage = "/images/default.png"
                    },
                    new ApplicationUser
                    {
                        Id = "user1-id",
                        UserName = "user1@test.com",
                        Email = "user1@test.com",
                        NormalizedEmail = "USER1@TEST.COM",
                        NormalizedUserName = "USER1@TEST.COM",
                        FirstName = "User",
                        LastName = "One",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "User1!"),
                        Description = "Default User 1",
                        ProfileImage = "/images/default.png"
                    },
                    new ApplicationUser
                    {
                        Id = "user2-id",
                        UserName = "user2@test.com",
                        Email = "user2@test.com",
                        NormalizedEmail = "USER2@TEST.COM",
                        NormalizedUserName = "USER2@TEST.COM",
                        FirstName = "User",
                        LastName = "Two",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "User1!"),
                        Description = "Default User 2",
                        ProfileImage = "/images/default.png"
                    }
                );

                // ASOCIERE USER ↔ ROLE
                context.UserRoles.AddRange(
                    new IdentityUserRole<string>
                    {
                        UserId = "admin-id",
                        RoleId = "role-admin"
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = "user1-id",
                        RoleId = "role-user"
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = "user2-id",
                        RoleId = "role-user"
                    }
                );

=======
        public static void Initialize(IServiceProvider
       serviceProvider)
        {
            using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService
            <DbContextOptions<ApplicationDbContext>>()))
            {
                // Verificam daca in baza de date exista cel putin un rol
                // insemnand ca a fost rulat codul
                // De aceea facem return pentru a nu insera rolurile inca o data
                // Acesta metoda trebuie sa se execute o singura data
 if (context.Roles.Any())
                {
                    return; // baza de date contine deja roluri
                }
                // CREAREA ROLURILOR IN BD
                // daca nu contine roluri, acestea se vor crea
                context.Roles.AddRange(
                new IdentityRole { Id = "2c5e174e-3b0e-446f-86af483d56fd7210", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2c5e174e-3b0e-446f-86af483d56fd7211", Name = "UnregisteredUser", NormalizedName = "UNREGISTEREDUSER" },
                new IdentityRole { Id = "2c5e174e-3b0e-446f-86af483d56fd7212", Name = "User", NormalizedName = "USER" }
                );

                 // o noua instanta pe care o vom utiliza pentru crearea parolelor utilizatorilor
                 // parolele sunt de tip hash
                 var hasher = new PasswordHasher<ApplicationUser>();

                // CREAREA USERILOR IN BD
                // Se creeaza cate un user pentru fiecare rol
                context.Users.AddRange(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb0",
                    // primary key
                    UserName = "admin@test.com",
                    FirstName = "Admin",
                    LastName = "System",
                    EmailConfirmed = true,
                    NormalizedEmail = "ADMIN@TEST.COM",
                    Email = "admin@test.com",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    PasswordHash = hasher.HashPassword(null,"Admin1!")
                },
               new ApplicationUser
               {
                   Id = "8e445865-a24d-4543-a6c6-9443d048cdb1",
                   // primary key
                   UserName = "unregistered@test.com",
                   FirstName = "Unregistered",
                   LastName = "User",
                   EmailConfirmed = true,
                   NormalizedEmail = "UNREGISTERED@TEST.COM",
                   Email = "unregistered@test.com",
                   NormalizedUserName = "UNREGISTERED@TEST.COM",
                   PasswordHash = hasher.HashPassword(null,"Unregistered1!")
               },
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb2",
                    // primary key
                    UserName = "user@test.com",
                    FirstName = "Standard",
                    LastName = "User",
                    EmailConfirmed = true,
                    NormalizedEmail = "USER@TEST.COM",
                    Email = "user@test.com",
                    NormalizedUserName = "USER@TEST.COM",
                    PasswordHash = hasher.HashPassword(null,"User1!")
                }
);
                // ASOCIEREA USER-ROLE
                context.UserRoles.AddRange(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb0"
                },
               new IdentityUserRole<string>
               {
                   RoleId = "2c5e174e-3b0e-446f-86af483d56fd7211",
                   UserId = "8e445865-a24d-4543-a6c6-9443d048cdb1"
               },
               new IdentityUserRole<string>
               {
                   RoleId = "2c5e174e-3b0e-446f-86af483d56fd7212",
                   UserId = "8e445865-a24d-4543-a6c6-9443d048cdb2"
               }
                );
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0
                context.SaveChanges();
            }
        }
    }
}
