using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> list();
        void Create(CreateArticleCategory command);
        void Edit(EditArticleCategory command);
        EditArticleCategory Get(int id);
        void DeActive(int id);
        void Active(int id);
    }
}
