using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegistrationDemo.User.Api.Handler;
using RegistrationDemo.User.Api.Model;

namespace RegistrationDemo.User.Api.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    private readonly IMediator _mediator;
    
    [HttpPost]
    [Route("create")]
    public async Task<UserDto> Create(CreateUserModel model)
    {
        return await _mediator.Send(new CreateUserCommand { 
            Email = model.Email, Password = model.Password, CountryId = model.CountryId, ProvinceId = model.ProvinceId 
        });
    }
}