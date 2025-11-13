using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class RemovePublicChannels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTimeouts_Channels_ChannelId",
                table: "UserTimeouts");

            migrationBuilder.DropTable(
                name: "ChannelPublicMessage");

            migrationBuilder.DropTable(
                name: "ChannelSettings");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_UserTimeouts_ChannelId",
                table: "UserTimeouts");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "UserTimeouts");

            migrationBuilder.AddColumn<int>(
                name: "MessageColorPrimary",
                table: "UserMessageDecorations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageColorSecondary",
                table: "UserMessageDecorations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Frames",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageColorPrimary",
                table: "UserMessageDecorations");

            migrationBuilder.DropColumn(
                name: "MessageColorSecondary",
                table: "UserMessageDecorations");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Frames");

            migrationBuilder.AddColumn<Guid>(
                name: "ChannelId",
                table: "UserTimeouts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Radius = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChannelPublicMessage",
                columns: table => new
                {
                    ChannelsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessagesId = table.Column<string>(type: "character varying(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelPublicMessage", x => new { x.ChannelsId, x.MessagesId });
                    table.ForeignKey(
                        name: "FK_ChannelPublicMessage_Channels_ChannelsId",
                        column: x => x.ChannelsId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelPublicMessage_PublicMessages_MessagesId",
                        column: x => x.MessagesId,
                        principalTable: "PublicMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChannelSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageArchiveThreshold = table.Column<int>(type: "integer", nullable: true),
                    MessageDuration = table.Column<long>(type: "bigint", nullable: false),
                    MessageHighlightThreshold = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelSettings_Channels_Id",
                        column: x => x.Id,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTimeouts_ChannelId",
                table: "UserTimeouts",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelPublicMessage_MessagesId",
                table: "ChannelPublicMessage",
                column: "MessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_Latitude_Longitude",
                table: "Channels",
                columns: new[] { "Latitude", "Longitude" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Channels_UserId",
                table: "Channels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTimeouts_Channels_ChannelId",
                table: "UserTimeouts",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
