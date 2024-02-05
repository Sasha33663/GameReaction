using Domain;
using Npgsql.TypeMapping;

namespace Application
{
    public interface IUserService
    {
        Task<User> UserCreateServiceAsync(string name, decimal moneyAmount);

        Task<Game> GameCreateServiceAsync(string name, string description, decimal price, int gameAmount, byte [] gamePreview, Guid userId);
        Task<int> CreateLike(int likes, Guid userId, Guid gameId);
    }
}