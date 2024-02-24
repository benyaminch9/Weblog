using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.Domain.ArticleCategoryAgg.Services;

namespace Weblog.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }

        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyTitle(title);
            validatorService.CheckThatThisRecordAlreadyExists(title);

            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        protected ArticleCategory()
        {
            
        }

        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }

        public void Edit(string title)
        {
            GuardAgainstEmptyTitle(title);

            Title = title;
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
