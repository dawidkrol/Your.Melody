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
        [HttpPost("CreateGame")]
        public async Task<Guid> CreateGame(string playlistUrl, GameModes mode)
        {
            var newGame = new Game();
            newGame.Id = new Guid();
            newGame.Playlist = await _songsController.GetSongs(playlistUrl);
            newGame.GameMode = mode;
            return newGame.Id;
        }
        [HttpGet("InformationAboutGame")]
        public async Task<Game> InformationAboutGame(Guid gameId)
        {
            return new Game();
        }
        [HttpGet("NextSong")]
        public async Task<Song> NextSong(Guid gameId)
        {
            return new Song();
        }
        [HttpPost("PlayerReply")]
        public async Task PlayerReply(Guid gameId, Guid songId, double points)
        {

        }
    }
}
