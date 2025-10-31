using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class UserInboxes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_Inboxes_DmId1",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Inboxes_InboxId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_InboxId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InboxId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "DmId1",
                table: "PrivateMessages",
                newName: "InboxId1");

            migrationBuilder.RenameColumn(
                name: "DmId",
                table: "PrivateMessages",
                newName: "InboxId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Channels",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InboxUser",
                columns: table => new
                {
                    InboxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxUser", x => new { x.InboxesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_InboxUser_Inboxes_InboxesId",
                        column: x => x.InboxesId,
                        principalTable: "Inboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InboxUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Channels_UserId",
                table: "Channels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InboxUser_UsersId",
                table: "InboxUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Users_UserId",
                table: "Channels",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_Inboxes_InboxId1",
                table: "PrivateMessages",
                column: "InboxId1",
                principalTable: "Inboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Users_UserId",
                table: "Channels");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_Inboxes_InboxId1",
                table: "PrivateMessages");

            migrationBuilder.DropTable(
                name: "InboxUser");

            migrationBuilder.DropIndex(
                name: "IX_Channels_UserId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Channels");

            migrationBuilder.RenameColumn(
                name: "InboxId1",
                table: "PrivateMessages",
                newName: "DmId1");

            migrationBuilder.RenameColumn(
                name: "InboxId",
                table: "PrivateMessages",
                newName: "DmId");

            migrationBuilder.AddColumn<Guid>(
                name: "InboxId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("019a3686-7e19-75d0-bf65-96f0f919394e"),
                column: "InboxId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Users_InboxId",
                table: "Users",
                column: "InboxId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_Inboxes_DmId1",
                table: "PrivateMessages",
                column: "DmId1",
                principalTable: "Inboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Inboxes_InboxId",
                table: "Users",
                column: "InboxId",
                principalTable: "Inboxes",
                principalColumn: "Id");
        }
    }
}
