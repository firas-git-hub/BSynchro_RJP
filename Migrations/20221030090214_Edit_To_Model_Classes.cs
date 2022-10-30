using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSynchro_RJP.Migrations
{
    public partial class Edit_To_Model_Classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsTransactions_UsersAccounts_UserAccountId",
                table: "AccountsTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAccounts_Users_UserId",
                table: "UsersAccounts");

            migrationBuilder.DropIndex(
                name: "IX_AccountsTransactions_UserAccountId",
                table: "AccountsTransactions");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "UsersAccounts");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UsersAccounts");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "AccountsTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UsersAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "UsersAccounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "AccountsTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsTransactions_AccountId",
                table: "AccountsTransactions",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsTransactions_UsersAccounts_AccountId",
                table: "AccountsTransactions",
                column: "AccountId",
                principalTable: "UsersAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAccounts_Users_UserId",
                table: "UsersAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsTransactions_UsersAccounts_AccountId",
                table: "AccountsTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAccounts_Users_UserId",
                table: "UsersAccounts");

            migrationBuilder.DropIndex(
                name: "IX_AccountsTransactions_AccountId",
                table: "AccountsTransactions");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "UsersAccounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AccountsTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UsersAccounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UsersAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UsersAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAccounts_Users_UserId",
                table: "UsersAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
