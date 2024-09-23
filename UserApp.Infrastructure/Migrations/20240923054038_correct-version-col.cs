using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correctversioncol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "version",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "version",
                table: "Users",
                type: "bigint",
                rowVersion: true,
                nullable: false,
                defaultValue: 0L);
        }
    }
}
