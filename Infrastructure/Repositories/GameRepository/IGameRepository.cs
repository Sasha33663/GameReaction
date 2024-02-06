﻿using Domain;

namespace Infrastructure.Repositories.GameRepository;

public interface IGameRepository
{
    Task AddGameInRepositoryAsync(Game game);
    Task<Game> GetByIdAsync(Guid gameId);

    Task UpdateAsync (Game game);
}