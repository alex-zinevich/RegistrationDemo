using Microsoft.EntityFrameworkCore;
using RegistrationDemo.Database.Models;

namespace RegistrationDemo.Database;

public class CountryRepository : BaseRepository<Country>, ICountryRepository
{
    public CountryRepository(UsersContext context) : base(context)
    {
    }

    public async Task<IReadOnlyCollection<Province>> GetProvincesAsync(long countryId, CancellationToken cancellation)
    {
        return await Context.Provinces.Where(p => p.CountryId == countryId).ToArrayAsync(cancellation);
    }
}

public interface ICountryRepository : IBaseRepository<Country>
{
    Task<IReadOnlyCollection<Province>> GetProvincesAsync(long countryId, CancellationToken cancellation);
}