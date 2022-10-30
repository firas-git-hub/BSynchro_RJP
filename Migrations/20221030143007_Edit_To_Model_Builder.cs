using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSynchro_RJP.Migrations
{
    public partial class Edit_To_Model_Builder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UsersAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "AccountsTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersAccounts_UserId1",
                table: "UsersAccounts",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsTransactions_UserAccountId",
                table: "AccountsTransactions",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsTransactions_UsersAccounts_UserAccountId",
                table: "AccountsTransactions",
                column: "UserAccountId",
                principalTable: "UsersAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAccounts_Users_UserId1",
                table: "UsersAccounts",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsTransactions_UsersAccounts_UserAccountId",
                table: "AccountsTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAccounts_Users_UserId1",
                table: "UsersAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UsersAccounts_UserId1",
                table: "UsersAccounts");

            migrationBuilder.DropIndex(
                name: "IX_AccountsTransactions_UserAccountId",
                table: "AccountsTransactions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UsersAccounts");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "AccountsTransactions");
        }
    }
}
