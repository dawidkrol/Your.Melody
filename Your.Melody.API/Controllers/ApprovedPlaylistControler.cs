using AngleSharp.Dom;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Your.Melody.API.Models;
using Your.Melody.Library.Data;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovedPlaylistControler : ControllerBase
    {
        private readonly IPlaylistData _playlistData;
        private readonly ISongData _songData;
        private readonly IMapper _mapper;

        public ApprovedPlaylistControler(IPlaylistData playlistData, ISongData songData, IMapper mapper)
        {
            _playlistData = playlistData;
            _songData = songData;
            _mapper = mapper;
        }
        /// <summary>
        /// Returns playlists that have been approved
        /// </summary>
        [HttpGet("ApprovedPlaylists")]
        public async Task<IEnumerable<ApprovedPlaylist>> ApprovedPlaylists()
        {
            return _mapper.Map<IEnumerable<ApprovedPlaylist>>(await _playlistData.GetApprovedPlaylists());
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
            var playll = _mapper.Map<Playlist>(playlist);
            playll.Id = Guid.NewGuid();

            //Add playlist
            await _playlistData.AddApprovedPlaylist(playll.Id,"",name,description);
            //Add songs to playlist
            foreach (var song in playlist.Songs)
            {
                await _songData.AddSongToPlaylist(_mapper.Map<Library.Models.Song>(song), playll.Id);
            }
        }
        /// <summary>
        /// Adding like to the playlist
        /// </summary>
        //[Authorize]
        [HttpPost("LikePlaylist")]
        public async Task LikePlaylist(Guid playlistId)
        {
            await _playlistData.LikeApprovedPlaylist(playlistId);
        }
        /// <summary>
        /// Adding unlike to the playlist
        /// </summary>
        //[Authorize]
        [HttpPost("UnlikePlaylist")]
        public async Task UnlikePlaylist(Guid playlistId)
        {
            await _playlistData.UnLikeApprovedPlaylist(playlistId);
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
        public async Task DeleteApprovedPlaylist([FromHeader]Guid id)
        {
            await _playlistData.DeleteApprovedPlaylist(id);
        }
    }
}
