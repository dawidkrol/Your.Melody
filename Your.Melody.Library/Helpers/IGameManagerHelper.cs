using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public interface IGameManagerHelper
    {
        Task<Song> GetNextSong(Guid gameId);
        Task<float> PlayerResponce(Guid gameId, Guid songId, string titleByUser, string artistByUser, int secWhenUserResponce);
    }
}