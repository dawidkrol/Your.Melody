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
                song.Title = video.Title;
                song.Artist = video.Author.ChannelTitle;
                SeperatingTitleAndArtist(ref song);
                output.Songs.Add(song);
            }

            return output;
        }
        private void SeperatingTitleAndArtist(ref SongDataModel sdm)
        {
            var artist = Regex.Split(sdm.Title, " - ");
            if (artist is null || artist.Length == 1)
                return;
            var title = Regex.Split(artist[1], " [([{]");
            sdm.Title = title.FirstOrDefault() ?? "";
            sdm.Artist = artist.FirstOrDefault() ?? "";
        }
    }
}
