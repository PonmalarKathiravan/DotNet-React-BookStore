using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetapp.Migrations
{
    public partial class initialtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartModels",
                columns: table => new
                {
                    sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cartId = table.Column<string>(nullable: true),
                    productName = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    quantity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartModels", x => x.sno);
                });

            migrationBuilder.CreateTable(
                name: "OrderModels",
                columns: table => new
                {
                    sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<string>(nullable: true),
                    productName = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    quantity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModels", x => x.sno);
                });

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    imageUrl = table.Column<string>(nullable: true),
                    quantity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true),
                    mobileNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.sno);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartModels");

            migrationBuilder.DropTable(
                name: "OrderModels");

            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropTable(
                name: "UserModels");
        }
    }
}
