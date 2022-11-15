using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost("AddNewPlayerToGame")]
        public async Task AddNewPlayerToGame(Guid gameId, string playerNickname)
        {

        }
       
    }
}
