namespace Your.Melody.API.Models
{
    public class Song
    {
        public Guid SongId { get; set; } = new Guid();
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public bool WasPlayed { get; set; }
        public Player Player { get; set; }
        public double Points { get; set; }
        //public string ChannelTitle { get; set; }
    }
}
