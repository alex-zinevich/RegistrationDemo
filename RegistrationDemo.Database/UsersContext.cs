using Microsoft.EntityFrameworkCore;
using RegistrationDemo.Database.Models;

namespace RegistrationDemo.Database;

public class UsersContext : DbContext
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Province> Provinces { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(b =>
            b.HasMany<Province>().WithOne().HasForeignKey(p => p.CountryId));

        modelBuilder.Entity<User>(b =>
            b.HasOne(u => u.Country).WithMany().HasForeignKey(u => u.CountryId));
        
        modelBuilder.Entity<User>(b =>
            b.HasOne(u => u.Province).WithMany().HasForeignKey(u => u.ProvinceId).OnDelete(DeleteBehavior.Restrict));
        
        modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Belarus" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Lithuania" });
        
        modelBuilder.Entity<Province>().HasData(new Province { Id = 1, Name = "Minsk", CountryId = 1 });
        modelBuilder.Entity<Province>().HasData(new Province { Id = 2, Name = "Grodno", CountryId = 1 });
        modelBuilder.Entity<Province>().HasData(new Province { Id = 3, Name = "Brest", CountryId = 1 });
        modelBuilder.Entity<Province>().HasData(new Province { Id = 4, Name = "Gomel", CountryId = 1 });
        modelBuilder.Entity<Province>().HasData(new Province { Id = 5, Name = "Mogilev", CountryId = 1 });
        modelBuilder.Entity<Province>().HasData(new Province { Id = 6, Name = "Vitebsk", CountryId = 1 });
        
        modelBuilder.Entity<Province>().HasData(new Province { Id = 7, Name = "Vilnius", CountryId = 2 });
        modelBuilder.Entity<Province>().HasData(new Province { Id = 8, Name = "Kaunas", CountryId = 2 });
        modelBuilder.Entity<Province>().HasData(new Province { Id = 9, Name = "Klaipeda", CountryId = 2 });
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}