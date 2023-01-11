using System.Xml.Linq;
using System;
using Your.Melody.Library.DbAccess;
using Your.Melody.Library.Models;
using YoutubeExplode.Playlists;
using Playlist = Your.Melody.Library.Models.Playlist;

namespace Your.Melody.Library.Data
{
    public class PlaylistData : IPlaylistData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public PlaylistData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task AddPlaylist(Playlist playlist, Guid gameId)
        {
            await _sqlDataAccess.SaveDataAsync<object>("spPlaylist_Add",
                new
                {
                    Id = playlist.Id,
                    GameId = gameId
                });
        }
        public async Task<IEnumerable<ApprovedPlaylist>> GetApprovedPlaylists()
        {
            var playlists = await _sqlDataAccess.LoadDataAsync<ApprovedPlaylist, object>("spPlaylist_GetApproved", new {} );
            foreach (var playlist in playlists)
            {
                playlist.Songs = (await _sqlDataAccess.LoadDataAsync<Song, object>("[dbo].[spSong_GetByPlaylistId]", new { PlaylistId = playlist.Id })).ToList();
            }
            return playlists;
        }

        public async Task<ApprovedPlaylist> GetApprovedPlaylistsById(Guid Id)
        {
            var playlist = (await _sqlDataAccess.LoadDataAsync<ApprovedPlaylist, object>("spPlaylist_GetApprovedById", new { Id = Id })).Single();
            playlist.Songs = (await _sqlDataAccess.LoadDataAsync<Song, object>("[dbo].[spSong_GetByPlaylistId]", new { PlaylistId = playlist.Id })).ToList();
            return playlist;
        }
        public async Task AddApprovedPlaylist(Guid Id, string URI, string name, string description = "")
        {
            await _sqlDataAccess.SaveDataAsync<object>("spPlaylist_AddApproved", new {
                @Id = Id,
                @URI = URI,
                @Name = name,
                @Description = description
            });
        }
        public async Task LikeApprovedPlaylist(Guid playlistId)
        {
            await _sqlDataAccess.SaveDataAsync<object>("spPlaylist_LikeApproved", new { @Id = playlistId });
        }
        public async Task UnLikeApprovedPlaylist(Guid playlistId)
        {
            await _sqlDataAccess.SaveDataAsync<object>("spPlaylist_UnLikeApproved", new { @Id = playlistId });
        }
        public async Task DeleteApprovedPlaylist(Guid playlistId)
        {
            await _sqlDataAccess.SaveDataAsync<object>("spPlaylist_DeleteApproved", new { @Id = playlistId });
        }
    }
}
