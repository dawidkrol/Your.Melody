using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public interface IPlayerHelper
    {
        Task<Guid> AddNewPlayerToGame(Guid gameId, string playerNickname);
        Task DeletePlayer(Guid playerId);
        Task EditPlayer(Guid playerId, string name);
        Task<IEnumerable<PlayerModel>> GetPlayers(Guid gameId);
    }
}