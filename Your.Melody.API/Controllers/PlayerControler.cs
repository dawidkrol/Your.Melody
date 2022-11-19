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
        private readonly IMapper _mapper;

        public PlayerControler(IGameData gameData, IMapper mapper)
        {
            _gameData = gameData;
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
            var game = GetGame(gameId);
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
            GameData._games.Single(x => x.Id == gameId).Players.Add(_mapper.Map<PlayerModel>(player));
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
            return GetGame(gameId).Players;
        }

        /// <summary>
        /// Editing player name
        /// </summary>
        /// <param name="playerId">player id</param>
        /// <param name="gameId">game id</param>
        /// <param name="name">new name</param>
        [HttpPut("EditPlayer")]
        public async Task EditPlayer(Guid playerId, Guid gameId, string name)
        {
            _gameData.GetGame(gameId).Players.Single(x => x.Id == playerId).Name = name;
        }

        /// <summary>
        /// Deleting player from game
        /// </summary>
        /// <param name="playerId">Player id</param>
        /// <param name="gameId">game id</param>
        [HttpDelete("DeletePlayer")]
        public async Task DeletePlayer(Guid playerId, Guid gameId)
        {
            var player = _gameData.GetGame(gameId).Players.Single(x => x.Id == playerId);
            _gameData.GetGame(gameId).Players.Remove(player);
        }

        private Game GetGame(Guid gameId)
        {
            return _mapper.Map<Game>(_gameData.GetGame(gameId));
        }
    }
}
