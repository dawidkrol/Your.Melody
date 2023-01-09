using Your.Melody.Library.DbAccess;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public class PlaylistData : IPlaylistData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public PlaylistData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public async Task AddPlaylist(Playlist playlist)
        {
            await _sqlDataAccess.SaveDataAsync<object>("spPlaylist_Add",
                new
                {
                    @Id = playlist.Id
                });
        }
    }
}
