using Domain;
using Infrastructure.Repositories.GameRepository;
using Infrastructure.Rerositories.UserRepository;

namespace Application;

public partial class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IGameRepository _gameRepository;

    public UserService(IUserRepository userRepository, IGameRepository gameRepository)
    {
        _userRepository = userRepository;
        _gameRepository = gameRepository;
    }

    public async Task<User> UserCreateServiceAsync(string name, decimal moneyAmount)
    {
        var newUser = new User
        {
            UserName = name,
            UserId = Guid.NewGuid(),
            MoneyAmount = moneyAmount,
            Games = []
        };
        await _userRepository.UserCreateInRepositoryAsync(newUser);
        return newUser;
    }

    public async Task<Game> GameCreateServiceAsync(string name, string description, decimal price, int gameAmount, byte gamePreview, Guid gameId)
    {
        var newGame = new Game
        {
            Name = name,
            Description = description,
            Price = price,
            GamesAmount = gameAmount,
            GameId = Guid.NewGuid(),

            GamePreview = gamePreview
        };
        await _gameRepository.AddGameInRepositoryAsync(newGame);
        return newGame;
    }
}