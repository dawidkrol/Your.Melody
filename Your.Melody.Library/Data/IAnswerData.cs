namespace Your.Melody.Library.Data
{
    public interface IAnswerData
    {
        Task AddPoints(Guid gameId, Guid playerId, Guid songId, float points);
        Task AddAnswer(Guid gameId, Guid playerId, Guid songId);
    }
}