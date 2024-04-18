using RegistrationDemo.Database.Models;

namespace RegistrationDemo.Database;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(UsersContext context) : base(context)
    {
    }
}

public interface IUserRepository : IBaseRepository<User> 
{
}