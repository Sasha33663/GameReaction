using Domain;
using Microsoft.EntityFrameworkCore;

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
    public async Task<Game?> GetByIdAsync(Guid gameId)
    {
        return await _gameDatabase.Games.FirstOrDefaultAsync(x => x.GameId == gameId);
    
     }
    public async Task UpdateAsync(Game game)
    {
        _gameDatabase.Games.Update(game);
        await _gameDatabase.SaveChangesAsync();
    }
}