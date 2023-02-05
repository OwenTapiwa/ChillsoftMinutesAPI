using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChillsoftMinutesAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class MinutesContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_MeetingType_MeetingTypeId",
                table: "Meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingType",
                table: "MeetingType");

            migrationBuilder.RenameTable(
                name: "MeetingType",
                newName: "MeetingTypes");

            migrationBuilder.AddColumn<string>(
                name: "PreFix",
                table: "MeetingTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingTypes",
                table: "MeetingTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_MeetingTypes_MeetingTypeId",
                table: "Meetings",
                column: "MeetingTypeId",
                principalTable: "MeetingTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_MeetingTypes_MeetingTypeId",
                table: "Meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingTypes",
                table: "MeetingTypes");

            migrationBuilder.DropColumn(
                name: "PreFix",
                table: "MeetingTypes");

            migrationBuilder.RenameTable(
                name: "MeetingTypes",
                newName: "MeetingType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingType",
                table: "MeetingType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_MeetingType_MeetingTypeId",
                table: "Meetings",
                column: "MeetingTypeId",
                principalTable: "MeetingType",
                principalColumn: "Id");
        }
    }
}
