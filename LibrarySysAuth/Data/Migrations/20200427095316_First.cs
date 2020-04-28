using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySysAuth.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    ReaderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.ReaderID);
                });

            migrationBuilder.CreateTable(
                name: "BookB",
                columns: table => new
                {
                    BookBID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleB = table.Column<string>(nullable: true),
                    AuthorB = table.Column<string>(nullable: true),
                    Rented = table.Column<bool>(nullable: false),
                    RentedbyReader = table.Column<int>(nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookB", x => x.BookBID);
                    
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookB_ReaderID",
                table: "BookB",
                column: "RentedbyReader");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookB");

            migrationBuilder.DropTable(
                name: "Reader");
        }
    }
}
