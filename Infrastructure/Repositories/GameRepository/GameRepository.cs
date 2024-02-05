using Domain;

namespace Infrastructure.Repositories.GameRepository;

public partial class GameRepository : IGameRepository
{
    private readonly Database _gameDatabase;

    public GameRepository(Database gameDatabase)
    {
        _gameDatabase = gameDatabase;
    }

    public async Task AddGameInRepositoryAsync(Game game)
    {
        await _gameDatabase.Games.AddAsync(game);
        await _gameDatabase.SaveChangesAsync();
    }
    public async Task<int> MakeLikeInRepositoryAsync (int likedGame)
    {
        var Game = new Game
        {
            Likes = likedGame
        };
        await _gameDatabase.Games.Likes.AddAsync(likedGame);
        await _gameDatabase.SaveChangesAsync();

        return 1;
    }
}