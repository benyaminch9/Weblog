using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.Domain.ArticleAgg;
using Weblog.Domain.ArticleCategoryAgg;
using Weblog.Infrastructure.EfCore.Mapping;

namespace Weblog.Infrastructure.EfCore
{
    public class WeblogDbContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        public WeblogDbContext(DbContextOptions<WeblogDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            base.OnModelCreating(modelBuilder);
        }


    }
}
