using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibraryWebApi.Migrations
{
    public partial class changedBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IfOwned",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IfRead",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IfOwned",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IfRead",
                table: "Books");
        }
    }
}
