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
        private readonly IGameHelper _gameHelper;
        private readonly ISongData _songData;
        private readonly IPlaylistData _playlistData;

        public GameController(ISongsDataHelper songsDataHelper, IMapper mapper,
            IGameData gameData, IGameHelper gameHelper,
            ISongData songData, IPlaylistData playlistData)
        {
            this._songsDataHelper = songsDataHelper;
            _mapper = mapper;
            _gameData = gameData;
            _gameHelper = gameHelper;
            _songData = songData;
            _playlistData = playlistData;
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
            _game.Playlist.Id = _game.Id;
            var g = _mapper.Map<Library.Models.GameModel>(_game);
            //Add game
            await _gameData.AddGame(g);
            //Add playlist
            await _playlistData.AddPlaylist(g.Playlist, _game.Id);
            //Add songs to playlist
            foreach (var song in g.Playlist.Songs)
            {
                await _songData.AddSongToPlaylist(song, g.Playlist.Id);
            }

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
            return await GetGame(gameId);
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
            await _gameHelper.PlayerResponce(gameId,songId, titleByUser, artistByUser, secWhenUserResponce);
        }

        /// <summary>
        /// Deleting specific game
        /// </summary>
        /// <param name="gameId">Game id</param>
        [HttpDelete("DeleteGame/{gameId}")]
        public async Task DeleteGame(Guid gameId)
        {
            await _gameData.DeleteGame(gameId);
        }

        private async Task<Game> GetGame(Guid gameId)
        {
            return _mapper.Map<Game>(await _gameData.GetGame(gameId));
        }
    }
}
