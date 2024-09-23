using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstNames = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondNames = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstLastNames = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondLastNames = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birthdays = table.Column<DateOnly>(type: "date", nullable: false),
                    Salarys = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDates = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDates = table.Column<DateTime>(type: "datetime2", nullable: true),
                    version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
