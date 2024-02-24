using Weblog.Domain.ArticleCategoryAgg;
using Weblog.Domain.ArticleCategoryAgg.Exeption;

namespace Weblog.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (_articleCategoryRepository.GetAll().Any(x => x.Title == title))
                throw new DuplicatedRecordException("This record already exists in database");
        }
    }

}
