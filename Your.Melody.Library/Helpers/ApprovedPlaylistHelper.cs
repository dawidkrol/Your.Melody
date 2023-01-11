using AutoMapper;
using Your.Melody.Library.Data;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public class ApprovedPlaylistHelper : IApprovedPlaylistHelper
    {
        private readonly IPlaylistData _playlistData;
        private readonly ISongData _songData;
        private readonly IMapper _mapper;

        public ApprovedPlaylistHelper(IPlaylistData playlistData, ISongData songData, IMapper mapper)
        {
            _playlistData = playlistData;
            _songData = songData;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ApprovedPlaylist>> ApprovedPlaylists()
        {
            return _mapper.Map<IEnumerable<ApprovedPlaylist>>(await _playlistData.GetApprovedPlaylists());
        }
        public async Task AddApprovedPlaylist(PlaylistModel playlist, string name, string description)
        {
            var playll = _mapper.Map<Playlist>(playlist);
            playll.Id = Guid.NewGuid();

            await _playlistData.AddApprovedPlaylist(playll.Id, "", name, description);
            foreach (var song in playlist.Songs)
            {
                await _songData.AddSongToPlaylist(_mapper.Map<Library.Models.Song>(song), playll.Id);
            }
        }
        public async Task LikePlaylist(Guid playlistId)
        {
            await _playlistData.LikeApprovedPlaylist(playlistId);
        }
        public async Task UnlikePlaylist(Guid playlistId)
        {
            await _playlistData.UnLikeApprovedPlaylist(playlistId);
        }
        public async Task DeleteApprovedPlaylist(Guid id)
        {
            await _playlistData.DeleteApprovedPlaylist(id);
        }
    }
}
