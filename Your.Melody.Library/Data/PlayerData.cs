using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
