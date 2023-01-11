using Your.Melody.Library.Data;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public class PlayerHelper : IPlayerHelper
    {
        private readonly IPlayerData _playerData;
        private readonly IGameHelper _gameHelper;

        public PlayerHelper(IPlayerData playerData, IGameHelper gameHelper)
        {
            _playerData = playerData;
            _gameHelper = gameHelper;
        }
        public async Task<Guid> AddNewPlayerToGame(Guid gameId, string playerNickname)
        {
            var game = await _gameHelper.GetGame(gameId);
            if (game.GameMode == GameModes.Single && game.Players.Count > 0)
            {
                throw new Exception("Cannot add more than one player to singleplayer mode");
            }
            var player = new PlayerModel
            {
                Id = Guid.NewGuid(),
                Name = playerNickname,
                GameId = gameId,
                Points = 0,
                Rounds = 0,
                User = null
            };
            await _playerData.AddPlayer(player);
            return player.Id;
        }
        public async Task<IEnumerable<PlayerModel>> GetPlayers(Guid gameId)
        {
            return await _playerData.GetPlayersByGameId(gameId);
        }
        public async Task EditPlayer(Guid playerId, string name)
        {
            await _playerData.EditPlayer(playerId, name);
        }
        public async Task DeletePlayer(Guid playerId)
        {
            await _playerData.DeletePlayer(playerId);
        }
    }
}
