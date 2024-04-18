using System.ComponentModel.DataAnnotations;

namespace RegistrationDemo.User.Api.Model;

public class CreateUserModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public long CountryId { get; set; }
    
    [Required]
    public long ProvinceId { get; set; }
}