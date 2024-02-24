using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.Application.Contracts.ArticleCategory
{
    public class EditArticleCategory : CreateArticleCategory
    {
        public int Id { get; set; }
    }
}
