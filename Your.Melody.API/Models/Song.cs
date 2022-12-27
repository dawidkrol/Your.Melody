namespace Your.Melody.API.Models
{
    /// <summary>
    /// Song model to use in the game
    /// </summary>
    public class Song
    {
        public Guid SongId { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public bool WasPlayed { get; set; }
        public Player Player { get; set; }
        public double Points { get; set; }
        public int SecToStart { get; set; }
    }
}
