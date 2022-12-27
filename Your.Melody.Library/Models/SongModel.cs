namespace Your.Melody.Library.Models
{
    public class SongModel
    {
        public ContentDetailsModel contentDetails { get; set; }
        public SnippetModel snippet { get; set; }
        public class SnippetModel
        {
            public string title { get; set; }
        }
        public class ContentDetailsModel
        {
            public string videoId { get; set; }
        }
    }
}
