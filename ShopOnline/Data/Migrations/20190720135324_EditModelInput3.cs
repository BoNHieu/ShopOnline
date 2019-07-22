using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class EditModelInput3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inputs_AspNetUsers_ApplicationUsersId",
                table: "Inputs");

            migrationBuilder.DropIndex(
                name: "IX_Inputs_ApplicationUsersId",
                table: "Inputs");

            migrationBuilder.RenameColumn(
                name: "ApplicationUsersId",
                table: "Inputs",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Inputs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Inputs",
                newName: "ApplicationUsersId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUsersId",
                table: "Inputs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_ApplicationUsersId",
                table: "Inputs",
                column: "ApplicationUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inputs_AspNetUsers_ApplicationUsersId",
                table: "Inputs",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
