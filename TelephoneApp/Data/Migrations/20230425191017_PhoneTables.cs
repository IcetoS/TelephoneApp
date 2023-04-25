using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelephoneApp.Data.Migrations
{
    public partial class PhoneTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelephoneApp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneApp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelephoneApp_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelephoneAppList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TelephoneNumber = table.Column<int>(type: "int", nullable: false),
                    LastCall = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelephoneAppId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneAppList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelephoneAppList_AspNetUsers_NameOfUserId",
                        column: x => x.NameOfUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TelephoneAppList_TelephoneApp_TelephoneAppId",
                        column: x => x.TelephoneAppId,
                        principalTable: "TelephoneApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneApp_UserId",
                table: "TelephoneApp",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneAppList_NameOfUserId",
                table: "TelephoneAppList",
                column: "NameOfUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneAppList_TelephoneAppId",
                table: "TelephoneAppList",
                column: "TelephoneAppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelephoneAppList");

            migrationBuilder.DropTable(
                name: "TelephoneApp");
        }
    }
}
