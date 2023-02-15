using Crypto.Model;
using Microsoft.EntityFrameworkCore;

namespace Currency.Persistence;

public class DataContext:DbContext
{
    public DataContext()
    {
        
    }

    public DataContext(DbContextOptions<DataContext> options) 
        : base(options)
    {
        
    }

    public DbSet<CurrencyResponse> Currency { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.Currency());
    }
    
}
    
