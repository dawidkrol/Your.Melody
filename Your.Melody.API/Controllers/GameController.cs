using Microsoft.AspNetCore.Mvc;
using Your.Melody.API.Models;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly SongsController _songsController;

        public GameController(SongsController songsController)
        {
            _songsController = songsController;
        }
        /// <summary>
        /// Creating new game with new playlist
        /// </summary>
        /// <param name="playlistUrl">Playlist to be used in the game</param>
        /// <param name="mode">Game mode selection: 1-single, 2-party, 3-multi</param>
        /// <returns>Returning playlist to approve.</returns>
        [HttpPost("CreateGameNewPlaylist")]
        public async Task<PlaylistModel> CreateGameNewPlaylist(string playlistUrl, GameModes mode)
        {
            return new PlaylistModel();
        }
        /// <summary>
        /// Checking new playlist for game
        /// </summary>
        /// <param name="model">Playlist model, that was returned by CreateGameNewPlaylist endpoint</param>
        /// <returns>New game guid</returns>
        [HttpPost("CheckingPlaylist")]
        public async Task<Guid> CheckingPlaylist(PlaylistModel model)
        {
            return new Guid();
        }
        /// <summary>
        /// Creating new game with already approved playlist
        /// </summary>
        /// <param name="playlistUrl">Playlist to be used in the game</param>
        /// <param name="mode">Game mode selection: 1-single, 2-party, 3-multi</param>
        /// <returns>Game id</returns>
        [HttpPost("CreateGameApprovedPlaylist")]
        public async Task<Guid> CreateGameApprovedPlaylist(Guid playlistId, GameModes mode)
        {
            var newGame = new Game();
            newGame.Id = new Guid();
            //newGame.Playlist = await _songsController.GetSongs(playlistUrl);
            newGame.GameMode = mode;
            return newGame.Id;
        }
        /// <summary>
        /// Returning informations about game
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns>The game model that contains all information about the game</returns>
        [HttpGet("InformationAboutGame")]
        public async Task<Game> InformationAboutGame(Guid gameId)
        {
            return new Game();
        }
        /// <summary>
        /// Getting the song to be used for the game next
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns>Song model</returns>
        [HttpGet("NextSong")]
        public async Task<Song> NextSong(Guid gameId)
        {
            return new Song();
        }
        /// <summary>
        /// User Game Responce
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="songId">Played song id</param>
        /// <param name="title">Title that user writed</param>
        /// <param name="artist">Artist that user writed</param>
        /// <param name="secFromStart">Secound from start when user answered</param>
        [HttpPost("PlayerResponce")]
        public async Task PlayerResponce(Guid gameId, Guid songId, string title, string artist, int secFromStart)
        {

        }

        /// <summary>
        /// Deleting specific game
        /// </summary>
        /// <param name="gameId">Game id</param>
        [HttpDelete("DeleteGame/{gameId}")]
        public async Task DeleteGame(Guid gameId)
        {

        }
    }
}
