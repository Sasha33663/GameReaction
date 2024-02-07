using Domain;

namespace Infrastructure.Rerositories.UserRepository;

public interface IUserRepository
{
    Task UserCreateInRepositoryAsync(User user);
    Task <User>GetUserByIdAsync(Guid userId);
    Task UpdateAsync(User user);
}