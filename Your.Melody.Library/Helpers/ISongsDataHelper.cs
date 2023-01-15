using System.Runtime.Intrinsics.Arm;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public interface ISongsDataHelper
    {
        Task<PlaylistModel> GetPlaylist(string url);
        (string title, string artist) SeperatingTitleAndArtist(string sdm);
    }
}