using Crypto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Currency.Persistence.EntityTypeConfiguration;

public class Currency:IEntityTypeConfiguration<CurrencyResponse>
{
    public void Configure(EntityTypeBuilder<CurrencyResponse> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Symbol).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Rank).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.MaxSupply).IsRequired(false);
        builder.Property(x => x.CirculatingSupply).IsRequired(false);
        builder.Property(x => x.Explorer).IsRequired(false);
    }
}