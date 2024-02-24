using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.Application.Contracts.ArticleCategory;
using Weblog.Domain.ArticleCategoryAgg;
using Weblog.Domain.ArticleCategoryAgg.Services;

namespace Weblog.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _validatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService validatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _validatorService = validatorService;
        }


        public List<ArticleCategoryViewModel> list()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }
            return result;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title, _validatorService);
            _articleCategoryRepository.Add(articleCategory);
        }

        public void Edit(EditArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Edit(command.Title);
            _articleCategoryRepository.Save();
        }

        public EditArticleCategory Get(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new EditArticleCategory
            {
                Id=articleCategory.Id,
                Title=articleCategory.Title,
            };
        }

        public void DeActive(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.DeActive();
            _articleCategoryRepository.Save();
        }

        public void Active(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Active();
            _articleCategoryRepository.Save();
        }

    }
}
