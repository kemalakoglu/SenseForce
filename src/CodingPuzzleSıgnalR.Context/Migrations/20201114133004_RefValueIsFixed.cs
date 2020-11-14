using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingPuzzleSıgnalR.ApplicationContext.Migrations
{
    public partial class RefValueIsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Message",
                table: "RefValue");

            migrationBuilder.AlterColumn<string>(
                name: "TimeStamp",
                schema: "Message",
                table: "Message",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldRowVersion: true,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "Message",
                table: "RefValue",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "TimeStamp",
                schema: "Message",
                table: "Message",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
