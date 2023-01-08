using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public interface IGameHelper
    {
        Task<double> CountingPointsAsync(Song song, string titleByUser, string artistByUser, double secWhenUserResponce);
        Task<Song> GetNextSong(Guid gameId);
        Task PlayerResponce(Guid gameId, Guid songId, string titleByUser, string artistByUser, int secWhenUserResponce);
    }
}