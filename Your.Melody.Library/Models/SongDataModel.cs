namespace Your.Melody.Library.Models
{
    public class SongDataModel
    {
        public Guid SongId { get; set; } = Guid.NewGuid();
        public string VideoUrl { get; set; }
        public string AudioUrl { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int SecToStart { get; set; }
    }
}
