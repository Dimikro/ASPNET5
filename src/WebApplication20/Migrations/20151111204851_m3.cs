using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WebApplication20.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_MasterToRole_Role_RoleId", table: "MasterToRole");
            migrationBuilder.DropPrimaryKey(name: "PK_MasterToRole", table: "MasterToRole");
            migrationBuilder.DropColumn(name: "RoleId", table: "MasterToRole");
            migrationBuilder.DropTable("Role");
            migrationBuilder.AlterColumn<string>(
                name: "IdentityRoleId",
                table: "MasterToRole",
                nullable: false);
            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterToRole",
                table: "MasterToRole",
                columns: new[] { "IdentityRoleId", "MasterID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_MasterToRole", table: "MasterToRole");
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });
            migrationBuilder.AlterColumn<string>(
                name: "IdentityRoleId",
                table: "MasterToRole",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "MasterToRole",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterToRole",
                table: "MasterToRole",
                columns: new[] { "RoleId", "MasterID" });
            migrationBuilder.AddForeignKey(
                name: "FK_MasterToRole_Role_RoleId",
                table: "MasterToRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }
    }
}
