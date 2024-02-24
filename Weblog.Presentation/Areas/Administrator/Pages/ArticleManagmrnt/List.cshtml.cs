using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Application;
using Weblog.Application.Contracts.Article;

namespace Weblog.Presentation.Areas.Administrator.Pages.ArticleManagmrnt
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetList();
        }

        public RedirectToPageResult OnPostDeActive(int id)
        {
            _articleApplication.DeActive(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostActive(int id)
        {
            _articleApplication.Active(id);
            return RedirectToPage("./List");
        }

    }
}
