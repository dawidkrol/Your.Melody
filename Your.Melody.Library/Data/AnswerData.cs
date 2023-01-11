using Your.Melody.Library.DbAccess;

namespace Your.Melody.Library.Data
{
    public class AnswerData : IAnswerData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public AnswerData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task AddAnswer(Guid gameId, Guid playerId, Guid songId)
        {
            await _sqlDataAccess.SaveDataAsync<object>("[dbo].[spAnswers_Add]",
                new
                {
                    gameId = gameId,
                    playerId = playerId,
                    songId = songId
                });
        }
        public async Task AddPoints(Guid gameId, Guid playerId, Guid songId, float points)
        {
            await _sqlDataAccess.SaveDataAsync<object>("[dbo].[spAnswers_AddPoints]",
                new
                {
                    gameId = gameId,
                    playerId = playerId,
                    songId = songId,
                    points = points
                });
        }
    }
}
