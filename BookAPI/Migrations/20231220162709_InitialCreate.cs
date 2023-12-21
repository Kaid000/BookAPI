using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Libary_Archive");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Libary_Archive",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Libary_Archive_ISBN",
                table: "Libary_Archive",
                column: "ISBN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libary_Archive",
                table: "Libary_Archive",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Libary_Archive",
                columns: new[] { "Id", "Author", "Description", "ISBN", "Title", "WhenTake", "WhenTakeLast" },
                values: new object[,]
                {
                    { 1, "Jeffrey Richter", "The book about C# and .NET", "4-7650-21", "CLR via C#", null, null },
                    { 2, "Lafore Robert", "The book about C++, STL and basic algorithms", "4-5421-61", "C++ Programming", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Libary_Archive_ISBN",
                table: "Libary_Archive");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libary_Archive",
                table: "Libary_Archive");

            migrationBuilder.DeleteData(
                table: "Libary_Archive",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Libary_Archive",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Libary_Archive",
                newName: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");
        }
    }
}
