using Your.Melody.Library.Data;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public class GameHelper
    {
        private readonly IGameData _gameData;

        public GameHelper(IGameData gameData)
        {
            _gameData = gameData;
        }
        public async Task<Song> GetNextSong(Guid gameId)
        {
            var game = _gameData.GetGame(gameId);
            var unplayedSongs = game.Playlist.Songs.Where(x => x.WasPlayed == false).ToList();
            var playersFromLessRounds = game.Players.OrderBy(x => x.Rounds).ToList();

            if(unplayedSongs.Count == 0 || playersFromLessRounds.Count == 0)
            {
                throw new Exception("There are not players or more unplayed songs");
            }

            int randNumb = new Random().Next(0,unplayedSongs.Count());
            var toPlay = unplayedSongs[randNumb];
            var player = playersFromLessRounds[0];
            toPlay.Player = playersFromLessRounds[0];
            player.Rounds++;

            return toPlay;
        }

        public async Task PlayerResponce(Guid gameId, Guid songId, double points)
        {
            var game = _gameData.GetGame(gameId);
            var s = game.Playlist.Songs.Single(x => x.SongId == songId);
            s.Points = points;
            s.Player.Points += s.Points;
            s.WasPlayed = true;
        }
    }
}
