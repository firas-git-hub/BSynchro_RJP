using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSynchro_RJP.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAccounts_Users_UserId1",
                table: "UsersAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UsersAccounts_UserId1",
                table: "UsersAccounts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UsersAccounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UsersAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersAccounts_UserId1",
                table: "UsersAccounts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAccounts_Users_UserId1",
                table: "UsersAccounts",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
