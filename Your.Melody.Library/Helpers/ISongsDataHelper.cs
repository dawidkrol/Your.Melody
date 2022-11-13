using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public interface ISongsDataHelper
    {
        Task<PlaylistModel> GetPlaylist(string playlistId);
        void SemeratingTitleAndArtist(ref SongDataModel sdm);
    }
}