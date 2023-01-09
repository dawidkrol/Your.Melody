using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public interface IPointsCounter
    {
        Task<double> CountingPointsAsync(Song song, string titleByUser, string artistByUser, double secWhenUserResponce);
    }
}