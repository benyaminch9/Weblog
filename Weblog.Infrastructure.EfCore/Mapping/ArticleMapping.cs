using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.Domain.ArticleAgg;

namespace Weblog.Infrastructure.EfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.Tag);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.Picture);
            builder.Property(x => x.PictureAlt);
            builder.Property(x => x.PictureTitle);
            builder.Property(x => x.Body);
            builder.Property(x => x.ShortDescription);
        }
    }
}
