using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Your.Melody.API.Models;
using Your.Melody.Library.Helpers;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovedPlaylistControler : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IApprovedPlaylistHelper _approvedPlaylistHelper;

        public ApprovedPlaylistControler(IMapper mapper, IApprovedPlaylistHelper approvedPlaylistHelper)
        {
            _mapper = mapper;
            _approvedPlaylistHelper = approvedPlaylistHelper;
        }
        /// <summary>
        /// Returns playlists that have been approved
        /// </summary>
        [HttpGet("ApprovedPlaylists")]
        public async Task<IEnumerable<ApprovedPlaylist>> ApprovedPlaylists()
        {
            return _mapper.Map<IEnumerable<ApprovedPlaylist>>(await _approvedPlaylistHelper.ApprovedPlaylists());
        }
        /// <summary>
        /// Adding playlist to the approved
        /// </summary>
        /// <param name="name">Playlist name</param>
        /// <param name="description">Playlist description</param>
        //[Authorize]
        [HttpPost("AddPlaylistToApproved")]
        public async Task AddPlaylistToApproved(PlaylistModel playlist, string name, string description)
        {
            await _approvedPlaylistHelper
                .AddApprovedPlaylist(_mapper.Map<Your.Melody.Library.Models.PlaylistModel>(playlist), name, description);
        }
        /// <summary>
        /// Adding like to the playlist
        /// </summary>
        //[Authorize]
        [HttpPost("LikePlaylist")]
        public async Task LikePlaylist(Guid playlistId)
        {
            await _approvedPlaylistHelper.LikePlaylist(playlistId);
        }
        /// <summary>
        /// Adding unlike to the playlist
        /// </summary>
        //[Authorize]
        [HttpPost("UnlikePlaylist")]
        public async Task UnlikePlaylist(Guid playlistId)
        {
            await _approvedPlaylistHelper.UnlikePlaylist(playlistId);
        }
        /// <summary>
        /// Editing existing approved playlist
        /// </summary>
        /// <param name="playlist">Edited approved playlist</param>
        //[Authorize]
        //[HttpPut("EditApprovedPlaylist")]
        //public async Task EditApprovedPlaylist(Playlist playlist)
        //{

        //}
        /// <summary>
        /// Deleting existing approved playlist
        /// </summary>
        /// <param name="id">The id of the playlist you want to delete</param>
        //[Authorize]
        [HttpDelete("DeleteApprovedPlaylist/{id}")]
        public async Task DeleteApprovedPlaylist([FromHeader] Guid id)
        {
            await _approvedPlaylistHelper.DeleteApprovedPlaylist(id);
        }
    }
}
