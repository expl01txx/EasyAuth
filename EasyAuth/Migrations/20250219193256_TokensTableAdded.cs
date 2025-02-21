using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAuth.Migrations
{
    /// <inheritdoc />
    public partial class TokensTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    owner_username = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    token = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    role = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    expire = table.Column<DateTime>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    is_freezed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokens", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tokens");
        }
    }
}
