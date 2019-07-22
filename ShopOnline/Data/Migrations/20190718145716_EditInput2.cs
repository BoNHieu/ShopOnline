using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class EditInput2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Inputs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_UserId",
                table: "Inputs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inputs_AspNetUsers_UserId",
                table: "Inputs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inputs_AspNetUsers_UserId",
                table: "Inputs");

            migrationBuilder.DropIndex(
                name: "IX_Inputs_UserId",
                table: "Inputs");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Inputs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
