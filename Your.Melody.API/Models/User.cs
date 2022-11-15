namespace Your.Melody.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Points { get; set; }
        public int PlaceInRanking { get; set; }
    }
}
