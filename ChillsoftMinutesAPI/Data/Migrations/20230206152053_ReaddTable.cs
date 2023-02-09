using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChillsoftMinutesAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReaddTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetingItemStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingItemId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingItemStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingItemStatuses_MeetingItems_MeetingItemId",
                        column: x => x.MeetingItemId,
                        principalTable: "MeetingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItemStatuses_MeetingItemId",
                table: "MeetingItemStatuses",
                column: "MeetingItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingItemStatuses");
        }
    }
}
