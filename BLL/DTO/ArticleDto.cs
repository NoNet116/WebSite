namespace BLL.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public UserDTO Author { get; set; } = default!;
        public List<string> Tags { get; set; } = new();
        public int CommentCount { get; set; }

    }
}
