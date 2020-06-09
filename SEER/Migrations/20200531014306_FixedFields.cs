using Microsoft.EntityFrameworkCore.Migrations;

namespace SEER.Migrations
{
    public partial class FixedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "BibliographicReference");

            migrationBuilder.DropColumn(
                name: "PageNumbers",
                table: "BibliographicReference");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "BibliographicReference");

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "BibliographicReference",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DOI",
                table: "BibliographicReference",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "BibliographicReference",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Participant",
                table: "BibliographicReference",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Practice",
                table: "BibliographicReference",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "BibliographicReference",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SEMethod",
                table: "BibliographicReference",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Method",
                table: "BibliographicReference");

            migrationBuilder.DropColumn(
                name: "Participant",
                table: "BibliographicReference");

            migrationBuilder.DropColumn(
                name: "Practice",
                table: "BibliographicReference");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "BibliographicReference");

            migrationBuilder.DropColumn(
                name: "SEMethod",
                table: "BibliographicReference");

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "BibliographicReference",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DOI",
                table: "BibliographicReference",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "BibliographicReference",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PageNumbers",
                table: "BibliographicReference",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Volume",
                table: "BibliographicReference",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
