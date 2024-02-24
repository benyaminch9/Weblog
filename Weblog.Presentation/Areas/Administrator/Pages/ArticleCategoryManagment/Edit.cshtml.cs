using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Application.Contracts.ArticleCategory;
using Weblog.Domain.ArticleCategoryAgg;

namespace Weblog.Presentation.Areas.Administrator.Pages.ArticleCategoryManagment
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditArticleCategory ArticleCategory { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(int id)
        {
            ArticleCategory = _articleCategoryApplication.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Edit(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}
