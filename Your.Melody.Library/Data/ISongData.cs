using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public interface ISongData
    {
        Task AddSongToPlaylist(Song song, Guid playlistId);
    }
}