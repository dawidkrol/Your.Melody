using Your.Melody.Library.DbAccess;
using Your.Melody.Library.Models;
using YoutubeExplode.Playlists;
using Playlist = Your.Melody.Library.Models.Playlist;

namespace Your.Melody.Library.Data
{
    public class GameData : IGameData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public GameData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public async Task<IEnumerable<GameModel>> GetGames()
        {
            return await _sqlDataAccess.LoadDataAsync<GameModel,object>("spGame_GetAll", new { });
        }
        public async Task<GameModel> GetGame(Guid gameId)
        {
            GameModel data = (await _sqlDataAccess.LoadDataAsync<GameModel, object>("spGame_GetById", new { gameId = gameId })).Single();
            data.Players = (await _sqlDataAccess.LoadDataAsync<PlayerModel, object>("[dbo].[spPlayer_GetByGameId]", new { GameId = gameId })).ToList();
            data.Playlist = (await _sqlDataAccess.LoadDataAsync<Playlist, object>("[dbo].[spPlaylist_GetByGameId]", new { GameId = gameId })).Single();
            data.Playlist.Songs = (await _sqlDataAccess.LoadDataAsync<Song, object>("[dbo].[spSong_GetByPlaylistId]", new { PlaylistId = data.Playlist.Id })).ToList();
            foreach (var song in data.Playlist.Songs)
            {
                song.Player = (await _sqlDataAccess.LoadDataAsync<PlayerModel, object>("[dbo].[spPlayer_GetBySongId]", new { songId = song.Id })).FirstOrDefault();
            }

            return data;
        }
        public async Task AddGame(GameModel newGame)
        {
            await _sqlDataAccess.SaveDataAsync<object>("spGame_Add", new 
            {
                Id = newGame.Id,
                GameMode = newGame.GameMode
            });
        }
        public async Task DeleteGame(Guid gameId)
        {
            //TODO
        }
        public async Task EditGame(GameModel gameModel)
        {
            //TODO
        }
    }
}
