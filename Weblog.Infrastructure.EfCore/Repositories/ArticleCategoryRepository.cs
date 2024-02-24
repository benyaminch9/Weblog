using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.Domain.ArticleCategoryAgg;

namespace Weblog.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly WeblogDbContext _context;

        public ArticleCategoryRepository(WeblogDbContext context)
        {
            _context = context;
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(x => x.Id).ToList();
        }

        public void Add(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            Save();
        }

        public ArticleCategory Get(int id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exists(string title)
        {
            return _context.ArticleCategories.Any(x => x.Title == title);
        }
    }
}
