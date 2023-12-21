using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedAutoMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Libary_Archive",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Libary_Archive",
                keyColumn: "Id",
                keyValue: 1,
                column: "Genre",
                value: "Educational");

            migrationBuilder.UpdateData(
                table: "Libary_Archive",
                keyColumn: "Id",
                keyValue: 2,
                column: "Genre",
                value: "Educational");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Libary_Archive");
        }
    }
}
