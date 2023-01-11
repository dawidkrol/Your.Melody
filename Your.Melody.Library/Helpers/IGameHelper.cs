using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public interface IGameHelper
    {
        Task<Guid> CreateGameApprovedPlaylist(Guid playlistId, GameModes mode);
        Task<Guid> CreateGameNewPlaylist(Playlist model, GameModes mode);
        Task DeleteGame(Guid gameId);
        Task<GameModel> InformationAboutGame(Guid gameId);
        Task<Song> NextSong(Guid gameId);
        Task<GameModel> GetGame(Guid gameId);
        Task PlayerReply(Guid gameId, Guid songId, string titleByUser, string artistByUser, int secWhenUserResponce);
    }
}