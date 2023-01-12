using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eduard_Sergiu.Migrations
{
    public partial class Chefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Breakfast",
                type: "decimal(6,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ChefID",
                table: "Breakfast",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantID",
                table: "Breakfast",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chef",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChefName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breakfast_ChefID",
                table: "Breakfast",
                column: "ChefID");

            migrationBuilder.CreateIndex(
                name: "IX_Breakfast_RestaurantID",
                table: "Breakfast",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Breakfast_Chef_ChefID",
                table: "Breakfast",
                column: "ChefID",
                principalTable: "Chef",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Breakfast_Restaurant_RestaurantID",
                table: "Breakfast",
                column: "RestaurantID",
                principalTable: "Restaurant",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breakfast_Chef_ChefID",
                table: "Breakfast");

            migrationBuilder.DropForeignKey(
                name: "FK_Breakfast_Restaurant_RestaurantID",
                table: "Breakfast");

            migrationBuilder.DropTable(
                name: "Chef");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Breakfast_ChefID",
                table: "Breakfast");

            migrationBuilder.DropIndex(
                name: "IX_Breakfast_RestaurantID",
                table: "Breakfast");

            migrationBuilder.DropColumn(
                name: "ChefID",
                table: "Breakfast");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "Breakfast");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Breakfast",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,0)");
        }
    }
}
