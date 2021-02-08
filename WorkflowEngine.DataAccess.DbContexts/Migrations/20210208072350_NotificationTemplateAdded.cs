using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkflowEngine.DataAccess.DbContexts.Migrations
{
    public partial class NotificationTemplateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NOTIFICATION_TEMPLATE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    SUBJECT = table.Column<string>(nullable: true),
                    CONTENT = table.Column<string>(nullable: true),
                    SMS_HEADER = table.Column<string>(nullable: true),
                    TO_ADDRESSES = table.Column<string>(nullable: true),
                    CC_ADDRESSES = table.Column<string>(nullable: true),
                    BCC_ADDRESSES = table.Column<string>(nullable: true),
                    GSM_NUMBERS = table.Column<string>(nullable: true),
                    IS_ACTIVE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION_TEMPLATE", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTIFICATION_TEMPLATE");
        }
    }
}
