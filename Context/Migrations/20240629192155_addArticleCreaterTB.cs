using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_MediatR.Migrations
{
    /// <inheritdoc />
    public partial class addArticleCreaterTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleCreaterId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArticleCreater",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCreater", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_ArticleCreaterId",
                table: "News",
                column: "ArticleCreaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_ArticleCreater_ArticleCreaterId",
                table: "News",
                column: "ArticleCreaterId",
                principalTable: "ArticleCreater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_ArticleCreater_ArticleCreaterId",
                table: "News");

            migrationBuilder.DropTable(
                name: "ArticleCreater");

            migrationBuilder.DropIndex(
                name: "IX_News_ArticleCreaterId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ArticleCreaterId",
                table: "News");
        }
    }
}
