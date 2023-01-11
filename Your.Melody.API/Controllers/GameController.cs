using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Your.Melody.API.Models;
using Your.Melody.Library.Helpers;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGameHelper _gameHelper;

        public GameController(IMapper mapper, IGameHelper gameHelper)
        {
            _mapper = mapper;
            _gameHelper = gameHelper;
        }
        /// <summary>
        /// Checking new playlist for game
        /// </summary>
        /// <param name="model">Playlist model, that was returned by endpoint</param>
        /// <returns>New game guid</returns>
        [HttpPost("CreateGameNewPlaylist")]
        public async Task<Guid> CreateGameNewPlaylist(PlaylistModel model, GameModes mode)
        {
            return await _gameHelper.CreateGameNewPlaylist(_mapper.Map<Library.Models.Playlist>(model),
                _mapper.Map<Library.Models.GameModes>(mode));
        }
        /// <summary>
        /// Creating new game with already approved playlist
        /// </summary>
        /// <param name="playlistId">Playlist to be used in the game</param>
        /// <param name="mode">Game mode selection: 1-single, 2-party, 3-multi</param>
        /// <returns>Game id</returns>
        [HttpPost("CreateGameApprovedPlaylist")]
        public async Task<Guid> CreateGameApprovedPlaylist(Guid playlistId, GameModes mode)
        {
            return await _gameHelper.CreateGameApprovedPlaylist(playlistId, _mapper.Map<Library.Models.GameModes>(mode));
        }
        /// <summary>
        /// Returning informations about game
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns>The game model that contains all information about the game</returns>
        [HttpGet("InformationAboutGame")]
        public async Task<Game> InformationAboutGame(Guid gameId)
        {
            return _mapper.Map<Game>(await _gameHelper.InformationAboutGame(gameId));
        }
        /// <summary>
        /// Getting the song to be used for the game next
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns>Song model</returns>
        [HttpGet("NextSong")]
        public async Task<Song> NextSong(Guid gameId)
        {
            return _mapper.Map<Song>(await _gameHelper.NextSong(gameId));
        }
        /// <summary>
        /// User Game Responce
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="songId">Played song id</param><
        /// <param name="titleByUser"></param>
        /// <param name="artistByUser"></param>
        /// <param name="secWhenUserResponce"></param>
        [HttpPost("PlayerReply")]
        public async Task PlayerReply(Guid gameId, Guid songId, string titleByUser, string artistByUser, int secWhenUserResponce)
        {
            await _gameHelper.PlayerReply(gameId, songId, titleByUser, artistByUser, secWhenUserResponce);
        }

        /// <summary>
        /// Deleting specific game
        /// </summary>
        /// <param name="gameId">Game id</param>
        [HttpDelete("DeleteGame/{gameId}")]
        public async Task DeleteGame(Guid gameId)
        {
            await _gameHelper.DeleteGame(gameId);
        }

    }
}
