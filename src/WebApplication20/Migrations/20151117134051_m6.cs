using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WebApplication20.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Message",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Text",
                table: "Message",
                nullable: false);
        }
    }
}
