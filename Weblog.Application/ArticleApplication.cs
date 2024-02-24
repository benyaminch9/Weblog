using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.Application.Contracts.Article;
using Weblog.Domain.ArticleAgg;
using Weblog.Infrastructure.EfCore.Repositories;

namespace Weblog.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepositoy;

        public ArticleApplication(IArticleRepository articleRepositoy)
        {
            _articleRepositoy = articleRepositoy;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepositoy.GetList();
        }
        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.Tag, command.Picture, command.PictureAlt,
                command.PictureTitle, command.ShortDescription, command.Body, command.ArticleCategoryId);
            _articleRepositoy.CreateAndSave(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepositoy.Get(command.Id);
            article.Edit(command.Title, command.Tag, command.Picture, command.PictureAlt,
                command.PictureTitle, command.ShortDescription, command.Body, command.ArticleCategoryId);
            _articleRepositoy.Save();
        }

        public EditArticle Get(int id)
        {
            var article = _articleRepositoy.Get(id);

            if (article == null)
            {
                return null; // یا مقدار پیشفرض دیگری که مناسب است را برگردانید
            }

            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                Tag = article.Tag,
                Picture = article.Picture,
                PictureAlt = article.PictureAlt,
                PictureTitle = article.PictureTitle,
                ShortDescription = article.ShortDescription,
                Body = article.Body,
                ArticleCategoryId = article.ArticleCategoryId
            };
           
        }

        public void DeActive(int id)
        {
            var article = _articleRepositoy.Get(id);
            article.DeActive();
            _articleRepositoy.Save();
        }

        public void Active(int id)
        {
            var article = _articleRepositoy.Get(id);
            article.Active();
            _articleRepositoy.Save();
        }
    }
}
