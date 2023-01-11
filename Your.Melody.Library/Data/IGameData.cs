using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public interface IGameData
    {
        Task AddGame(GameModel newGame);
        Task DeleteGame(Guid gameId);
        Task EditGame(GameModel gameModel);
        Task<GameModel> GetGame(Guid gameId);
        Task<IEnumerable<GameModel>> GetGames();
    }
}