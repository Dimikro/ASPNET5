using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace WebApplication20.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "LookUpValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LookUpId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUpValue_LookUp_LookUpId",
                        column: x => x.LookUpId,
                        principalTable: "LookUp",
                        principalColumn: "Id");
                });
            migrationBuilder.AddColumn<string>(
                name: "IdentityRoleId",
                table: "MasterToRole",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_MasterToRole_IdentityRole_IdentityRoleId",
                table: "MasterToRole",
                column: "IdentityRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_MasterToRole_IdentityRole_IdentityRoleId", table: "MasterToRole");
            migrationBuilder.DropColumn(name: "IdentityRoleId", table: "MasterToRole");
            migrationBuilder.DropTable("LookUpValue");
            migrationBuilder.DropTable("LookUp");
        }
    }
}
