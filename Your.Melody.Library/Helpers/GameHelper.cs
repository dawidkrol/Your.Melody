using Your.Melody.Library.Data;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public class GameHelper : IGameHelper
    {
        private readonly IGameData _gameData;
        private readonly IPointsCounter _pointsCounter;

        public GameHelper(IGameData gameData, IPointsCounter pointsCounter)
        {
            _gameData = gameData;
            _pointsCounter = pointsCounter;
        }
        public async Task<Song> GetNextSong(Guid gameId)
        {
            var game = await _gameData.GetGame(gameId);
            var unplayedSongs = game.Playlist.Songs.Where(x => x.WasPlayed == false).ToList();
            var playersFromLessRounds = game.Players.OrderBy(x => x.Rounds).ToList();

            if (unplayedSongs.Count == 0 || playersFromLessRounds.Count == 0)
            {
                throw new Exception("There are not players or more unplayed songs");
            }

            int randNumb = new Random().Next(0, unplayedSongs.Count());
            var toPlay = unplayedSongs[randNumb];
            var player = playersFromLessRounds[0];
            toPlay.Player = playersFromLessRounds[0];
            player.Rounds++;

            return toPlay;
        }

        public async Task PlayerResponce(Guid gameId, Guid songId, string titleByUser, string artistByUser, int secWhenUserResponce)
        {
            var game = await _gameData.GetGame(gameId);
            var s = game.Playlist.Songs.Single(x => x.SongId == songId);
            s.Points = await _pointsCounter.CountingPointsAsync(s, titleByUser, artistByUser, secWhenUserResponce);
            s.Player.Points += s.Points;
            s.WasPlayed = true;
        }
    }
}
