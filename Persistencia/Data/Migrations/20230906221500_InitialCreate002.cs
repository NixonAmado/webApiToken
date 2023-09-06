using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolUser_Rol_RolsId",
                table: "RolUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RolUser_User_UsersId",
                table: "RolUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRols_Rol_RolId",
                table: "UsersRols");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRols_User_UserId",
                table: "UsersRols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Rols");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rols",
                table: "Rols",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolUser_Rols_RolsId",
                table: "RolUser",
                column: "RolsId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolUser_Users_UsersId",
                table: "RolUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRols_Rols_RolId",
                table: "UsersRols",
                column: "RolId",
                principalTable: "Rols",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRols_Users_UserId",
                table: "UsersRols",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolUser_Rols_RolsId",
                table: "RolUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RolUser_Users_UsersId",
                table: "RolUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRols_Rols_RolId",
                table: "UsersRols");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRols_Users_UserId",
                table: "UsersRols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rols",
                table: "Rols");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Rols",
                newName: "Rol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolUser_Rol_RolsId",
                table: "RolUser",
                column: "RolsId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolUser_User_UsersId",
                table: "RolUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRols_Rol_RolId",
                table: "UsersRols",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRols_User_UserId",
                table: "UsersRols",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
