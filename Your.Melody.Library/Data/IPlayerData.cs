using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public interface IPlayerData
    {
        Task AddPlayer(PlayerModel model);
        Task AddPoints(Guid playerId, float points);
        Task DeletePlayer(Guid playerId);
        Task EditPlayer(Guid playerId, string newName);
        Task<IEnumerable<PlayerModel>> GetPlayersByGameId(Guid gameId);
        Task AddRounds(Guid playerId, int rounds);
    }
}