namespace Your.Melody.API.Models
{
    /// <summary>
    /// Song model to use before the game to present or edit the song data
    /// </summary>
    public class SongModel
    {
        public Guid SongId { get; set; } = new Guid();
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
    }
}
