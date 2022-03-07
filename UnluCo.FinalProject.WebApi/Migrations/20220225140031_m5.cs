using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UnluCo.FinalProject.WebApi.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPicture",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductPictureId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UploadedFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductPictureId",
                table: "Products",
                column: "ProductPictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UploadedFile_ProductPictureId",
                table: "Products",
                column: "ProductPictureId",
                principalTable: "UploadedFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UploadedFile_ProductPictureId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "UploadedFile");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductPictureId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPictureId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductPicture",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
