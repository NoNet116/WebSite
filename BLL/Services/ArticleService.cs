using BLL.Interfaces;
using DAL.Entities;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class ArticleService:IArticleService
    {
        private readonly AppDbContext _context;

        public ArticleService(AppDbContext context)
        {
            _context = context;
        }

        // Получить все статьи (если нужно где-то)
        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        // ПАГИНАЦИЯ: получить статьи постранично
        public async Task<IEnumerable<Article>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Articles
                .OrderByDescending(a => a.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        // Пример: получить статью по Id
        public async Task<Article?> GetByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        // Пример: создать статью
        public async Task CreateAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        // Пример: удалить
        public async Task DeleteAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }

        public Task UpdateAsync(Article model)
        {
            throw new NotImplementedException();
        }
    }
}

