using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public interface IApprovedPlaylistHelper
    {
        Task AddApprovedPlaylist(PlaylistModel playlist, string name, string description);
        Task<IEnumerable<ApprovedPlaylist>> ApprovedPlaylists();
        Task DeleteApprovedPlaylist(Guid id);
        Task LikePlaylist(Guid playlistId);
        Task UnlikePlaylist(Guid playlistId);
    }
}