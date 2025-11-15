namespace TomekReads.Server.Data.Models
{
    public class Book
    {
        public required string Id { get; set; } // this should be ISBN
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int? Rating { get; set; }
        public string? Review { get; set; }
    }
}
