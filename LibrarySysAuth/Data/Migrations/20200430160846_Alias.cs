using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySysAuth.Data.Migrations
{
    public partial class Alias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AliasofReader",
                table: "BookC",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AliasofReader",
                table: "BookC");
        }
    }
}
