namespace Your.Melody.API.Models
{
    /// <summary>
    /// Confirmed playlist that guarantees the right titles,
    /// artist names and where the music will start
    /// </summary>
    public class ApprovedPlaylist : Playlist
    {
        public Guid Id { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SongModel> Songs { get; set; }
        public int Likes { get; set; } = 0;
        public int Unlikes { get; set; } = 0;
    }
}
