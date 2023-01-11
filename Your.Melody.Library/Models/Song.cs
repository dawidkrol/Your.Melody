namespace Your.Melody.Library.Models
{
    public class Song : SongDataModel
    {
        public bool WasPlayed { get; set; }
        public PlayerModel Player { get; set; }
        public float Points { get; set; }
    }
}
