using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Your.Melody.Library.Models
{
    public class Song : SongDataModel
    {
        public bool WasPlayed { get; set; }
        public PlayerModel Player { get; set; }
        public double Points { get; set; }
    }
}
