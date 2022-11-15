namespace Your.Melody.API.Models
{
    public class ApprovedPlaylist : Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; } = 0;
        public int Unlikes { get; set; } = 0;
    }
}
