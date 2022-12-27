using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public interface IGameData
    {
        void AddGame(GameModel newGame);
        void DeleteGame(Guid gameId);
        void EditGame(GameModel gameModel);
        GameModel GetGame(Guid gameId);
        IEnumerable<GameModel> GetGames();
    }
}