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

        public async Task<IEnumerable<ArticleDTO>> GetAllArticlesAsync()
        {
            var articles = await _repository.GetAllAsync(
                a => a.Author
                //a => a.Tags,
               // a => a.Comments
             );

            return articles.Select(a => new ArticleDTO
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedAt = a.CreatedAt,
                Author = new UserDTO
                {
                    FirstName = a.Author.FirstName,
                    LastName = a.Author.LastName,
                    UserName = a.Author.UserName,
                    FatherName = a.Author.FatherName,
                    Email = a.Author.Email,

                },
                Tags =  a.Tags.Select(t => t.Name).ToList(),
                CommentCount = a.Comments.Count
            });

        }

        public async Task<ArticleDTO?> GetArticleByIdAsync(int id)
        {
            var a = await _repository.GetByIdAsync(id);
            if (a == null) return null;

            return new ArticleDTO
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedAt = a.CreatedAt,
               // AuthorName = a.Author.LastName,
                Tags = a.Tags.Select(t => t.Name).ToList(),
                CommentCount = a.Comments.Count
            };
        }

        public async Task CreateArticleAsync(ArticleDTO model, User author)
        {
            var article = new Article
            {
                Title = model.Title,
                Content = model.Content,
                CreatedAt = DateTime.UtcNow,
                Author = author,
                Tags = model.Tags.Select(t => new Tag { Name = t, Id =1}).ToList()
            };
            await _repository.AddAsync(article);
        }
    }

}

