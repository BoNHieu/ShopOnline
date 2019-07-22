using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class EditClassInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inputs_AspNetUsers_UserId",
                table: "Inputs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Inputs",
                newName: "ApplicationUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Inputs_UserId",
                table: "Inputs",
                newName: "IX_Inputs_ApplicationUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inputs_AspNetUsers_ApplicationUsersId",
                table: "Inputs",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inputs_AspNetUsers_ApplicationUsersId",
                table: "Inputs");

            migrationBuilder.RenameColumn(
                name: "ApplicationUsersId",
                table: "Inputs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Inputs_ApplicationUsersId",
                table: "Inputs",
                newName: "IX_Inputs_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inputs_AspNetUsers_UserId",
                table: "Inputs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
