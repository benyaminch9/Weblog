using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Weblog.Application;
using Weblog.Application.Contracts.Article;
using Weblog.Application.Contracts.ArticleCategory;
using Weblog.Domain.ArticleAgg;
using Weblog.Domain.ArticleAgg.Services;
using Weblog.Domain.ArticleCategoryAgg;
using Weblog.Domain.ArticleCategoryAgg.Services;
using Weblog.Infrastracture.Query;
using Weblog.Infrastructure.EfCore;
using Weblog.Infrastructure.EfCore.Repositories;

namespace Weblog.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleValidatorService, ArticleValidatorService>();

            services.AddTransient<IArticleQuery, ArticleQuery>();

            services.AddDbContext<WeblogDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
