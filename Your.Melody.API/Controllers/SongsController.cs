using Microsoft.AspNetCore.Mvc;
using Your.Melody.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {

        [HttpPost]
        public void Post([FromBody]PlaylistModel playlist)
        {

        }
    }
}
