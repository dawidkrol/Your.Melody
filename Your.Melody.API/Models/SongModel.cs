namespace Your.Melody.API.Models
{
    /// <summary>
    /// Song model to use before the game to present or edit the song data
    /// </summary>
    public class SongModel
    {
        public Guid SongId { get; set; }
        public string VideoUrl { get; set; }
        public string AudioUrl { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int SecToStart { get; set; }
    }
}
