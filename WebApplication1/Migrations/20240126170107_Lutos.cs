using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
	public partial class Lutos : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Users_Info",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
					Role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
					UserName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
					FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
					LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
					Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
					PostalCode = table.Column<int>(type: "int", maxLength: 15, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users_Info", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Products_Info",
				columns: table => new
				{
					ProductID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Available = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
					Category = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
					Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					Main_Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					ProductDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					Liked = table.Column<int>(type: "int", nullable: true),
					ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					ProductPrice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Slider = table.Column<bool>(type: "bit", nullable: true),
					MyUsersId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products_Info", x => x.ProductID);
					table.ForeignKey(
						name: "FK_Products_Info_Users_Info_MyUsersId",
						column: x => x.MyUsersId,
						principalTable: "Users_Info",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "Product_Comments",
				columns: table => new
				{
					CommentID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ProductID = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
					Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					MyproductsProductID = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Product_Comments", x => x.CommentID);
					table.ForeignKey(
						name: "FK_Product_Comments_Products_Info_MyproductsProductID",
						column: x => x.MyproductsProductID,
						principalTable: "Products_Info",
						principalColumn: "ProductID");
				});

			migrationBuilder.CreateIndex(
				name: "IX_Product_Comments_MyproductsProductID",
				table: "Product_Comments",
				column: "MyproductsProductID");

			migrationBuilder.CreateIndex(
				name: "IX_Products_Info_MyUsersId",
				table: "Products_Info",
				column: "MyUsersId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Product_Comments");

			migrationBuilder.DropTable(
				name: "Products_Info");

			migrationBuilder.DropTable(
				name: "Users_Info");
		}
	}
}
