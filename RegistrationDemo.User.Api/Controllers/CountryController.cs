using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegistrationDemo.User.Api.Handler;

namespace RegistrationDemo.User.Api.Controllers;

[ApiController]
[Route("countries")]
public class CountryController : ControllerBase
{
    private readonly ILogger<CountryController> _logger;
    
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator, ILogger<CountryController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpGet]
    [Route("all")]
    public async Task<IEnumerable<CountryDto>> GetList()
    {
        return await _mediator.Send(new GetCountriesListQuery());
    }
    
    [HttpGet]
    [Route("{countryId}/provinces")]
    public async Task<IEnumerable<ProvinceDto>> GetProvinces(long countryId)
    {
        return await _mediator.Send(new GetCountryProvincesQuery { CountryId = countryId});
    }
}