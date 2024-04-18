namespace RegistrationDemo.Database.Models;

public class Country : IEntity
{
    public long Id { get; set; }
    
    public string Name { get; set; }
}