using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        EditArticle Get(int id);
        void DeActive(int id);
        void Active(int id);
    }

}
