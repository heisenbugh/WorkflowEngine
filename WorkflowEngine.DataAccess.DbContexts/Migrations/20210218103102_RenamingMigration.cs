using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkflowEngine.DataAccess.DbContexts.Migrations
{
    public partial class RenamingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REQUEST_USER_REQUESTED_BY_ID",
                table: "REQUEST");

            migrationBuilder.DropIndex(
                name: "IX_REQUEST_REQUESTED_BY_ID",
                table: "REQUEST");

            migrationBuilder.DropColumn(
                name: "REQUESTED_BY_ID",
                table: "REQUEST");

            migrationBuilder.AddColumn<Guid>(
                name: "OWNER_ID",
                table: "REQUEST",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_OWNER_ID",
                table: "REQUEST",
                column: "OWNER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_REQUEST_USER_OWNER_ID",
                table: "REQUEST",
                column: "OWNER_ID",
                principalTable: "USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REQUEST_USER_OWNER_ID",
                table: "REQUEST");

            migrationBuilder.DropIndex(
                name: "IX_REQUEST_OWNER_ID",
                table: "REQUEST");

            migrationBuilder.DropColumn(
                name: "OWNER_ID",
                table: "REQUEST");

            migrationBuilder.AddColumn<Guid>(
                name: "REQUESTED_BY_ID",
                table: "REQUEST",
                type: "RAW(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_REQUESTED_BY_ID",
                table: "REQUEST",
                column: "REQUESTED_BY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_REQUEST_USER_REQUESTED_BY_ID",
                table: "REQUEST",
                column: "REQUESTED_BY_ID",
                principalTable: "USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
