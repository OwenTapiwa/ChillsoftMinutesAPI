using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChillsoftMinutesAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class MinutesEntitiesUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingTypeId = table.Column<int>(type: "int", nullable: true),
                    DateHeld = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinutesTakerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_AspNetUsers_MinutesTakerId",
                        column: x => x.MinutesTakerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meetings_MeetingType_MeetingTypeId",
                        column: x => x.MeetingTypeId,
                        principalTable: "MeetingType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeetingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    PersonResponsibleId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingItems_AspNetUsers_PersonResponsibleId",
                        column: x => x.PersonResponsibleId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingItems_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingItemStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingItemStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingItemStatuses_MeetingItems_Id",
                        column: x => x.Id,
                        principalTable: "MeetingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_MeetingId",
                table: "MeetingItems",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_PersonResponsibleId",
                table: "MeetingItems",
                column: "PersonResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MeetingTypeId",
                table: "Meetings",
                column: "MeetingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MinutesTakerId",
                table: "Meetings",
                column: "MinutesTakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingItemStatuses");

            migrationBuilder.DropTable(
                name: "MeetingItems");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "MeetingType");
        }
    }
}
