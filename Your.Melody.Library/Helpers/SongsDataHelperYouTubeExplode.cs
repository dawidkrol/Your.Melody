using Dapper;
using System.Text.RegularExpressions;
using Your.Melody.Library.Models;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Videos.Streams;

namespace Your.Melody.Library.Helpers
{
    public class SongsDataHelperYouTubeExplode : ISongsDataHelper
    {
        private readonly YoutubeClient _client;

        public SongsDataHelperYouTubeExplode(YoutubeClient client)
        {
            _client = client;
        }
        public async Task<PlaylistModel> GetPlaylist(string url)
        {
            var output = new PlaylistModel();
            var videos = await _client.Playlists.GetVideosAsync(url);
            foreach (var video in videos)
            {
                var streamManifest = await _client.Videos.Streams.GetManifestAsync(video.Url);
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                var song = new SongDataModel();
                song.VideoUrl = video.Url;
                song.AudioUrl = streamInfo.Url;
                (song.Title,song.Artist) = SeperatingTitleAndArtist(video.Title);
                output.Songs.Add(song);
            }

            return output;
        }
        public (string title, string artist) SeperatingTitleAndArtist(string sdm)
        {
            var artist = Regex.Split(sdm, " - ");
            if (artist is null || artist.Length == 1)
                return (sdm,"");
            var title = Regex.Split(artist[1], " [(prod.)([{]");
            return (title.FirstOrDefault() ?? "", artist.FirstOrDefault() ?? "");
        }
    }
}
