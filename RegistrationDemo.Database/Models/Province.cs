namespace RegistrationDemo.Database.Models;

public class Province : IEntity
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public long CountryId { get; set; }
}