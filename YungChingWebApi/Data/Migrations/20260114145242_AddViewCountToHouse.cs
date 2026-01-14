using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YungChingWebApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddViewCountToHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Houses");
        }
    }
}
