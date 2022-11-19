using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public class GameData : IGameData
    {
        public static List<GameModel> _games = new();
        public IEnumerable<GameModel> GetGames()
        {
            return _games;
        }
        public GameModel GetGame(Guid gameId)
        {
            return _games.FirstOrDefault(x => x.Id == gameId);
        }
        public void AddGame(GameModel newGame)
        {
            _games.Add(newGame);
        }
        public void DeleteGame(Guid gameId)
        {
            _games.Remove(GetGame(gameId));
        }
        public void EditGame(GameModel gameModel)
        {
            var game = GetGame(gameModel.Id);
            game.Playlist = gameModel.Playlist;
            game.Players = gameModel.Players;
            game.GameMode = gameModel.GameMode;
        }
    }
}
