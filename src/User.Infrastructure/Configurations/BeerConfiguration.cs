using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.Entities;
using User.Infrastructure.Configurations.Common;

namespace User.Infrastructure.Configurations
{
    internal sealed class BeerConfiguration : BaseEntityTypeConfiguration<Beer>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Beer> builder)
        {
            base.ConfigureEntity(builder);

            builder
                .Property(beer => beer.Name)
                .IsRequired();

            builder
                .Property(beer => beer.ExternalId)
                .IsRequired();

            builder
                .HasMany(beer => beer.UserRates)
                .WithOne(rate => rate.Beer)
                .HasForeignKey(rate => rate.BeerId);
        }
    }
}