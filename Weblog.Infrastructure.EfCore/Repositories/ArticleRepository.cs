using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.Application.Contracts.Article;
using Weblog.Domain.ArticleAgg;

namespace Weblog.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly WeblogDbContext _context;

        public ArticleRepository(WeblogDbContext context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate
            }).ToList();
        }
        public void CreateAndSave(Article entity)
        {
            _context.Articles.Add(entity);
            Save();
        }

        public Article Get(int id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exist(string title)
        {
            return _context.Articles.Any(x => x.Title == title);
        }
    }
}
