﻿using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public interface IPlayerData
    {
        Task AddPlayer(PlayerModel model);
        Task AddPoints(Guid playerId, float points);
    }
}