using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingService.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scenario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VonageRole = table.Column<int>(type: "int", nullable: false),
                    Permissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScenarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tenant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantRole_Scenario_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScenarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tenant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Scenario_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tenant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_ParticipantRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ParticipantRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Participant_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tenant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Message_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_ParticipantId",
                table: "Message",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_RoomId",
                table: "Message",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_RoleId",
                table: "Participant",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_RoomId",
                table: "Participant",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantRole_ScenarioId",
                table: "ParticipantRole",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_ScenarioId",
                table: "Room",
                column: "ScenarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "ParticipantRole");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Scenario");
        }
    }
}
