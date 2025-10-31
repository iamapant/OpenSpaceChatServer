using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class RelationTicketFont : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_Channels_DmId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_FontFamilies_MessageFontFamilyId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_FontStyles_MessageFontStyleId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_Inboxes_InboxId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_Landmarks_LandmarkId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_Users_UserId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_Channels_DmId",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_FontFamilies_MessageFontFamilyId",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_FontStyles_MessageFontStyleId",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_Inboxes_InboxId",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_Landmarks_LandmarkId",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_Users_UserId",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_FontFamilies_MessageFontFamilyId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_FontStyles_MessageFontStyleId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_Landmarks_LandmarkId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_Users_UserId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicMessages_FontFamilies_MessageFontFamilyId",
                table: "PublicMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicMessages_FontStyles_MessageFontStyleId",
                table: "PublicMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicMessages_Landmarks_LandmarkId",
                table: "PublicMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicMessages_Users_UserId",
                table: "PublicMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBlacklist_Users_BlacklistId",
                table: "UserBlacklist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBlacklist_Users_UserId",
                table: "UserBlacklist");

            migrationBuilder.DropTable(
                name: "ReportData");

            migrationBuilder.DropIndex(
                name: "IX_PublicMessages_LandmarkId",
                table: "PublicMessages");

            migrationBuilder.DropIndex(
                name: "IX_PublicMessages_MessageFontFamilyId",
                table: "PublicMessages");

            migrationBuilder.DropIndex(
                name: "IX_PublicMessages_MessageFontStyleId",
                table: "PublicMessages");

            migrationBuilder.DropIndex(
                name: "IX_PublicMessages_UserId",
                table: "PublicMessages");

            migrationBuilder.DropIndex(
                name: "IX_PublicArchives_LandmarkId",
                table: "PublicArchives");

            migrationBuilder.DropIndex(
                name: "IX_PublicArchives_LandmarkId_Created",
                table: "PublicArchives");

            migrationBuilder.DropIndex(
                name: "IX_PublicArchives_MessageFontFamilyId",
                table: "PublicArchives");

            migrationBuilder.DropIndex(
                name: "IX_PublicArchives_MessageFontStyleId",
                table: "PublicArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateMessages_DmId",
                table: "PrivateMessages");

            migrationBuilder.DropIndex(
                name: "IX_PrivateMessages_InboxId",
                table: "PrivateMessages");

            migrationBuilder.DropIndex(
                name: "IX_PrivateMessages_LandmarkId",
                table: "PrivateMessages");

            migrationBuilder.DropIndex(
                name: "IX_PrivateMessages_MessageFontFamilyId",
                table: "PrivateMessages");

            migrationBuilder.DropIndex(
                name: "IX_PrivateMessages_MessageFontStyleId",
                table: "PrivateMessages");

            migrationBuilder.DropIndex(
                name: "IX_PrivateMessages_UserId",
                table: "PrivateMessages");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_DmId",
                table: "PrivateArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_DmId_Created",
                table: "PrivateArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_InboxId",
                table: "PrivateArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_LandmarkId",
                table: "PrivateArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_MessageFontFamilyId",
                table: "PrivateArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_MessageFontStyleId",
                table: "PrivateArchives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBlacklist",
                table: "UserBlacklist");

            migrationBuilder.DropIndex(
                name: "IX_UserBlacklist_BlacklistId",
                table: "UserBlacklist");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "PublicMessages");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "PublicMessages");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "PublicMessages");

            migrationBuilder.DropColumn(
                name: "LandmarkId",
                table: "PublicMessages");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "PublicMessages");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "PublicMessages");

            migrationBuilder.DropColumn(
                name: "MessageFontFamilyId",
                table: "PublicMessages");

            migrationBuilder.DropColumn(
                name: "MessageFontStyleId",
                table: "PublicMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PublicMessages");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "FrameType",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "LandmarkId",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "MessageFontFamilyId",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "MessageFontStyleId",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "InboxId",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "IsPinned",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "LandmarkId",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "MessageFontFamilyId",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "DmId",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "FrameType",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "InboxId",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "IsPinned",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "LandmarkId",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "MessageFontFamilyId",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "MessageFontStyleId",
                table: "PrivateArchives");

            migrationBuilder.RenameTable(
                name: "UserBlacklist",
                newName: "Blacklists");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PublicArchives",
                newName: "FrameId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicArchives_UserId",
                table: "PublicArchives",
                newName: "IX_PublicArchives_FrameId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PrivateMessages",
                newName: "DmId1");

            migrationBuilder.RenameColumn(
                name: "MessageFontStyleId",
                table: "PrivateMessages",
                newName: "PinnedDmId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PrivateArchives",
                newName: "FrameId");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateArchives_UserId",
                table: "PrivateArchives",
                newName: "IX_PrivateArchives_FrameId");

            migrationBuilder.AddColumn<Guid>(
                name: "FontFamilyId",
                table: "UserInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FontStyleId",
                table: "UserInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MessageFrameId",
                table: "UserInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MessageFrameOptionsId",
                table: "UserInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "SupportTickets",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "DmId",
                table: "PrivateMessages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PinnedMessageId",
                table: "Inboxes",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "UserChatRangeInKm",
                table: "CuratorSettings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blacklists",
                table: "Blacklists",
                columns: new[] { "UserId", "BlacklistId" });

            migrationBuilder.CreateTable(
                name: "MessageFrames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageFrames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContentType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    LandmarkId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Landmarks_LandmarkId",
                        column: x => x.LandmarkId,
                        principalTable: "Landmarks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupportTicketData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Content = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    SupportTicketId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTicketData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTicketData_SupportTickets_SupportTicketId",
                        column: x => x.SupportTicketId,
                        principalTable: "SupportTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMessageDecorations",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FrameId = table.Column<Guid>(type: "uuid", nullable: true),
                    FrameOptionsId = table.Column<Guid>(type: "uuid", nullable: true),
                    NoteFontStyleId = table.Column<Guid>(type: "uuid", nullable: true),
                    NoteFontFamilyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessageDecorations", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserMessageDecorations_FontFamilies_NoteFontFamilyId",
                        column: x => x.NoteFontFamilyId,
                        principalTable: "FontFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMessageDecorations_FontStyles_NoteFontStyleId",
                        column: x => x.NoteFontStyleId,
                        principalTable: "FontStyles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMessageDecorations_MessageFrameOptions_FrameOptionsId",
                        column: x => x.FrameOptionsId,
                        principalTable: "MessageFrameOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMessageDecorations_MessageFrames_FrameId",
                        column: x => x.FrameId,
                        principalTable: "MessageFrames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMessageDecorations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CuratorSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserChatRangeInKm",
                value: 0.3f);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("019a3685-bab8-7dc4-ac85-8d0bb0d63218"), "Admin" },
                    { new Guid("019a3686-1b37-7087-9600-399694d0e4a1"), "Curator" },
                    { new Guid("019a3686-49f2-71d6-97bd-a2bb8e42da8e"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "InboxId", "IsActive", "LastLogin", "Name", "PasswordHash", "RefreshToken", "RoleId" },
                values: new object[] { new Guid("019a3686-7e19-75d0-bf65-96f0f919394e"), new DateTime(1, 1, 1, 1, 1, 1, 0, DateTimeKind.Utc), null, true, null, "Admin", "$argon2id$v=19$m=65536,t=3,p=1$eI12WvnpYPXzPf4AG5Bsfg$fZLnznwn3EsME9EM1MG/N5ktw61J8adMYcH8JY9+gUg", null, new Guid("019a3685-bab8-7dc4-ac85-8d0bb0d63218") });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "AvatarUrl", "Bio", "Country", "CoverUrl", "DisplayName", "DoB", "Email", "FirstName", "FontFamilyId", "FontStyleId", "LastName", "MessageFrameId", "MessageFrameOptionsId", "Phone", "Updated" },
                values: new object[] { new Guid("019a3686-7e19-75d0-bf65-96f0f919394e"), null, null, null, null, null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin123@gmail.com", "admin", null, null, null, null, null, null, new DateTime(1, 1, 1, 1, 1, 1, 0, DateTimeKind.Utc) });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_FontFamilyId",
                table: "UserInfos",
                column: "FontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_FontStyleId",
                table: "UserInfos",
                column: "FontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_MessageFrameId",
                table: "UserInfos",
                column: "MessageFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_MessageFrameOptionsId",
                table: "UserInfos",
                column: "MessageFrameOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReacts_MessageId",
                table: "MessageReacts",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Inboxes_PinnedMessageId",
                table: "Inboxes",
                column: "PinnedMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_LandmarkId",
                table: "Messages",
                column: "LandmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_LandmarkId_Created",
                table: "Messages",
                columns: new[] { "LandmarkId", "Created" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicketData_SupportTicketId",
                table: "SupportTicketData",
                column: "SupportTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessageDecorations_FrameId",
                table: "UserMessageDecorations",
                column: "FrameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessageDecorations_FrameOptionsId",
                table: "UserMessageDecorations",
                column: "FrameOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessageDecorations_NoteFontFamilyId",
                table: "UserMessageDecorations",
                column: "NoteFontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessageDecorations_NoteFontStyleId",
                table: "UserMessageDecorations",
                column: "NoteFontStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blacklists_Users_BlacklistId",
                table: "Blacklists",
                column: "BlacklistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blacklists_Users_UserId",
                table: "Blacklists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelPublicMessage_PublicMessages_MessagesId",
                table: "ChannelPublicMessage",
                column: "MessagesId",
                principalTable: "PublicMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inboxes_PrivateMessages_PinnedMessageId",
                table: "Inboxes",
                column: "PinnedMessageId",
                principalTable: "PrivateMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReacts_Messages_MessageId",
                table: "MessageReacts",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_MessageFrames_FrameId",
                table: "PrivateArchives",
                column: "FrameId",
                principalTable: "MessageFrames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_PrivateMessages_Id",
                table: "PrivateArchives",
                column: "Id",
                principalTable: "PrivateMessages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_Inboxes_DmId1",
                table: "PrivateMessages",
                column: "DmId1",
                principalTable: "Inboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_Messages_Id",
                table: "PrivateMessages",
                column: "Id",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_MessageFrames_FrameId",
                table: "PublicArchives",
                column: "FrameId",
                principalTable: "MessageFrames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_PublicMessages_Id",
                table: "PublicArchives",
                column: "Id",
                principalTable: "PublicMessages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicMessages_Messages_Id",
                table: "PublicMessages",
                column: "Id",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_FontFamilies_FontFamilyId",
                table: "UserInfos",
                column: "FontFamilyId",
                principalTable: "FontFamilies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_FontStyles_FontStyleId",
                table: "UserInfos",
                column: "FontStyleId",
                principalTable: "FontStyles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_MessageFrameOptions_MessageFrameOptionsId",
                table: "UserInfos",
                column: "MessageFrameOptionsId",
                principalTable: "MessageFrameOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_MessageFrames_MessageFrameId",
                table: "UserInfos",
                column: "MessageFrameId",
                principalTable: "MessageFrames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blacklists_Users_BlacklistId",
                table: "Blacklists");

            migrationBuilder.DropForeignKey(
                name: "FK_Blacklists_Users_UserId",
                table: "Blacklists");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelPublicMessage_PublicMessages_MessagesId",
                table: "ChannelPublicMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Inboxes_PrivateMessages_PinnedMessageId",
                table: "Inboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReacts_Messages_MessageId",
                table: "MessageReacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_MessageFrames_FrameId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_PrivateMessages_Id",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_Inboxes_DmId1",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_Messages_Id",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_MessageFrames_FrameId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_PublicMessages_Id",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicMessages_Messages_Id",
                table: "PublicMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_FontFamilies_FontFamilyId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_FontStyles_FontStyleId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_MessageFrameOptions_MessageFrameOptionsId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_MessageFrames_MessageFrameId",
                table: "UserInfos");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "SupportTicketData");

            migrationBuilder.DropTable(
                name: "UserMessageDecorations");

            migrationBuilder.DropTable(
                name: "MessageFrames");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_FontFamilyId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_FontStyleId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_MessageFrameId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_MessageFrameOptionsId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_MessageReacts_MessageId",
                table: "MessageReacts");

            migrationBuilder.DropIndex(
                name: "IX_Inboxes_PinnedMessageId",
                table: "Inboxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blacklists",
                table: "Blacklists");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("019a3686-1b37-7087-9600-399694d0e4a1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("019a3686-49f2-71d6-97bd-a2bb8e42da8e"));

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("019a3686-7e19-75d0-bf65-96f0f919394e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("019a3686-7e19-75d0-bf65-96f0f919394e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("019a3685-bab8-7dc4-ac85-8d0bb0d63218"));

            migrationBuilder.DropColumn(
                name: "FontFamilyId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "FontStyleId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "MessageFrameId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "MessageFrameOptionsId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "PinnedMessageId",
                table: "Inboxes");

            migrationBuilder.DropColumn(
                name: "UserChatRangeInKm",
                table: "CuratorSettings");

            migrationBuilder.RenameTable(
                name: "Blacklists",
                newName: "UserBlacklist");

            migrationBuilder.RenameColumn(
                name: "FrameId",
                table: "PublicArchives",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicArchives_FrameId",
                table: "PublicArchives",
                newName: "IX_PublicArchives_UserId");

            migrationBuilder.RenameColumn(
                name: "PinnedDmId",
                table: "PrivateMessages",
                newName: "MessageFontStyleId");

            migrationBuilder.RenameColumn(
                name: "DmId1",
                table: "PrivateMessages",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FrameId",
                table: "PrivateArchives",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateArchives_FrameId",
                table: "PrivateArchives",
                newName: "IX_PrivateArchives_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "SupportTickets",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "PublicMessages",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "PublicMessages",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "PublicMessages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LandmarkId",
                table: "PublicMessages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "PublicMessages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "PublicMessages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "MessageFontFamilyId",
                table: "PublicMessages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MessageFontStyleId",
                table: "PublicMessages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PublicMessages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "PublicArchives",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "PublicArchives",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "PublicArchives",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FrameType",
                table: "PublicArchives",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LandmarkId",
                table: "PublicArchives",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "PublicArchives",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "PublicArchives",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "MessageFontFamilyId",
                table: "PublicArchives",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MessageFontStyleId",
                table: "PublicArchives",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DmId",
                table: "PrivateMessages",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "PrivateMessages",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "PrivateMessages",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "PrivateMessages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "InboxId",
                table: "PrivateMessages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPinned",
                table: "PrivateMessages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LandmarkId",
                table: "PrivateMessages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "PrivateMessages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "PrivateMessages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "MessageFontFamilyId",
                table: "PrivateMessages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "PrivateArchives",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "PrivateArchives",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "PrivateArchives",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DmId",
                table: "PrivateArchives",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrameType",
                table: "PrivateArchives",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InboxId",
                table: "PrivateArchives",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPinned",
                table: "PrivateArchives",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LandmarkId",
                table: "PrivateArchives",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "PrivateArchives",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "PrivateArchives",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "MessageFontFamilyId",
                table: "PrivateArchives",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MessageFontStyleId",
                table: "PrivateArchives",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBlacklist",
                table: "UserBlacklist",
                columns: new[] { "UserId", "BlacklistId" });

            migrationBuilder.CreateTable(
                name: "ReportData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false),
                    DataType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportData_SupportTickets_ReportId",
                        column: x => x.ReportId,
                        principalTable: "SupportTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicMessages_LandmarkId",
                table: "PublicMessages",
                column: "LandmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicMessages_MessageFontFamilyId",
                table: "PublicMessages",
                column: "MessageFontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicMessages_MessageFontStyleId",
                table: "PublicMessages",
                column: "MessageFontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicMessages_UserId",
                table: "PublicMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_LandmarkId",
                table: "PublicArchives",
                column: "LandmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_LandmarkId_Created",
                table: "PublicArchives",
                columns: new[] { "LandmarkId", "Created" });

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_MessageFontFamilyId",
                table: "PublicArchives",
                column: "MessageFontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_MessageFontStyleId",
                table: "PublicArchives",
                column: "MessageFontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessages_DmId",
                table: "PrivateMessages",
                column: "DmId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessages_InboxId",
                table: "PrivateMessages",
                column: "InboxId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessages_LandmarkId",
                table: "PrivateMessages",
                column: "LandmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessages_MessageFontFamilyId",
                table: "PrivateMessages",
                column: "MessageFontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessages_MessageFontStyleId",
                table: "PrivateMessages",
                column: "MessageFontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessages_UserId",
                table: "PrivateMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_DmId",
                table: "PrivateArchives",
                column: "DmId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_DmId_Created",
                table: "PrivateArchives",
                columns: new[] { "DmId", "Created" });

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_InboxId",
                table: "PrivateArchives",
                column: "InboxId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_LandmarkId",
                table: "PrivateArchives",
                column: "LandmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_MessageFontFamilyId",
                table: "PrivateArchives",
                column: "MessageFontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_MessageFontStyleId",
                table: "PrivateArchives",
                column: "MessageFontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBlacklist_BlacklistId",
                table: "UserBlacklist",
                column: "BlacklistId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportData_ReportId",
                table: "ReportData",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_Channels_DmId",
                table: "PrivateArchives",
                column: "DmId",
                principalTable: "Channels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_FontFamilies_MessageFontFamilyId",
                table: "PrivateArchives",
                column: "MessageFontFamilyId",
                principalTable: "FontFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_FontStyles_MessageFontStyleId",
                table: "PrivateArchives",
                column: "MessageFontStyleId",
                principalTable: "FontStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_Inboxes_InboxId",
                table: "PrivateArchives",
                column: "InboxId",
                principalTable: "Inboxes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_Landmarks_LandmarkId",
                table: "PrivateArchives",
                column: "LandmarkId",
                principalTable: "Landmarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_Users_UserId",
                table: "PrivateArchives",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_Channels_DmId",
                table: "PrivateMessages",
                column: "DmId",
                principalTable: "Channels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_FontFamilies_MessageFontFamilyId",
                table: "PrivateMessages",
                column: "MessageFontFamilyId",
                principalTable: "FontFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_FontStyles_MessageFontStyleId",
                table: "PrivateMessages",
                column: "MessageFontStyleId",
                principalTable: "FontStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_Inboxes_InboxId",
                table: "PrivateMessages",
                column: "InboxId",
                principalTable: "Inboxes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_Landmarks_LandmarkId",
                table: "PrivateMessages",
                column: "LandmarkId",
                principalTable: "Landmarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_Users_UserId",
                table: "PrivateMessages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_FontFamilies_MessageFontFamilyId",
                table: "PublicArchives",
                column: "MessageFontFamilyId",
                principalTable: "FontFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_FontStyles_MessageFontStyleId",
                table: "PublicArchives",
                column: "MessageFontStyleId",
                principalTable: "FontStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_Landmarks_LandmarkId",
                table: "PublicArchives",
                column: "LandmarkId",
                principalTable: "Landmarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_Users_UserId",
                table: "PublicArchives",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicMessages_FontFamilies_MessageFontFamilyId",
                table: "PublicMessages",
                column: "MessageFontFamilyId",
                principalTable: "FontFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicMessages_FontStyles_MessageFontStyleId",
                table: "PublicMessages",
                column: "MessageFontStyleId",
                principalTable: "FontStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicMessages_Landmarks_LandmarkId",
                table: "PublicMessages",
                column: "LandmarkId",
                principalTable: "Landmarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicMessages_Users_UserId",
                table: "PublicMessages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBlacklist_Users_BlacklistId",
                table: "UserBlacklist",
                column: "BlacklistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBlacklist_Users_UserId",
                table: "UserBlacklist",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
