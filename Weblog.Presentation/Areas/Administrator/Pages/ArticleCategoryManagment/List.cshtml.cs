using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Application.Contracts.ArticleCategory;

namespace Weblog.Presentation.Areas.Administrator.Pages.ArticleCategoryManagment
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.list();
        }

        public RedirectToPageResult OnPostDeActive(int id)
        {
            _articleCategoryApplication.DeActive(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostActive(int id)
        {
            _articleCategoryApplication.Active(id);
            return RedirectToPage("./List");
        }
    }
}
