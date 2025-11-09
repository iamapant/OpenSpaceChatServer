using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class NormalizeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_MessageFrameOptions_FrameOptionsId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_MessageFrames_FrameId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_MessageFrameOptions_FrameOptionsId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_MessageFrames_FrameId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_MessageFrameOptions_MessageFrameOptionsId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_MessageFrames_MessageFrameId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessageDecorations_MessageFrameOptions_FrameOptionsId",
                table: "UserMessageDecorations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessageDecorations_MessageFrames_FrameId",
                table: "UserMessageDecorations");

            migrationBuilder.DropTable(
                name: "MessageFrameOptions");

            migrationBuilder.DropTable(
                name: "MessageFrames");

            migrationBuilder.DropTable(
                name: "MessageReacts");

            migrationBuilder.DropTable(
                name: "MessageStickerStylePrivateArchive");

            migrationBuilder.DropTable(
                name: "MessageStickerStylePublicArchive");

            migrationBuilder.DropTable(
                name: "MessageStickerStyles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTimeouts",
                table: "UserTimeouts");

            migrationBuilder.DropIndex(
                name: "IX_UserTimeouts_UserId",
                table: "UserTimeouts");

            migrationBuilder.RenameColumn(
                name: "MessageFrameOptionsId",
                table: "UserInfos",
                newName: "FrameOptionsId");

            migrationBuilder.RenameColumn(
                name: "MessageFrameId",
                table: "UserInfos",
                newName: "FrameId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfos_MessageFrameOptionsId",
                table: "UserInfos",
                newName: "IX_UserInfos_FrameOptionsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfos_MessageFrameId",
                table: "UserInfos",
                newName: "IX_UserInfos_FrameId");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "SupportTickets",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultFontFamilyId",
                table: "CuratorSettings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "DefaultFontSizeInPx",
                table: "CuratorSettings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "DefaultFontStyle",
                table: "CuratorSettings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DefaultFontStyleId",
                table: "CuratorSettings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DefaultFontWeight",
                table: "CuratorSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DefaultFrameId",
                table: "CuratorSettings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DefaultFrameOptionsId",
                table: "CuratorSettings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "DefaultLetterSpacing",
                table: "CuratorSettings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DefaultLineSpacing",
                table: "CuratorSettings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "DefaultTextDecoration",
                table: "CuratorSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultTextTransform",
                table: "CuratorSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTimeouts",
                table: "UserTimeouts",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "AdminSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SettingsRefreshIntervalInHour = table.Column<float>(type: "real", nullable: false),
                    AllowsLoginThroughEmail = table.Column<bool>(type: "boolean", nullable: false),
                    UsernameMaxLength = table.Column<int>(type: "integer", nullable: false),
                    UsernameMinLength = table.Column<int>(type: "integer", nullable: false),
                    UsernameExcludedCharacters = table.Column<string>(type: "text", nullable: false),
                    ExcludedWordsSeparator = table.Column<char>(type: "character(1)", nullable: false),
                    UsernameExcludedWords = table.Column<string>(type: "text", nullable: false),
                    PasswordMaxLength = table.Column<int>(type: "integer", nullable: false),
                    PasswordMinLength = table.Column<int>(type: "integer", nullable: false),
                    PasswordExcludedCharacters = table.Column<string>(type: "text", nullable: false),
                    PasswordContainsNumber = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordContainsSpecial = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordContainsUpper = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordContainsLower = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordDefaultLength = table.Column<int>(type: "integer", nullable: false),
                    PasswordAllowedSpecials = table.Column<string>(type: "text", nullable: false),
                    PasswordExcludedWords = table.Column<string>(type: "text", nullable: false),
                    CreateAccountTokenExpireInMinute = table.Column<float>(type: "real", nullable: true),
                    RefreshTokenTimeoutInHour = table.Column<float>(type: "real", nullable: false),
                    RefreshTokenLength = table.Column<int>(type: "integer", nullable: false),
                    RefreshTokenSeparator = table.Column<char>(type: "character(1)", nullable: false),
                    RefreshTokenCharacters = table.Column<string>(type: "text", nullable: false),
                    SoftDeleteRetentionInHours = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrameOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorPrimary = table.Column<int>(type: "integer", nullable: false),
                    ColorSecondary = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReactionType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => new { x.MessageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Reactions_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StickerStyles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionX = table.Column<double>(type: "double precision", nullable: false),
                    PositionY = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Rotation = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StickerStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StickerUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StickerUrls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArchiveSticker",
                columns: table => new
                {
                    ArchiveId = table.Column<string>(type: "character varying(100)", nullable: false),
                    StickerUrlId = table.Column<Guid>(type: "uuid", nullable: false),
                    StickerStyleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PrivateArchiveId = table.Column<string>(type: "character varying(100)", nullable: true),
                    PublicArchiveId = table.Column<string>(type: "character varying(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveSticker", x => new { x.ArchiveId, x.StickerUrlId, x.StickerStyleId });
                    table.ForeignKey(
                        name: "FK_ArchiveSticker_Messages_ArchiveId",
                        column: x => x.ArchiveId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchiveSticker_PrivateArchives_PrivateArchiveId",
                        column: x => x.PrivateArchiveId,
                        principalTable: "PrivateArchives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArchiveSticker_PublicArchives_PublicArchiveId",
                        column: x => x.PublicArchiveId,
                        principalTable: "PublicArchives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArchiveSticker_StickerStyles_StickerStyleId",
                        column: x => x.StickerStyleId,
                        principalTable: "StickerStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchiveSticker_StickerUrls_StickerUrlId",
                        column: x => x.StickerUrlId,
                        principalTable: "StickerUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdminSettings",
                columns: new[] { "Id", "AllowsLoginThroughEmail", "CreateAccountTokenExpireInMinute", "ExcludedWordsSeparator", "PasswordAllowedSpecials", "PasswordContainsLower", "PasswordContainsNumber", "PasswordContainsSpecial", "PasswordContainsUpper", "PasswordDefaultLength", "PasswordExcludedCharacters", "PasswordExcludedWords", "PasswordMaxLength", "PasswordMinLength", "RefreshTokenCharacters", "RefreshTokenLength", "RefreshTokenSeparator", "RefreshTokenTimeoutInHour", "SettingsRefreshIntervalInHour", "SoftDeleteRetentionInHours", "UsernameExcludedCharacters", "UsernameExcludedWords", "UsernameMaxLength", "UsernameMinLength" },
                values: new object[] { 1, true, 30f, '#', "!\"#$%&'()*+,-./:;<=>?@[\\]^`{|}~", true, true, true, true, 8, "	\n\r", "", 30, 8, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^`{|}~", 10, '_', 2f, 1f, 1440f, "!\"#$%&'()*+,/:;<=>?@[\\]^`{|}~", "", 25, 5 });

            migrationBuilder.UpdateData(
                table: "CuratorSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DefaultFontFamilyId", "DefaultFontSizeInPx", "DefaultFontStyle", "DefaultFontStyleId", "DefaultFontWeight", "DefaultFrameId", "DefaultFrameOptionsId", "DefaultLetterSpacing", "DefaultLineSpacing", "DefaultTextDecoration", "DefaultTextTransform" },
                values: new object[] { "019a62f7-4772-7b75-bf90-a279409799de", 16f, "Arial", "019a62f8-b759-7fef-b336-101f7a31d111", 400, "019a36b6-44a9-7484-9d3a-91c305018ac8", "019a62f1-51a2-71c7-94ce-78748709c6f4", 0f, 1.6f, "", "" });

            migrationBuilder.InsertData(
                table: "FontFamilies",
                columns: new[] { "Id", "Family" },
                values: new object[] { new Guid("019a62f7-4772-7b75-bf90-a279409799de"), "Arial" });

            migrationBuilder.InsertData(
                table: "FontStyles",
                columns: new[] { "Id", "SizeInPx", "Style", "TextDecoration", "TextTransform", "Weight" },
                values: new object[] { new Guid("019a62f8-b759-7fef-b336-101f7a31d111"), 14f, null, null, null, 400 });

            migrationBuilder.InsertData(
                table: "FrameOptions",
                columns: new[] { "Id", "ColorPrimary", "ColorSecondary" },
                values: new object[] { new Guid("019a62f1-51a2-71c7-94ce-78748709c6f4"), -1, -14774017 });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_Email",
                table: "UserInfos",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_Phone",
                table: "UserInfos",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Channels_Latitude_Longitude",
                table: "Channels",
                columns: new[] { "Latitude", "Longitude" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveSticker_ArchiveId",
                table: "ArchiveSticker",
                column: "ArchiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveSticker_PrivateArchiveId",
                table: "ArchiveSticker",
                column: "PrivateArchiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveSticker_PublicArchiveId",
                table: "ArchiveSticker",
                column: "PublicArchiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveSticker_StickerStyleId",
                table: "ArchiveSticker",
                column: "StickerStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveSticker_StickerUrlId",
                table: "ArchiveSticker",
                column: "StickerUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_MessageId",
                table: "Reactions",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_UserId",
                table: "Reactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StickerUrls_Url",
                table: "StickerUrls",
                column: "Url",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_FrameOptions_FrameOptionsId",
                table: "PrivateArchives",
                column: "FrameOptionsId",
                principalTable: "FrameOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_Frames_FrameId",
                table: "PrivateArchives",
                column: "FrameId",
                principalTable: "Frames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_FrameOptions_FrameOptionsId",
                table: "PublicArchives",
                column: "FrameOptionsId",
                principalTable: "FrameOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_Frames_FrameId",
                table: "PublicArchives",
                column: "FrameId",
                principalTable: "Frames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_FrameOptions_FrameOptionsId",
                table: "UserInfos",
                column: "FrameOptionsId",
                principalTable: "FrameOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Frames_FrameId",
                table: "UserInfos",
                column: "FrameId",
                principalTable: "Frames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessageDecorations_FrameOptions_FrameOptionsId",
                table: "UserMessageDecorations",
                column: "FrameOptionsId",
                principalTable: "FrameOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessageDecorations_Frames_FrameId",
                table: "UserMessageDecorations",
                column: "FrameId",
                principalTable: "Frames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_FrameOptions_FrameOptionsId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_Frames_FrameId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_FrameOptions_FrameOptionsId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_Frames_FrameId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_FrameOptions_FrameOptionsId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Frames_FrameId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessageDecorations_FrameOptions_FrameOptionsId",
                table: "UserMessageDecorations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessageDecorations_Frames_FrameId",
                table: "UserMessageDecorations");

            migrationBuilder.DropTable(
                name: "AdminSettings");

            migrationBuilder.DropTable(
                name: "ArchiveSticker");

            migrationBuilder.DropTable(
                name: "FrameOptions");

            migrationBuilder.DropTable(
                name: "Frames");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "StickerStyles");

            migrationBuilder.DropTable(
                name: "StickerUrls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTimeouts",
                table: "UserTimeouts");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_Email",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_Phone",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_Channels_Latitude_Longitude",
                table: "Channels");

            migrationBuilder.DeleteData(
                table: "FontFamilies",
                keyColumn: "Id",
                keyValue: new Guid("019a62f7-4772-7b75-bf90-a279409799de"));

            migrationBuilder.DeleteData(
                table: "FontStyles",
                keyColumn: "Id",
                keyValue: new Guid("019a62f8-b759-7fef-b336-101f7a31d111"));

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "SupportTickets");

            migrationBuilder.DropColumn(
                name: "DefaultFontFamilyId",
                table: "CuratorSettings");

            migrationBuilder.DropColumn(
                name: "DefaultFontSizeInPx",
                table: "CuratorSettings");

            migrationBuilder.DropColumn(
                name: "DefaultFontStyle",
                table: "CuratorSettings");

            migrationBuilder.DropColumn(
                name: "DefaultFontStyleId",
                table: "CuratorSettings");

            migrationBuilder.DropColumn(
                name: "DefaultFontWeight",
                table: "CuratorSettings");

            migrationBuilder.DropColumn(
                name: "DefaultFrameId",
                table: "CuratorSettings");

            migrationBuilder.DropColumn(
                name: "DefaultFrameOptionsId",
                table: "CuratorSettings");

            migrationBuilder.DropColumn(
                name: "DefaultLetterSpacing",
                table: "CuratorSettings");

            migrationBuilder.DropColumn(
                name: "DefaultLineSpacing",
                table: "CuratorSettings");

            migrationBuilder.DropColumn(
                name: "DefaultTextDecoration",
                table: "CuratorSettings");

            migrationBuilder.DropColumn(
                name: "DefaultTextTransform",
                table: "CuratorSettings");

            migrationBuilder.RenameColumn(
                name: "FrameOptionsId",
                table: "UserInfos",
                newName: "MessageFrameOptionsId");

            migrationBuilder.RenameColumn(
                name: "FrameId",
                table: "UserInfos",
                newName: "MessageFrameId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfos_FrameOptionsId",
                table: "UserInfos",
                newName: "IX_UserInfos_MessageFrameOptionsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfos_FrameId",
                table: "UserInfos",
                newName: "IX_UserInfos_MessageFrameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTimeouts",
                table: "UserTimeouts",
                columns: new[] { "UserId", "ChannelId" });

            migrationBuilder.CreateTable(
                name: "MessageFrameOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorPrimary = table.Column<int>(type: "integer", nullable: false),
                    ColorSecondary = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageFrameOptions", x => x.Id);
                });

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
                name: "MessageReacts",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reaction = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReacts", x => new { x.MessageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MessageReacts_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageReacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageStickerStyles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionX = table.Column<double>(type: "double precision", nullable: false),
                    PositionY = table.Column<double>(type: "double precision", nullable: false),
                    Rotation = table.Column<float>(type: "real", nullable: false),
                    SizeX = table.Column<double>(type: "double precision", nullable: false),
                    SizeY = table.Column<double>(type: "double precision", nullable: false),
                    StickerUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStickerStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageStickerStylePrivateArchive",
                columns: table => new
                {
                    PrivateArchivesId = table.Column<string>(type: "character varying(100)", nullable: false),
                    StickersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStickerStylePrivateArchive", x => new { x.PrivateArchivesId, x.StickersId });
                    table.ForeignKey(
                        name: "FK_MessageStickerStylePrivateArchive_MessageStickerStyles_Stic~",
                        column: x => x.StickersId,
                        principalTable: "MessageStickerStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageStickerStylePrivateArchive_PrivateArchives_PrivateAr~",
                        column: x => x.PrivateArchivesId,
                        principalTable: "PrivateArchives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageStickerStylePublicArchive",
                columns: table => new
                {
                    PublicArchivesId = table.Column<string>(type: "character varying(100)", nullable: false),
                    StickersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStickerStylePublicArchive", x => new { x.PublicArchivesId, x.StickersId });
                    table.ForeignKey(
                        name: "FK_MessageStickerStylePublicArchive_MessageStickerStyles_Stick~",
                        column: x => x.StickersId,
                        principalTable: "MessageStickerStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageStickerStylePublicArchive_PublicArchives_PublicArchi~",
                        column: x => x.PublicArchivesId,
                        principalTable: "PublicArchives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTimeouts_UserId",
                table: "UserTimeouts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageReacts_MessageId",
                table: "MessageReacts",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReacts_UserId",
                table: "MessageReacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageStickerStylePrivateArchive_StickersId",
                table: "MessageStickerStylePrivateArchive",
                column: "StickersId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageStickerStylePublicArchive_StickersId",
                table: "MessageStickerStylePublicArchive",
                column: "StickersId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_MessageFrameOptions_FrameOptionsId",
                table: "PrivateArchives",
                column: "FrameOptionsId",
                principalTable: "MessageFrameOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_MessageFrames_FrameId",
                table: "PrivateArchives",
                column: "FrameId",
                principalTable: "MessageFrames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_MessageFrameOptions_FrameOptionsId",
                table: "PublicArchives",
                column: "FrameOptionsId",
                principalTable: "MessageFrameOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_MessageFrames_FrameId",
                table: "PublicArchives",
                column: "FrameId",
                principalTable: "MessageFrames",
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

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessageDecorations_MessageFrameOptions_FrameOptionsId",
                table: "UserMessageDecorations",
                column: "FrameOptionsId",
                principalTable: "MessageFrameOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessageDecorations_MessageFrames_FrameId",
                table: "UserMessageDecorations",
                column: "FrameId",
                principalTable: "MessageFrames",
                principalColumn: "Id");
        }
    }
}
