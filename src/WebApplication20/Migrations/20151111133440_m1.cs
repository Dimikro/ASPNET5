using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace WebApplication20.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterEntity", x => x.Id);
                });
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
            migrationBuilder.CreateTable(
                name: "SlaveEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MasterId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlaveEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlaveEntity_MasterEntity_MasterId",
                        column: x => x.MasterId,
                        principalTable: "MasterEntity",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "MasterToRole",
                columns: table => new
                {
                    RoleId = table.Column<string>(nullable: false),
                    MasterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterToRole", x => new { x.RoleId, x.MasterID });
                    table.ForeignKey(
                        name: "FK_MasterToRole_MasterEntity_MasterID",
                        column: x => x.MasterID,
                        principalTable: "MasterEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MasterToRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("MasterToRole");
            migrationBuilder.DropTable("SlaveEntity");
            migrationBuilder.DropTable("Role");
            migrationBuilder.DropTable("MasterEntity");
        }
    }
}
