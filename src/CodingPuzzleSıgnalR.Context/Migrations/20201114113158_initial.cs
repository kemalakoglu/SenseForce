using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CodingPuzzleSıgnalR.ApplicationContext.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Message");

            migrationBuilder.CreateTable(
                name: "RefType",
                schema: "Message",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefType_RefType_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Message",
                        principalTable: "RefType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    TypeId = table.Column<long>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DataId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_RefType_DataId",
                        column: x => x.DataId,
                        principalSchema: "Message",
                        principalTable: "RefType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_RefType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Message",
                        principalTable: "RefType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefValue",
                schema: "Message",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    RefTypeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefValue_RefType_RefTypeId",
                        column: x => x.RefTypeId,
                        principalSchema: "Message",
                        principalTable: "RefType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_DataId",
                schema: "Message",
                table: "Message",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_TypeId",
                schema: "Message",
                table: "Message",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RefType_ParentId",
                schema: "Message",
                table: "RefType",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RefValue_RefTypeId",
                schema: "Message",
                table: "RefValue",
                column: "RefTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message",
                schema: "Message");

            migrationBuilder.DropTable(
                name: "RefValue",
                schema: "Message");

            migrationBuilder.DropTable(
                name: "RefType",
                schema: "Message");
        }
    }
}
