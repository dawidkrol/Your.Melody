namespace Your.Melody.API.Models
{
    /// <summary>
    /// Playlist model to use before the game to present or edit the playlist
    /// </summary>
    public class PlaylistModel
    {
        public List<SongModel> Songs { get; set; }
    }
}
