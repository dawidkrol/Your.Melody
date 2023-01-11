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
                    @playerId = playerId,
                    @points = points
                });
        }
        public async Task EditPlayer(Guid playerId, string newName)
        {
            await _sqlDataAccess.SaveDataAsync<object>("[dbo].[spPlayer_Edit]",
                new
                {
                    @playerId = playerId,
                    @newName = newName
                });
        }
        public async Task DeletePlayer(Guid playerId)
        {
            await _sqlDataAccess.SaveDataAsync<object>("[dbo].[spPlayer_Delete]",
                new
                {
                    @playerId = playerId
                });
        }
    }
}
