using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSynchro_RJP.Migrations
{
    public partial class Model_Builder_Service_Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsTransactions_UsersAccounts_UserAccountId",
                table: "AccountsTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AccountsTransactions_UserAccountId",
                table: "AccountsTransactions");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "AccountsTransactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "AccountsTransactions",
                type: "int",
                nullable: true);

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
        }
    }
}
