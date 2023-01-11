using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public interface IPointsCounter
    {
        Task<float> CountingPointsAsync(Song song, string titleByUser, string artistByUser, float secWhenUserResponce);
    }
}