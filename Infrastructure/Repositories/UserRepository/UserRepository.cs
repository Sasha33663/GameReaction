using Domain;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Rerositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly Database _userDatabase;

    public UserRepository(Database databse)
    {
        _userDatabase = databse;
    }

    public async Task UserCreateInRepositoryAsync(User user)
    {
        await _userDatabase.Users.AddAsync(user);
        await _userDatabase.SaveChangesAsync();
    }
    public async Task <User> GetUserByIdAsync(Guid userId)
    {
       
        return await _userDatabase.Users.FirstOrDefaultAsync(x => x.UserId == userId);
    }
    public async Task UpdateAsync (User user)
    {
        _userDatabase.Users.Update(user);
        await _userDatabase.SaveChangesAsync();
    }
}