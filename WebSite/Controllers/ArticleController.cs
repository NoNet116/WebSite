using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ArticleController(IArticleService articleService, IMapper mapper, IUserService userService)
        {
            _articleService = articleService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ArticleViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = _mapper.Map<ArticleViewModel,ArticleDto>(model);

            var user = await _userService.GetUserAsync(User);

            await _articleService.CreateArticleAsync(dto, user);
            return RedirectToAction("Index");
        }

        [HttpGet]
         public async Task<IActionResult> Index()
          {
            var articles = await _articleService.GetAllArticlesAsync();
            
            return View(articles);
          }
        /* 
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
          }*/
    }
}
