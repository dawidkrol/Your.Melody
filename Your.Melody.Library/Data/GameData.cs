using Your.Melody.Library.DbAccess;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public class GameData : IGameData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public GameData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public async Task<IEnumerable<GameModel>> GetGames()
        {
            return await _sqlDataAccess.LoadDataAsync<GameModel,object>("spGame_GetAll", new { });
        }
        public async Task<GameModel> GetGame(Guid gameId)
        {
            return (await _sqlDataAccess.LoadDataAsync<GameModel, object>("spGame_GetById", new { Id = gameId })).FirstOrDefault();
        }
        public async Task AddGame(GameModel newGame)
        {
            await _sqlDataAccess.SaveDataAsync<object>("spGame_Add", new 
            {
                Id = newGame.Id,
                GameMode = newGame.GameMode,
                PlaylistId = newGame.Playlist.Id
            });
        }
        public async Task DeleteGame(Guid gameId)
        {
            //TODO
        }
        public async Task EditGame(GameModel gameModel)
        {
            //TODO
        }
    }
}
