using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Weblog.Infrastructure.EfCore;
namespace Weblog.Infrastracture.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly WeblogDbContext _context;

        public ArticleQuery(WeblogDbContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Select(x =>
                    new ArticleQueryView
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Tag = x.Tag,
                        Picture = x.Picture,
                        PictureAlt = x.PictureAlt,
                        PictureTitle = x.PictureTitle,
                        ShortDescription = x.ShortDescription,
                        ArticleCategory = x.ArticleCategory.Title,
                        CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    }).ToList();
        }

        public ArticleQueryView GetArticle(int id)
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Tag = x.Tag,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Body = x.Body,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
