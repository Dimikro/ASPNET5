using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WebApplication20.Migrations
{
    public partial class m12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HoursToDelete",
                table: "Message",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Message",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "HoursToDelete", table: "Message");
            migrationBuilder.DropColumn(name: "Password", table: "Message");
        }
    }
}
