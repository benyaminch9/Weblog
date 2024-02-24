using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Application.Contracts.ArticleCategory;

namespace Weblog.Presentation.Areas.Administrator.Pages.ArticleCategoryManagment
{
    public class CreateModel : PageModel
    {

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {

        }

        public RedirectToPageResult OnPost(CreateArticleCategory command)
        {
            _articleCategoryApplication.Create(command);
            return RedirectToPage("./List");
        }

    }
}
