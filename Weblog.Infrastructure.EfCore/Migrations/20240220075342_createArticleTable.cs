using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weblog.Infrastructure.EfCore.Migrations
{
    public partial class createArticleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "PictureAlt",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "PictureTitle",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "ArticleCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "ArticleCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "ArticleCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureAlt",
                table: "ArticleCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureTitle",
                table: "ArticleCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "ArticleCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "ArticleCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
