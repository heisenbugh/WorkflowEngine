using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkflowEngine.DataAccess.DbContexts.Migrations
{
    public partial class InitialNpgsql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notification_content_template",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification_content_template", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "process",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_process", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "email_notification_template",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: true),
                    to_addresses = table.Column<string>(type: "text", nullable: true),
                    cc_addresses = table.Column<string>(type: "text", nullable: true),
                    bcc_addresses = table.Column<string>(type: "text", nullable: true),
                    content_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_notification_template", x => x.id);
                    table.ForeignKey(
                        name: "FK_email_notification_template_notification_content_template_c~",
                        column: x => x.content_id,
                        principalTable: "notification_content_template",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sms_notification_template",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    header = table.Column<string>(type: "text", nullable: true),
                    gsm_numbers = table.Column<string>(type: "text", nullable: true),
                    content_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_notification_template", x => x.id);
                    table.ForeignKey(
                        name: "FK_sms_notification_template_notification_content_template_con~",
                        column: x => x.content_id,
                        principalTable: "notification_content_template",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "action",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    code_name = table.Column<string>(type: "text", nullable: true),
                    process_id = table.Column<Guid>(type: "uuid", nullable: true),
                    action_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_action", x => x.id);
                    table.ForeignKey(
                        name: "FK_action_process_process_id",
                        column: x => x.process_id,
                        principalTable: "process",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    code_name = table.Column<string>(type: "text", nullable: true),
                    process_id = table.Column<Guid>(type: "uuid", nullable: true),
                    partial_view_name = table.Column<string>(type: "text", nullable: true),
                    state_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.id);
                    table.ForeignKey(
                        name: "FK_state_process_process_id",
                        column: x => x.process_id,
                        principalTable: "process",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "process_admin",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    process_id = table.Column<Guid>(type: "uuid", nullable: false),
                    admin_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_process_admin", x => x.id);
                    table.ForeignKey(
                        name: "FK_process_admin_process_process_id",
                        column: x => x.process_id,
                        principalTable: "process",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_process_admin_user_admin_id",
                        column: x => x.admin_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "path",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    from_state_id = table.Column<Guid>(type: "uuid", nullable: false),
                    action_id = table.Column<Guid>(type: "uuid", nullable: false),
                    to_state_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_path", x => x.id);
                    table.ForeignKey(
                        name: "FK_path_action_action_id",
                        column: x => x.action_id,
                        principalTable: "action",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_path_state_from_state_id",
                        column: x => x.from_state_id,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_path_state_to_state_id",
                        column: x => x.to_state_id,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "request",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    process_id = table.Column<Guid>(type: "uuid", nullable: true),
                    request_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    current_state_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request", x => x.id);
                    table.ForeignKey(
                        name: "FK_request_process_process_id",
                        column: x => x.process_id,
                        principalTable: "process",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_request_state_current_state_id",
                        column: x => x.current_state_id,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_request_user_owner_id",
                        column: x => x.owner_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "state_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    state_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_state_user_state_state_id",
                        column: x => x.state_id,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_state_user_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "path_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    path_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_path_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_path_user_path_path_id",
                        column: x => x.path_id,
                        principalTable: "path",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_path_user_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "progress",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    path_id = table.Column<Guid>(type: "uuid", nullable: true),
                    progressed_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    progress_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    message = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_progress", x => x.id);
                    table.ForeignKey(
                        name: "FK_progress_path_path_id",
                        column: x => x.path_id,
                        principalTable: "path",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_progress_request_request_id",
                        column: x => x.request_id,
                        principalTable: "request",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_progress_user_progressed_by_id",
                        column: x => x.progressed_by_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "request_data",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    request_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request_data", x => x.id);
                    table.ForeignKey(
                        name: "FK_request_data_request_request_id",
                        column: x => x.request_id,
                        principalTable: "request",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_action_process_id",
                table: "action",
                column: "process_id");

            migrationBuilder.CreateIndex(
                name: "IX_email_notification_template_content_id",
                table: "email_notification_template",
                column: "content_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_path_action_id",
                table: "path",
                column: "action_id");

            migrationBuilder.CreateIndex(
                name: "IX_path_from_state_id",
                table: "path",
                column: "from_state_id");

            migrationBuilder.CreateIndex(
                name: "IX_path_to_state_id",
                table: "path",
                column: "to_state_id");

            migrationBuilder.CreateIndex(
                name: "IX_path_user_path_id",
                table: "path_user",
                column: "path_id");

            migrationBuilder.CreateIndex(
                name: "IX_path_user_user_id",
                table: "path_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_process_admin_admin_id",
                table: "process_admin",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_process_admin_process_id",
                table: "process_admin",
                column: "process_id");

            migrationBuilder.CreateIndex(
                name: "IX_progress_path_id",
                table: "progress",
                column: "path_id");

            migrationBuilder.CreateIndex(
                name: "IX_progress_progressed_by_id",
                table: "progress",
                column: "progressed_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_progress_request_id",
                table: "progress",
                column: "request_id");

            migrationBuilder.CreateIndex(
                name: "IX_request_current_state_id",
                table: "request",
                column: "current_state_id");

            migrationBuilder.CreateIndex(
                name: "IX_request_owner_id",
                table: "request",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_request_process_id",
                table: "request",
                column: "process_id");

            migrationBuilder.CreateIndex(
                name: "IX_request_data_request_id",
                table: "request_data",
                column: "request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sms_notification_template_content_id",
                table: "sms_notification_template",
                column: "content_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_state_process_id",
                table: "state",
                column: "process_id");

            migrationBuilder.CreateIndex(
                name: "IX_state_user_state_id",
                table: "state_user",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_state_user_user_id",
                table: "state_user",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "email_notification_template");

            migrationBuilder.DropTable(
                name: "path_user");

            migrationBuilder.DropTable(
                name: "process_admin");

            migrationBuilder.DropTable(
                name: "progress");

            migrationBuilder.DropTable(
                name: "request_data");

            migrationBuilder.DropTable(
                name: "sms_notification_template");

            migrationBuilder.DropTable(
                name: "state_user");

            migrationBuilder.DropTable(
                name: "path");

            migrationBuilder.DropTable(
                name: "request");

            migrationBuilder.DropTable(
                name: "notification_content_template");

            migrationBuilder.DropTable(
                name: "action");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "process");
        }
    }
}
