using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.Application.Contracts.Article;

namespace Weblog.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void CreateAndSave(Article entity);
        Article Get(int id);
        void Save();
        bool Exist(string title);

    }
}
