using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllAsync();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> LoadMore(int page = 1, int pageSize = 5)
        {
            var articles = await _articleService.GetPagedAsync(page, pageSize);
            return PartialView("_ArticleListPartial", articles);
        }

        public async Task<IActionResult> Details(int id)
        {
            var article = await _articleService.GetByIdAsync(id);
            if (article == null) return NotFound();
            return View(article);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Article model)
        {
            if (!ModelState.IsValid) return View(model);
            await _articleService.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var article = await _articleService.GetByIdAsync(id);
            if (article == null) return NotFound();
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article model)
        {
            if (!ModelState.IsValid) return View(model);
            await _articleService.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _articleService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
