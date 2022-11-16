namespace Your.Melody.API.Models
{
    /// <summary>
    /// Registered user
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
