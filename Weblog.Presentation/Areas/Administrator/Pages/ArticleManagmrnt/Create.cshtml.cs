using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Weblog.Application.Contracts.Article;
using Weblog.Application.Contracts.ArticleCategory;

namespace Weblog.Presentation.Areas.Administrator.Pages.ArticleManagmrnt
{
    public class CreateModel : PageModel
    {
        public List<SelectListItem> ArticleCategories { get; set; }

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.list()
                .Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }

        public RedirectToPageResult OnPost(CreateArticle command)
        {
            _articleApplication.Create(command);
            return RedirectToPage("./List");
        }
    }
}
