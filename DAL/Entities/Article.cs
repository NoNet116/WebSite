namespace DAL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public User Author { get; set; } = default!; // Навигационное свойство
    }
}
