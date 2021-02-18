using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkflowEngine.DataAccess.DbContexts.Migrations
{
    public partial class NotificationTemplatelerAyrildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTIFICATION_TEMPLATE");

            migrationBuilder.CreateTable(
                name: "NOTIFICATION_CONTENT_TEMPLATE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CONTENT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION_CONTENT_TEMPLATE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EMAIL_NOTIFICATION_TEMPLATE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    SUBJECT = table.Column<string>(nullable: true),
                    TO_ADDRESSES = table.Column<string>(nullable: true),
                    CC_ADDRESSES = table.Column<string>(nullable: true),
                    BCC_ADDRESSES = table.Column<string>(nullable: true),
                    CONTENT_ID = table.Column<Guid>(nullable: false),
                    IS_ACTIVE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMAIL_NOTIFICATION_TEMPLATE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMAIL_NOTIFICATION_TEMPLATE_NOTIFICATION_CONTENT_TEMPLATE_CONTENT_ID",
                        column: x => x.CONTENT_ID,
                        principalTable: "NOTIFICATION_CONTENT_TEMPLATE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMS_NOTIFICATION_TEMPLATE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    HEADER = table.Column<string>(nullable: true),
                    GSM_NUMBERS = table.Column<string>(nullable: true),
                    CONTENT_ID = table.Column<Guid>(nullable: false),
                    IS_ACTIVE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMS_NOTIFICATION_TEMPLATE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SMS_NOTIFICATION_TEMPLATE_NOTIFICATION_CONTENT_TEMPLATE_CONTENT_ID",
                        column: x => x.CONTENT_ID,
                        principalTable: "NOTIFICATION_CONTENT_TEMPLATE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMAIL_NOTIFICATION_TEMPLATE_CONTENT_ID",
                table: "EMAIL_NOTIFICATION_TEMPLATE",
                column: "CONTENT_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SMS_NOTIFICATION_TEMPLATE_CONTENT_ID",
                table: "SMS_NOTIFICATION_TEMPLATE",
                column: "CONTENT_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMAIL_NOTIFICATION_TEMPLATE");

            migrationBuilder.DropTable(
                name: "SMS_NOTIFICATION_TEMPLATE");

            migrationBuilder.DropTable(
                name: "NOTIFICATION_CONTENT_TEMPLATE");

            migrationBuilder.CreateTable(
                name: "NOTIFICATION_TEMPLATE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    BCC_ADDRESSES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CC_ADDRESSES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CONTENT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    GSM_NUMBERS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SMS_HEADER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SUBJECT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TO_ADDRESSES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION_TEMPLATE", x => x.ID);
                });
        }
    }
}
