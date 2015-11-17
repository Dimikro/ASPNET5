using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WebApplication20.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Message",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Link", table: "Message");
        }
    }
}
