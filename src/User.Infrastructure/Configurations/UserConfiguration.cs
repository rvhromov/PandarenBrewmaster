using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Infrastructure.Configurations.Common;

namespace User.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : BaseEntityTypeConfiguration<Domain.Entities.User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.User> builder)
        {
            base.ConfigureEntity(builder);

            builder
                .Property(user => user.UserName)
                .IsRequired();
            
            builder
                .Property(user => user.PasswordHash)
                .IsRequired();

            builder
                .HasMany(user => user.BeerRates)
                .WithOne(rate => rate.User)
                .HasForeignKey(rate => rate.UserId);
        }
    }
}