using System.ComponentModel.DataAnnotations;

namespace WebSite.ViewModels
{
    public class ArticleViewModel
    {
        public required string Title { get; set; }
        public required string Content { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9а-яА-ЯёЁ]+)(,[a-zA-Z0-9а-яА-ЯёЁ]+)*$", ErrorMessage = "Разрешены только буквы, цифры и запятые")]
        public string? TagsInput { get; set; }

        public List<string>? Tags { get; set; }

        public string AuthorFullName { get; set; } = string.Empty;

        public DateTime CreatedDate{ get; set; } 
        public int CommentCount { get; set; }
    }
}
