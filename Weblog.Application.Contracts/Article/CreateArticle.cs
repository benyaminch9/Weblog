namespace Weblog.Application.Contracts.Article
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string Tag { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string ShortDescription { get; set; }
        public string Body { get; set; }
        public int ArticleCategoryId { get; set; }
    }
}
