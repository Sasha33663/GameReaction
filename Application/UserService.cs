using Application.Dto;
using Domain;
using Infrastructure.Repositories.GameRepository;
using Infrastructure.Rerositories.UserRepository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Options;
using System.Data;

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
       
        var newUser = new User(Guid.NewGuid())
        {
            UserName = name,
            
            MoneyAmount = moneyAmount,
            Games = new List<Game>()

        };
       
        await _userRepository.UserCreateInRepositoryAsync(newUser);
        return newUser;
    }

    public async Task<Game> GameCreateServiceAsync(string name, string description, decimal price, int gameAmount,  byte[] gamePreview, Guid userId)
    {
        
       var newGame = new Game
        {

           Name = name,
            Description = description,
            Price = price,
            GamesAmount = gameAmount,
            GameId = Guid.NewGuid(),
            UserId = userId,
            GamePreview = gamePreview,
           
        };
        
        await _gameRepository.AddGameInRepositoryAsync(newGame);
        return newGame;
    }
    public async Task  CreateLike(int like, Guid gameId)
    {
        var game = await _gameRepository.GetGameByIdAsync(gameId);
        
        game.Likes += like;
        if (like != 1 )
        {

            throw new Exception("Лайк может рaвняться только 1 ");
        }
        else
        {
            await _gameRepository.UpdateAsync(game);
        }
    }
    public async Task CreateDislike(int dislike, Guid gameId)
    {
        var game = await _gameRepository.GetGameByIdAsync(gameId);

        game.Dislikes += dislike;
        if (dislike != 1)
        {

            throw new Exception("Дизлайк может рaвняться только 1");
        }
        else
        {
            await _gameRepository.UpdateAsync(game);
        }
    }
    public async Task DoBuyAsync( Guid userId, Guid gameId, int count)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        var game = await _gameRepository.GetGameByIdAsync(gameId);
        if (user.MoneyAmount < game.Price)
        {
            throw new Exception("Не хватает средств");
        }
        if (count <= 0)
        {
            throw new Exception("Нельзя купить 0 игр");
            
        }
        if (count > game.GamesAmount)
        {
            throw new Exception("На складе не достаточно игр");

        }
        if (count * game.Price > user.MoneyAmount) 
        {
            throw new Exception("Не хватает средств");
        }
        if (game.GamesAmount <= 0)
        {
            throw new Exception("На складе не достаточно игр");
        }
        user.MoneyAmount -= game.Price;
        game.GamesAmount -= count;
        await _gameRepository.UpdateAsync(game);
        await _userRepository.UpdateAsync(user);
    }
    public async Task DoBuyAsync (Guid userId, IEnumerable<BuyGameDto> buyGameDto)
    {
        foreach (var item  in buyGameDto)
        {
            await DoBuyAsync(userId, item.gameId,item.count);
        }
    }

}