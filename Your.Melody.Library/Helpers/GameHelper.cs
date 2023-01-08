using Your.Melody.Library.Data;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public class GameHelper : IGameHelper
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
            var game = _gameData.GetGame(gameId);
            var s = game.Playlist.Songs.Single(x => x.SongId == songId);
            s.Points = await CountingPointsAsync(s, titleByUser, artistByUser, secWhenUserResponce);
            s.Player.Points += s.Points;
            s.WasPlayed = true;
        }

        public async Task<double> CountingPointsAsync(Song song, string titleByUser, string artistByUser, double secWhenUserResponce)
        {
            //Max 100 pts.
            double result = 0;
            result += 50 * (await textEquality(titleByUser, song.Title));
            result += 50 * (await textEquality(artistByUser, song.Artist));
            result /= 1 + (secWhenUserResponce / 15);
            return result;
        }
        private async Task<double> textEquality(string a, string b)
        {
            a = await normalizingString(a);
            b = await normalizingString(b);
            if (a == b)
                return 1;
            if ((a.Length == 0) || (b.Length == 0))
            {
                return 0;
            }
            double maxLen = a.Length > b.Length ? a.Length : b.Length;
            int minLen = a.Length < b.Length ? a.Length : b.Length;
            int sameCharAtIndex = 0;
            for (int i = 0; i < minLen; i++)
            {
                if (a[i] == b[i])
                {
                    sameCharAtIndex++;
                }
            }
            return sameCharAtIndex / maxLen;
        }
        private async Task<string> normalizingString(string text) => text.ToLower().Trim().Replace(" ", "");
    }
}
