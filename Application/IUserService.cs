using Domain;
using Npgsql.TypeMapping;

namespace Application
{
    public interface IUserService
    {
        Task<User> UserCreateServiceAsync(string name, decimal moneyAmount);

        Task<Game> GameCreateServiceAsync(string name, string description, decimal price, int gameAmount, byte [] gamePreview, Guid userId);
        Task CreateLike (int likes, Guid gameId);
        Task CreateDislike (int dislikes, Guid gameId);
    }
}