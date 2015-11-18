using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace WebApplication20.Migrations
{
    public partial class m8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Message", table: "Message");
            migrationBuilder.DropColumn(name: "Id", table: "Message");
            migrationBuilder.DropColumn(name: "Link", table: "Message");
            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Message",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Message", table: "Message");
            migrationBuilder.DropColumn(name: "Guid", table: "Message");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Message",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Message",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");
        }
    }
}
