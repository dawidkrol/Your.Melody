using System.Reflection.Metadata.Ecma335;

namespace Your.Melody.API.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GameId { get; set; }
        public double Points { get; set; }
        public int Rounds { get; set; } = 0;
    }
}
