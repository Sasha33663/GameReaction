﻿using Domain;

namespace Infrastructure.Repositories.GameRepository;

public interface IGameRepository
{
    Task AddGameInRepositoryAsync(Game game);
}