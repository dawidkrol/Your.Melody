using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public class SongsDataHelperYouTube : ISongsDataHelper
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public SongsDataHelperYouTube(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<PlaylistModel> GetPlaylist(string url)
        {
            var playlistId = seperatingPlaylistFromUrl(url);
            var apiKey = _configuration["ApiKey"];
            HttpClient httpClient = new HttpClient();
            var valResp = await httpClient.GetFromJsonAsync<PlaylistYtModel>($"https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails%2Cid%2Csnippet&" +
                $"playlistId={playlistId}&key={apiKey}");
            PlaylistModel values = await ytModelConventer(valResp);
            values.Songs.ForEach(x => SeperatingTitleAndArtist(ref x));
            return values;
        }
        private async Task<PlaylistModel> ytModelConventer(PlaylistYtModel playlistYtModel)
        {
            return _mapper.Map<PlaylistModel>(playlistYtModel);
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
        private async Task<string> seperatingPlaylistFromUrl(string url)
        {
            var data = Regex.Match(url, "(?<=list=)([a-zA-Z0-9])\\w+").Value;
            return data;
        }
    }
}
