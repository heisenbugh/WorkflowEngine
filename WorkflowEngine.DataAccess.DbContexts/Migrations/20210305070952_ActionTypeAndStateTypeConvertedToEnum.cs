using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkflowEngine.DataAccess.DbContexts.Migrations
{
    public partial class ActionTypeAndStateTypeConvertedToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACTION_ACTION_TYPE_ACTION_TYPE_ID",
                table: "ACTION");

            migrationBuilder.DropForeignKey(
                name: "FK_STATE_STATE_TYPE_STATE_TYPE_ID",
                table: "STATE");

            migrationBuilder.DropTable(
                name: "ACTION_TYPE");

            migrationBuilder.DropTable(
                name: "STATE_TYPE");

            migrationBuilder.DropIndex(
                name: "IX_STATE_STATE_TYPE_ID",
                table: "STATE");

            migrationBuilder.DropIndex(
                name: "IX_ACTION_ACTION_TYPE_ID",
                table: "ACTION");

            migrationBuilder.DropColumn(
                name: "STATE_TYPE_ID",
                table: "STATE");

            migrationBuilder.DropColumn(
                name: "ACTION_TYPE_ID",
                table: "ACTION");

            migrationBuilder.AddColumn<string>(
                name: "STATE_TYPE",
                table: "STATE",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ACTION_TYPE",
                table: "ACTION",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STATE_TYPE",
                table: "STATE");

            migrationBuilder.DropColumn(
                name: "ACTION_TYPE",
                table: "ACTION");

            migrationBuilder.AddColumn<Guid>(
                name: "STATE_TYPE_ID",
                table: "STATE",
                type: "RAW(16)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ACTION_TYPE_ID",
                table: "ACTION",
                type: "RAW(16)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ACTION_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTION_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STATE_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATE_TYPE", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STATE_STATE_TYPE_ID",
                table: "STATE",
                column: "STATE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACTION_ACTION_TYPE_ID",
                table: "ACTION",
                column: "ACTION_TYPE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ACTION_ACTION_TYPE_ACTION_TYPE_ID",
                table: "ACTION",
                column: "ACTION_TYPE_ID",
                principalTable: "ACTION_TYPE",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_STATE_STATE_TYPE_STATE_TYPE_ID",
                table: "STATE",
                column: "STATE_TYPE_ID",
                principalTable: "STATE_TYPE",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
