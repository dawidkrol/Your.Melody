namespace Your.Melody.API.Models
{
    /// <summary>
    /// Playlist model to use in the game
    /// </summary>
    public class Playlist
    {
        public Guid Id { get; set; }
        public List<Song> Songs { get; set; }
    }
}
