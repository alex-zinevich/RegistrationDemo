namespace RegistrationDemo.Database.Models;

public class User : IEntity
{
    public long Id { get; set; }
    
    public string Username { get; set; }
    
    public string PasswordHash { get; set; }
    
    public long CountryId { get; set; }
    public virtual Country Country { get; set; }
    
    public long ProvinceId { get; set; }
    public virtual Province Province { get; set; }
}