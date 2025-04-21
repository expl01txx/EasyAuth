using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAuth.Migrations
{
    /// <inheritdoc />
    public partial class AddHwidToToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hwid",
                table: "tokens",
                type: "TEXT",
                maxLength: 128,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hwid",
                table: "tokens");
        }
    }
}
