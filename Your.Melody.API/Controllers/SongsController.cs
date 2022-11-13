using Microsoft.AspNetCore.Mvc;
using Your.Melody.Library.Helpers;
using Your.Melody.Library.Models;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongsDataHelper _songsDataHelper;

        public SongsController(ISongsDataHelper songsDataHelper)
        {
            _songsDataHelper = songsDataHelper;
        }
        [HttpGet]
        public async Task<PlaylistModel> GetSongs([FromQuery] string playlistId)
        {
            return await _songsDataHelper.GetPlaylist(playlistId);
        }
    }
}
