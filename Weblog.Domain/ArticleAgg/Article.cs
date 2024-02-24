using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.Domain.ArticleCategoryAgg;

namespace Weblog.Domain.ArticleAgg
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string ShortDescription { get; set; }
        public string Body { get; set; }
        public int ArticleCategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public ArticleCategory ArticleCategory { get; private set; }


        protected Article()
        {
        }

        public Article(string title, string tag, string picture, string pictureAlt,
            string pictureTitle, string shortDescription, string body, int articleCategoryId)
        {
            Validate(title, articleCategoryId);

            Title = title;
            Tag = tag;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Body = body;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        private static void Validate(string title, long articleCategoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();

            if (articleCategoryId == 0)
                throw new ArgumentOutOfRangeException();
        }

        public void Edit(string title, string tag, string picture, string pictureAlt,
            string pictureTitle, string shortDescription, string body, int articleCategoryId)
        {
            Validate(title, articleCategoryId);

            Title = title;
            Tag = tag;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Body = body;
            ArticleCategoryId = articleCategoryId;
        }

        public void DeActive()
        {
            IsDeleted = true;
        }

        public void Active()
        {
            IsDeleted = false;
        }
    }
}
