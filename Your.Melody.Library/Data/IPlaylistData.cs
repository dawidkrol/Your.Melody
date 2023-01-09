using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public interface IPlaylistData
    {
        Task AddPlaylist(Playlist playlist, Guid gameId);
    }
}