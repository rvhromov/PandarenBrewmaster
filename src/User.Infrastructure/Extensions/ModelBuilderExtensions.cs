using Microsoft.EntityFrameworkCore;

namespace User.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Domain.Entities.User>()
                .HasData(
                    new Domain.Entities.User
                    {
                        Id = 1,
                        UserName = "KeshaWildbarley",
                        PasswordHash = "dtVujawDMtV59t0l2B7XTFGVwglZmgBk1mtjQCJwBEg="
                    },
                    new Domain.Entities.User
                    {
                        Id = 2,
                        UserName = "ModiStonesmith",
                        PasswordHash = "1suO4jm61BOZsdWFt4i/zEVwW4oqM8QR7R4oXfwED/Q=",
                    },
                    new Domain.Entities.User
                    {
                        Id = 3,
                        UserName = "Samuro",
                        PasswordHash = "M8ibmf/0LsnTuVDora2po2TmqneEL6SJgMN9ETIjh/w="
                    });
        }
    }
}