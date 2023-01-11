using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public interface IPlaylistData
    {
        Task AddPlaylist(Playlist playlist, Guid gameId);
        Task<IEnumerable<ApprovedPlaylist>> GetApprovedPlaylists();
        Task AddApprovedPlaylist(Guid Id, string URI, string name, string description = "");
        Task LikeApprovedPlaylist(Guid playlistId);
        Task UnLikeApprovedPlaylist(Guid playlistId);
        Task DeleteApprovedPlaylist(Guid playlistId);
        Task<ApprovedPlaylist> GetApprovedPlaylistsById(Guid Id);

    }
}