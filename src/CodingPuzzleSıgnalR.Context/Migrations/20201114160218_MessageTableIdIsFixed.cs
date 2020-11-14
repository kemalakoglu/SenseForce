using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingPuzzleSıgnalR.ApplicationContext.Migrations
{
    public partial class MessageTableIdIsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Message",
                table: "Message",
                nullable: false,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "Message",
                table: "Message",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
