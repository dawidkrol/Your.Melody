using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Your.Melody.API.Models;
using Your.Melody.Library.Helpers;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerControler : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlayerHelper _playerHelper;

        public PlayerControler(IMapper mapper, IPlayerHelper playerHelper)
        {
            _mapper = mapper;
            _playerHelper = playerHelper;
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
            return await _playerHelper.AddNewPlayerToGame(gameId, playerNickname);
        }

        /// <summary>
        /// Getting players from a specific game
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns>Players from game</returns>
        [HttpGet("GetPlayers/{gameId}")]
        public async Task<IEnumerable<Player>> GetPlayers(Guid gameId)
        {
            return _mapper.Map<IEnumerable<Player>>(await _playerHelper.GetPlayers(gameId));
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
            await _playerHelper.EditPlayer(playerId, name);
        }

        /// <summary>
        /// Deleting player from game
        /// </summary>
        /// <param name="playerId">Player id</param>
        /// <param name="gameId">game id</param>
        [HttpDelete("DeletePlayer")]
        public async Task DeletePlayer(Guid playerId)
        {
            await _playerHelper.DeletePlayer(playerId);
        }
    }
}
