namespace Your.Melody.Library.Models
{
    public class ApprovedPlaylist
    {
        public Guid Id { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Song> Songs { get; set; }
        public int Likes { get; set; } = 0;
        public int Unlikes { get; set; } = 0;
    }
}
