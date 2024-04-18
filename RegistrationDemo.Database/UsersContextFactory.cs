using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RegistrationDemo.Database;

public class UsersContextFactory : IDesignTimeDbContextFactory<UsersContext>
{
    public UsersContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UsersContext>();
        
        optionsBuilder.UseSqlServer("Server=.;Database=UsersDb;Trusted_Connection=True;User Id=sa; Password=*;TrustServerCertificate=True");
        return new UsersContext(optionsBuilder.Options);
    }
}