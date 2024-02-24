using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        ArticleCategory Get(int id);
        void Add(ArticleCategory entity);
        void Save();
        bool Exists(string title);
    }
}
