using Domain;
using Infrastructure.Repositories;

namespace Infrastructure.Rerositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly Database _database;

    public UserRepository(Database databse)
    {
        _database = databse;
    }

    public async Task UserCreateInRepositoryAsync(User user)
    {
        await _database.Users.AddAsync(user);
        await _database.SaveChangesAsync();
    }
}