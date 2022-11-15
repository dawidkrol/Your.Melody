using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Your.Melody.API.Models;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovedPlaylistControler : ControllerBase
    {
        public ApprovedPlaylistControler()
        {

        }
        /// <summary>
        /// Returns playlists that have been approved
        /// </summary>
        [HttpGet("ApprovedPlaylists")]
        public async Task<List<ApprovedPlaylist>> ApprovedPlaylists()
        {
            return new List<ApprovedPlaylist>();
        }
        /// <summary>
        /// Adding playlist to the approved
        /// </summary>
        /// <param name="name">Playlist name</param>
        /// <param name="description">Playlist description</param>
        [Authorize]
        [HttpPost("AddPlaylistToApproved")]
        public async Task AddPlaylistToApproved(Playlist playlist, string name, string description)
        {

        }
        /// <summary>
        /// Adding like to the playlist
        /// </summary>
        [Authorize]
        [HttpPost("LikePlaylist")]
        public async Task LikePlaylist(Guid playlistId)
        {

        }
        /// <summary>
        /// Adding unlike to the playlist
        /// </summary>
        [Authorize]
        [HttpPost("UnlikePlaylist")]
        public async Task UnlikePlaylist(Guid playlistId)
        {

        }
    }
}
