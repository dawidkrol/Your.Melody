using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Your.Melody.Library.Models
{
    public class Song
    {
        public Guid SongId { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public bool WasPlayed { get; set; }
        public PlayerModel Player { get; set; }
        public double Points { get; set; }
        public int SecToStart { get; set; }
    }
}
