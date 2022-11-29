using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Your.Melody.API.Models;
using Your.Melody.Library.Data;
using Your.Melody.Library.Helpers;
using static HotChocolate.ErrorCodes;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ISongsDataHelper _songsDataHelper;
        private readonly IMapper _mapper;
        private readonly IGameData _gameData;
        private readonly GameHelper _gameHelper;

        public GameController(ISongsDataHelper songsDataHelper, IMapper mapper,
            IGameData gameData, GameHelper gameHelper)
        {
            this._songsDataHelper = songsDataHelper;
            _mapper = mapper;
            _gameData = gameData;
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
            Game _game = new();
            _game.GameMode = mode;
            _game.Playlist = _mapper.Map<Playlist>(model);
            _game.Id = Guid.NewGuid();

            _gameData.AddGame(_mapper.Map<Library.Models.GameModel>(_game));

            return _game.Id;
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returning informations about game
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns>The game model that contains all information about the game</returns>
        [HttpGet("InformationAboutGame")]
        public async Task<Game> InformationAboutGame(Guid gameId)
        {
            return GetGame(gameId);
        }
        /// <summary>
        /// Getting the song to be used for the game next
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns>Song model</returns>
        [HttpGet("NextSong")]
        public async Task<Song> NextSong(Guid gameId)
        {
            return _mapper.Map<Song>(await _gameHelper.GetNextSong(gameId));
        }
        /// <summary>
        /// User Game Result
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="songId">Played song id</param><
        /// <param name="titleByUser"></param>
        /// <param name="artistByUser"></param>
        /// <param name="secWhenUserResponce"></param>
        [HttpPost("PlayerReply")]
        public async Task PlayerReply(Guid gameId, Guid songId, string titleByUser, string artistByUser, int secWhenUserResponce)
        {
            await _gameHelper.PlayerResponce(gameId,songId, titleByUser, artistByUser, secWhenUserResponce);
        }

        /// <summary>
        /// Deleting specific game
        /// </summary>
        /// <param name="gameId">Game id</param>
        [HttpDelete("DeleteGame/{gameId}")]
        public async Task DeleteGame(Guid gameId)
        {
            _gameData.DeleteGame(gameId);
        }

        private Game GetGame(Guid gameId)
        {
            return _mapper.Map<Game>(_gameData.GetGame(gameId));
        }
    }
}
