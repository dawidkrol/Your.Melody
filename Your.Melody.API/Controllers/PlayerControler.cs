using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Your.Melody.API.Models;
using Your.Melody.Library.Data;
using Your.Melody.Library.Models;
using GameModes = Your.Melody.API.Models.GameModes;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerControler : ControllerBase
    {
        private readonly IGameData _gameData;
        private readonly IPlayerData _playerData;
        private readonly IMapper _mapper;

        public PlayerControler(IGameData gameData, IPlayerData playerData, IMapper mapper)
        {
            _gameData = gameData;
            _playerData = playerData;
            _mapper = mapper;
        }
        /// <summary>
        /// Adding new player to the created game.
        /// </summary>
        /// <param name="gameId">game id</param>
        /// <param name="playerNickname">Player nickname</param>
        /// <returns>Player id</returns>
        [HttpPost("AddNewPlayerToGame")]
        public async Task<Guid> AddNewPlayerToGame(Guid gameId, string playerNickname)
        {
            var game = await GetGame(gameId);
            if (game.GameMode == GameModes.Single && game.Players.Count > 0)
            {
                throw new Exception("Cannot add more than one player to singleplayer mode");
            }
            var player = new Player
            {
                Id = Guid.NewGuid(),
                Name = playerNickname,
                GameId = gameId,
                Points = 0,
                Rounds = 0,
                User = null
            };
            await _playerData.AddPlayer(_mapper.Map<PlayerModel>(player));
            return player.Id;
        }

        /// <summary>
        /// Getting players from a specific game
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns>Players from game</returns>
        [HttpGet("GetPlayers/{gameId}")]
        public async Task<List<Player>> GetPlayers(Guid gameId)
        {
            return (await GetGame(gameId)).Players;
        }

        /// <summary>
        /// Editing player name
        /// </summary>
        /// <param name="playerId">player id</param>
        /// <param name="gameId">game id</param>
        /// <param name="name">new name</param>
        [HttpPut("EditPlayer")]
        public async Task EditPlayer(Guid playerId, string name)
        {
            await _playerData.EditPlayer(playerId, name);
        }

        /// <summary>
        /// Deleting player from game
        /// </summary>
        /// <param name="playerId">Player id</param>
        /// <param name="gameId">game id</param>
        [HttpDelete("DeletePlayer")]
        public async Task DeletePlayer(Guid playerId)
        {
            await _playerData.DeletePlayer(playerId);
        }

        private async Task<Game> GetGame(Guid gameId)
        {
            return _mapper.Map<Game>(await _gameData.GetGame(gameId));
        }
    }
}
