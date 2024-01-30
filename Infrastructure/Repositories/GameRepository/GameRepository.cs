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
}