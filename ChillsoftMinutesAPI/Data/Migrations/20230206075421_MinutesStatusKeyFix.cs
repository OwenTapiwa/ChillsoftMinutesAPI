using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChillsoftMinutesAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class MinutesStatusKeyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingItemStatuses_MeetingItems_Id",
                table: "MeetingItemStatuses");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "MeetingItemStatuses",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MeetingItemId",
                table: "MeetingItemStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItemStatuses_MeetingItemId",
                table: "MeetingItemStatuses",
                column: "MeetingItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingItemStatuses_MeetingItems_MeetingItemId",
                table: "MeetingItemStatuses",
                column: "MeetingItemId",
                principalTable: "MeetingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingItemStatuses_MeetingItems_MeetingItemId",
                table: "MeetingItemStatuses");

            migrationBuilder.DropIndex(
                name: "IX_MeetingItemStatuses_MeetingItemId",
                table: "MeetingItemStatuses");

            migrationBuilder.DropColumn(
                name: "MeetingItemId",
                table: "MeetingItemStatuses");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "MeetingItemStatuses",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingItemStatuses_MeetingItems_Id",
                table: "MeetingItemStatuses",
                column: "Id",
                principalTable: "MeetingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
