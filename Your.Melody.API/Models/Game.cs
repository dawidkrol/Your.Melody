namespace Your.Melody.API.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public GameModes GameMode { get; set; }
        public List<Player> Players { get; set; }
        public Playlist Playlist { get; set; }
    }
}
