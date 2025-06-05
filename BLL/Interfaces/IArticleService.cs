
using DAL.Entities;

namespace BLL.Interfaces;
public interface IArticleService
{
    Task CreateAsync(Article model);
    Task DeleteAsync(int id);
    Task<IEnumerable<Article>?> GetAllAsync();
    Task<Article?> GetByIdAsync(int id);
    Task UpdateAsync(Article model);
    Task<IEnumerable<Article>> GetPagedAsync(int page, int pageSize);
}
