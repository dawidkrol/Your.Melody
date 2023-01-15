using Your.Melody.Library.DbAccess;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public class PlayerData : IPlayerData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public PlayerData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<IEnumerable<PlayerModel>> GetPlayersByGameId(Guid gameId)
        {
            return await _sqlDataAccess.LoadDataAsync<PlayerModel, object>("spPlayer_GetByGameId",
                new
                {
                    gameId = gameId
                });
        }
        public async Task AddPlayer(PlayerModel model)
        {
            await _sqlDataAccess.SaveDataAsync<object>("spPlayer_Add",
                new
                {
                    Id = model.Id,
                    Name = model.Name ?? "",
                    GameId = model.GameId,
                    UserId = model?.User?.Id
                });
        }
        public async Task AddPoints(Guid playerId, float points)
        {
            await _sqlDataAccess.SaveDataAsync<object>("[dbo].[spPlayer_AddPoints]",
                new
                {
                    playerId = playerId,
                    points = points
                });
        }
        public async Task AddRounds(Guid playerId, int rounds)
        {
            await _sqlDataAccess.SaveDataAsync<object>("[dbo].[spPlayer_AddRound]",
                new
                {
                    playerId = playerId,
                    rounds = rounds
                });
        }
        public async Task EditPlayer(Guid playerId, string newName)
        {
            await _sqlDataAccess.SaveDataAsync<object>("[dbo].[spPlayer_Edit]",
                new
                {
                    playerId = playerId,
                    newName = newName
                });
        }
        public async Task DeletePlayer(Guid playerId)
        {
            await _sqlDataAccess.SaveDataAsync<object>("[dbo].[spPlayer_Delete]",
                new
                {
                    playerId = playerId
                });
        }
    }
}
