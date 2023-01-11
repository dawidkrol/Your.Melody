using AutoMapper;
using Your.Melody.Library.Data;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public class GameHelper : IGameHelper
    {
        private readonly IMapper _mapper;
        private readonly IGameData _gameData;
        private readonly IPlaylistData _playlistData;
        private readonly ISongData _songData;
        private readonly IGameManagerHelper _gameManagerHelper;

        public GameHelper(IMapper mapper, IGameData gameData, IPlaylistData playlistData,
            ISongData songData, IGameManagerHelper gameManagerHelper)
        {
            _mapper = mapper;
            _gameData = gameData;
            _playlistData = playlistData;
            _songData = songData;
            _gameManagerHelper = gameManagerHelper;
        }

        public async Task<Guid> CreateGameNewPlaylist(Playlist model, GameModes mode)
        {
            GameModel _game = new();
            _game.GameMode = mode;
            _game.Playlist = model;
            _game.Id = Guid.NewGuid();
            _game.Playlist.Id = _game.Id;
            //Add game
            await _gameData.AddGame(_game);
            //Add playlist
            await _playlistData.AddPlaylist(_game.Playlist, _game.Id);
            //Add songs to playlist
            foreach (var song in _game.Playlist.Songs)
            {
                await _songData.AddSongToPlaylist(song, _game.Playlist.Id);
            }

            return _game.Id;
        }
        public async Task<Guid> CreateGameApprovedPlaylist(Guid playlistId, GameModes mode)
        {
            GameModel _game = new();
            _game.GameMode = mode;
            var playlist = await _playlistData.GetApprovedPlaylistsById(playlistId);
            _game.Playlist = _mapper.Map<Playlist>(playlist);
            _game.Id = Guid.NewGuid();
            _game.Playlist.Id = _game.Id;
            //Add game
            await _gameData.AddGame(_game);
            //Add playlist
            await _playlistData.AddPlaylist(_game.Playlist, _game.Id);
            //Add songs to playlist
            foreach (var song in _game.Playlist.Songs)
            {
                song.Id = Guid.NewGuid();
                await _songData.AddSongToPlaylist(song, _game.Playlist.Id);
            }

            return _game.Id;
        }
        public async Task<GameModel> InformationAboutGame(Guid gameId)
        {
            return await GetGame(gameId);
        }

        public async Task<Song> NextSong(Guid gameId)
        {
            return await _gameManagerHelper.GetNextSong(gameId);
        }

        public async Task<float> PlayerReply(Guid gameId, Guid songId, string titleByUser, string artistByUser, int secWhenUserResponce)
        {
            return await _gameManagerHelper.PlayerResponce(gameId, songId, titleByUser, artistByUser, secWhenUserResponce);
        }

        public async Task DeleteGame(Guid gameId)
        {
            await _gameData.DeleteGame(gameId);
        }

        public async Task<GameModel> GetGame(Guid gameId)
        {
            return _mapper.Map<GameModel>(await _gameData.GetGame(gameId));
        }
    }
}
