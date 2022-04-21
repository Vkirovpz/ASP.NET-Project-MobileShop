namespace MobileShop.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    public partial class dealerTownAndImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Dealers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Dealers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Dealers");
        }
    }
}
