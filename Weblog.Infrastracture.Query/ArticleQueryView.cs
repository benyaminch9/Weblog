using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.Infrastracture.Query
{
    public class ArticleQueryView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string ArticleCategory { get; set; }
        public string Body { get; set; }
        public string CreationDate { get; set; }
    }
}
