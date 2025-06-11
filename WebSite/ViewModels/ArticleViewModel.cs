using System.ComponentModel.DataAnnotations;

namespace WebSite.ViewModels
{
    public class ArticleViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();

        public DateTime CreatedAt { get; set; }

        public string AuthorName { get; set; } = string.Empty;
        public int CommentCount { get; set; }
    }
}
