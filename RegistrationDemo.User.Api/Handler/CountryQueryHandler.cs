using MediatR;
using RegistrationDemo.Database;

namespace RegistrationDemo.User.Api.Handler;

public class GetCountriesListQuery : IRequest<IEnumerable<CountryDto>>
{
}

public class GetCountryProvincesQuery : IRequest<IEnumerable<ProvinceDto>>
{
    public long CountryId { get; set; }
}

public class CountryQueryHandler : IRequestHandler<GetCountriesListQuery, IEnumerable<CountryDto>>, 
    IRequestHandler<GetCountryProvincesQuery, IEnumerable<ProvinceDto>>
{
    public CountryQueryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    
    private readonly ICountryRepository _countryRepository;
    
    public async Task<IEnumerable<CountryDto>> Handle(GetCountriesListQuery request, CancellationToken cancellation)
    {
        var countries = await _countryRepository.GetAllAsync(cancellation);

        return countries.Select(country => new CountryDto { Id = country.Id, Name = country.Name }).ToList();
    }

    public async Task<IEnumerable<ProvinceDto>> Handle(GetCountryProvincesQuery request, CancellationToken cancellation)
    {
        var provinces = await _countryRepository.GetProvincesAsync(request.CountryId, cancellation);

        return provinces.Select(province => new ProvinceDto { Id = province.Id, Name = province.Name }).ToList();
    }
}