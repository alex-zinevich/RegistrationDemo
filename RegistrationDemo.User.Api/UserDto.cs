namespace RegistrationDemo.User.Api;

public class UserDto
{
    public long Id { get; set; }
    
    public string Username { get; set; }
    
    public long CountryId { get; set; }
    
    public long ProvinceId { get; set; }
}