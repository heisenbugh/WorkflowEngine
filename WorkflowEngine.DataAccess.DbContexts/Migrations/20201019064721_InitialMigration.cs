using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkflowEngine.DataAccess.DbContexts.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROCESS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROCESS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FIRST_NAME = table.Column<string>(nullable: true),
                    LAST_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACTION",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    CODE_NAME = table.Column<string>(nullable: true),
                    PROCESS_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACTION_PROCESS_PROCESS_ID",
                        column: x => x.PROCESS_ID,
                        principalTable: "PROCESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "STATE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    CODE_NAME = table.Column<string>(nullable: true),
                    PROCESS_ID = table.Column<Guid>(nullable: true),
                    PARTIAL_VIEW_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STATE_PROCESS_PROCESS_ID",
                        column: x => x.PROCESS_ID,
                        principalTable: "PROCESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PROCESS_ADMIN",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PROCESS_ID = table.Column<Guid>(nullable: false),
                    ADMIN_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROCESS_ADMIN", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PROCESS_ADMIN_USER_ADMIN_ID",
                        column: x => x.ADMIN_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROCESS_ADMIN_PROCESS_PROCESS_ID",
                        column: x => x.PROCESS_ID,
                        principalTable: "PROCESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PATH",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FROM_STATE_ID = table.Column<Guid>(nullable: false),
                    ACTION_ID = table.Column<Guid>(nullable: false),
                    TO_STATE_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATH", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PATH_ACTION_ACTION_ID",
                        column: x => x.ACTION_ID,
                        principalTable: "ACTION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PATH_STATE_FROM_STATE_ID",
                        column: x => x.FROM_STATE_ID,
                        principalTable: "STATE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PATH_STATE_TO_STATE_ID",
                        column: x => x.TO_STATE_ID,
                        principalTable: "STATE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REQUEST",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TITLE = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    PROCESS_ID = table.Column<Guid>(nullable: true),
                    REQUEST_DATE = table.Column<DateTime>(nullable: false),
                    REQUESTED_BY_ID = table.Column<Guid>(nullable: false),
                    CURRENT_STATE_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUEST", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REQUEST_STATE_CURRENT_STATE_ID",
                        column: x => x.CURRENT_STATE_ID,
                        principalTable: "STATE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_REQUEST_PROCESS_PROCESS_ID",
                        column: x => x.PROCESS_ID,
                        principalTable: "PROCESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_REQUEST_USER_REQUESTED_BY_ID",
                        column: x => x.REQUESTED_BY_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STATE_USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    USER_ID = table.Column<Guid>(nullable: false),
                    STATE_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATE_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STATE_USER_STATE_STATE_ID",
                        column: x => x.STATE_ID,
                        principalTable: "STATE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STATE_USER_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PATH_USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    USER_ID = table.Column<Guid>(nullable: false),
                    PATH_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATH_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PATH_USER_PATH_PATH_ID",
                        column: x => x.PATH_ID,
                        principalTable: "PATH",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PATH_USER_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PROGRESS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    REQUEST_ID = table.Column<Guid>(nullable: false),
                    PATH_ID = table.Column<Guid>(nullable: true),
                    PROGRESSED_BY_ID = table.Column<Guid>(nullable: true),
                    PROGRESS_DATE = table.Column<DateTime>(nullable: false),
                    MESSAGE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROGRESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PROGRESS_PATH_PATH_ID",
                        column: x => x.PATH_ID,
                        principalTable: "PATH",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PROGRESS_USER_PROGRESSED_BY_ID",
                        column: x => x.PROGRESSED_BY_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PROGRESS_REQUEST_REQUEST_ID",
                        column: x => x.REQUEST_ID,
                        principalTable: "REQUEST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REQUEST_DATA",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    REQUEST_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUEST_DATA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REQUEST_DATA_REQUEST_REQUEST_ID",
                        column: x => x.REQUEST_ID,
                        principalTable: "REQUEST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACTION_PROCESS_ID",
                table: "ACTION",
                column: "PROCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PATH_ACTION_ID",
                table: "PATH",
                column: "ACTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PATH_FROM_STATE_ID",
                table: "PATH",
                column: "FROM_STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PATH_TO_STATE_ID",
                table: "PATH",
                column: "TO_STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PATH_USER_PATH_ID",
                table: "PATH_USER",
                column: "PATH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PATH_USER_USER_ID",
                table: "PATH_USER",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESS_ADMIN_ADMIN_ID",
                table: "PROCESS_ADMIN",
                column: "ADMIN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESS_ADMIN_PROCESS_ID",
                table: "PROCESS_ADMIN",
                column: "PROCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROGRESS_PATH_ID",
                table: "PROGRESS",
                column: "PATH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROGRESS_PROGRESSED_BY_ID",
                table: "PROGRESS",
                column: "PROGRESSED_BY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROGRESS_REQUEST_ID",
                table: "PROGRESS",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_CURRENT_STATE_ID",
                table: "REQUEST",
                column: "CURRENT_STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_PROCESS_ID",
                table: "REQUEST",
                column: "PROCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_REQUESTED_BY_ID",
                table: "REQUEST",
                column: "REQUESTED_BY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_DATA_REQUEST_ID",
                table: "REQUEST_DATA",
                column: "REQUEST_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_STATE_PROCESS_ID",
                table: "STATE",
                column: "PROCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STATE_USER_STATE_ID",
                table: "STATE_USER",
                column: "STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STATE_USER_USER_ID",
                table: "STATE_USER",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PATH_USER");

            migrationBuilder.DropTable(
                name: "PROCESS_ADMIN");

            migrationBuilder.DropTable(
                name: "PROGRESS");

            migrationBuilder.DropTable(
                name: "REQUEST_DATA");

            migrationBuilder.DropTable(
                name: "STATE_USER");

            migrationBuilder.DropTable(
                name: "PATH");

            migrationBuilder.DropTable(
                name: "REQUEST");

            migrationBuilder.DropTable(
                name: "ACTION");

            migrationBuilder.DropTable(
                name: "STATE");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "PROCESS");
        }
    }
}
