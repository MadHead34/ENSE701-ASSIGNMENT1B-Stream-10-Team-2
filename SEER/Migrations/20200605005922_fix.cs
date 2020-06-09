using Microsoft.EntityFrameworkCore.Migrations;

namespace SEER.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcceptedArticle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_AcceptedArticle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InitialArticle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    DOI = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialArticle", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedArticle");

            migrationBuilder.DropTable(
                name: "InitialArticle");
        }
    }
}
