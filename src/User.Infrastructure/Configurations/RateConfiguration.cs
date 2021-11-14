using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.Entities;
using User.Infrastructure.Configurations.Common;

namespace User.Infrastructure.Configurations
{
    internal sealed class RateConfiguration : BaseEntityTypeConfiguration<Rate>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Rate> builder)
        {
            base.ConfigureEntity(builder);

            builder
                .HasOne(rate => rate.Beer)
                .WithMany(beer => beer.UserRates)
                .HasForeignKey(rate => rate.BeerId);
            
            builder
                .HasOne(rate => rate.User)
                .WithMany(user => user.BeerRates)
                .HasForeignKey(rate => rate.UserId);
        }
    }
}