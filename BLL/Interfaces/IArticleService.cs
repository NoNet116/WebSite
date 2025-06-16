
using BLL.DTO;
using DAL.Entities;

namespace BLL.Interfaces;
public interface IArticleService
{
    Task CreateArticleAsync(ArticleDTO model, User author);
    Task<IEnumerable<ArticleDTO>?> GetAllArticlesAsync();
   // Task DeleteAsync(int id);
    //Task<Article?> GetByIdAsync(int id);
    //Task UpdateAsync(Article model);
    //Task<IEnumerable<Article>> GetPagedAsync(int page, int pageSize);
}
