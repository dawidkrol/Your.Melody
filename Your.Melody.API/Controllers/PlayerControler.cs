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
        [HttpPost("AddNewPlayerToGame")]
        public async Task AddNewPlayerToGame(Guid gameId, string playerNickname)
        {

        }
       
    }
}
