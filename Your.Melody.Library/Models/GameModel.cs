namespace Your.Melody.Library.Models
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public GameModes GameMode { get; set; }
        public List<PlayerModel> Players { get; set; }
        public Playlist Playlist { get; set; }
    }
}
