using MediatR;
using RegistrationDemo.Common;
using RegistrationDemo.Common.Security;
using RegistrationDemo.Database;

namespace RegistrationDemo.User.Api.Handler;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public long CountryId { get; set; }
    public long ProvinceId { get; set; }
}

public class UserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;

    public UserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellation)
    {
        var user = new Database.Models.User {
            Username = request.Email, 
            PasswordHash = SecretHasher.Hash(request.Password), 
            CountryId = request.CountryId, 
            ProvinceId = request.ProvinceId
        };

        var found = await _userRepository.FindFirstAsync(u => u.Username == request.Email, cancellation);
        if (found != null)
            throw new BlException(ErrorCode.UserExist, $"User with email: {request.Email} already exists.");
        
        user = await _userRepository.AddAsync(user, cancellation);

        return new UserDto {
            Id = user.Id,
            Username = user.Username,
            CountryId = user.CountryId,
            ProvinceId = user.ProvinceId
        };
    }
}