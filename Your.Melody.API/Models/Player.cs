namespace Your.Melody.API.Models
{
    /// <summary>
    /// Unique player in the game
    /// </summary>
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GameId { get; set; }
        public float Points { get; set; }
        public int Rounds { get; set; } = 0;
        public User User { get; set; }
    }
}
