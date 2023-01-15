using Your.Melody.Library.Data;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public class GameManagerHelper : IGameManagerHelper
    {
        private readonly IGameData _gameData;
        private readonly IAnswerData _answerData;
        private readonly ISongData _songData;
        private readonly IPointsCounter _pointsCounter;
        private readonly IPlayerData _playerData;

        public GameManagerHelper(IGameData gameData, IAnswerData answerData, ISongData songData,
            IPointsCounter pointsCounter, IPlayerData playerData)
        {
            _gameData = gameData;
            _answerData = answerData;
            _songData = songData;
            _pointsCounter = pointsCounter;
            _playerData = playerData;
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
            if (unplayedSongs.Count < game.Players.Where(x => x.Rounds == playersFromLessRounds[0].Rounds).Count())
            {
                throw new Exception("There are not enough songs to play the next round");
            }

            int randNumb = new Random().Next(0, unplayedSongs.Count());
            var toPlay = unplayedSongs[randNumb];
            var player = playersFromLessRounds[0];
            toPlay.Player = playersFromLessRounds[0];
            await _answerData.AddAnswer(game.Id, player.Id, toPlay.Id);
            await _playerData.AddRounds(player.Id, 1);

            return toPlay;
        }

        public async Task<float> PlayerResponce(Guid gameId, Guid songId, string titleByUser, string artistByUser, int secWhenUserResponce)
        {
            var game = await _gameData.GetGame(gameId);
            var s = game.Playlist.Songs.Single(x => x.Id == songId);
            await _songData.SetSongAsPlayed(s.Id);
            s.Points = await _pointsCounter.CountingPointsAsync(s, titleByUser, artistByUser, secWhenUserResponce);
            await _playerData.AddPoints(s.Player.Id, s.Player.Points + s.Points);
            await _answerData.AddPoints(gameId, s.Player.Id, songId, s.Points);
            s.Player.Points += s.Points;
            s.WasPlayed = true;
            return s.Points;
        }
    }
}
