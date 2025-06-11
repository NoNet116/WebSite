using DAL.Entities;
using BLL.DTO;
using DAL.Interfaces;
using BLL.Interfaces;

namespace BLL.Services
{
    public class ArticleService: IArticleService
    {
        private readonly IRepository<Article> _repository;

        public ArticleService(IRepository<Article> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ArticleDto>> GetAllArticlesAsync()
        {
            var articles = await _repository.GetAllAsync();

            return articles.Select(a => new ArticleDto
            {
                
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedAt = a.CreatedAt,
                AuthorName = a.AuthorId,
                Tags = a.Tags.Select(t => t.Name).ToList(),
                CommentCount = a.Comments.Count
            });
        }

        public async Task<ArticleDto?> GetArticleByIdAsync(int id)
        {
            var a = await _repository.GetByIdAsync(id);
            if (a == null) return null;

            return new ArticleDto
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedAt = a.CreatedAt,
                AuthorName = a.Author.LastName,
                Tags = a.Tags.Select(t => t.Name).ToList(),
                CommentCount = a.Comments.Count
            };
        }

        public async Task CreateArticleAsync(ArticleDto model, User author)
        {
            var article = new Article
            {
                Title = model.Title,
                Content = model.Content,
                CreatedAt = DateTime.UtcNow,
                Author = author,
                Tags = model.Tags.Select(t => new Tag { Name = t }).ToList()
            };
            await _repository.AddAsync(article);
        }
    }

}

