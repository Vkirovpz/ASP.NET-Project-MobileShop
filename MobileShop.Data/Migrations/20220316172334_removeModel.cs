using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileShop.Data.Migrations
{
    public partial class removeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Models_ModelId",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Phones_ModelId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Phones");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Phones",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Phones");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ModelId",
                table: "Phones",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Models_ModelId",
                table: "Phones",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
