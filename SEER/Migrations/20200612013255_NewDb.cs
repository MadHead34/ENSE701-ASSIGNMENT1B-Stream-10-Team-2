using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace SEER.Migrations
{
    public partial class NewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcceptedArticle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    DOI = table.Column<string>(nullable: false),
                    SEMethod = table.Column<string>(nullable: true),
                    Practice = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true),
                    Participant = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedArticle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BibliographicReference",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    DOI = table.Column<string>(nullable: false),
                    SEMethod = table.Column<string>(nullable: false),
                    Practice = table.Column<string>(nullable: false),
                    Method = table.Column<string>(nullable: false),
                    Participant = table.Column<string>(nullable: false),
                    Result = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibliographicReference", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InitialArticle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    DOI = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialArticle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RejectedArticle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    DOI = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectedArticle", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedArticle");

            migrationBuilder.DropTable(
                name: "BibliographicReference");

            migrationBuilder.DropTable(
                name: "InitialArticle");

            migrationBuilder.DropTable(
                name: "RejectedArticle");
        }
    }
}
