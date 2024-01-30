using Domain;

namespace Infrastructure.Rerositories.UserRepository;

public interface IUserRepository
{
    Task UserCreateInRepositoryAsync(User user);
}