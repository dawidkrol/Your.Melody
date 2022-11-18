using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Your.Melody.API.Models;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerControler : ControllerBase
    {
        public PlayerControler()
        {

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
            return new Guid();
        }

        /// <summary>
        /// Getting players from a specific game
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns>Players from game</returns>
        [HttpGet("GetPlayers/{gameId}")]
        public async Task<List<Player>> GetPlayers(Guid gameId)
        {
            return new List<Player>();
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

        }

        /// <summary>
        /// Deleting player from game
        /// </summary>
        /// <param name="playerId">Player id</param>
        /// <param name="gameId">game id</param>
        [HttpDelete("DeletePlayer")]
        public async Task DeletePlayer(Guid playerId, Guid gameId)
        {

        }


    }
}
