using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Radius = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuratorSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DefaultMessageDurationInHour = table.Column<float>(type: "real", nullable: false),
                    DefaultMessageHighlightThreshold = table.Column<int>(type: "integer", nullable: false),
                    DefaultMessageArchiveThreshold = table.Column<int>(type: "integer", nullable: false),
                    DefaultChannelRadiusInKm = table.Column<double>(type: "double precision", nullable: false),
                    LandmarkTaggableRangeInKm = table.Column<float>(type: "real", nullable: false),
                    PrivateMessagePublishDeadlineInHour = table.Column<float>(type: "real", nullable: false),
                    PublicMessageFrequencyPerInterval = table.Column<float>(type: "real", nullable: false),
                    PublicMessageFrequencyIntervalInSecond = table.Column<int>(type: "integer", nullable: false),
                    DefaultTimeoutPeriodInMinute = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuratorSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FontFamilies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Family = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FontFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FontStyles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false, defaultValue: 400),
                    Style = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    SizeInPx = table.Column<float>(type: "real", nullable: false, defaultValue: 14f),
                    LetterSpacing = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    LineSpacing = table.Column<float>(type: "real", nullable: false, defaultValue: 1.2f),
                    TextDecoration = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TextTransform = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FontStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inboxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inboxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Landmarks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IconUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    PhotoUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    InfoUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landmarks", x => x.Id);
                });

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
                name: "MessageStickerStyles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StickerUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    PositionX = table.Column<double>(type: "double precision", nullable: false),
                    PositionY = table.Column<double>(type: "double precision", nullable: false),
                    SizeX = table.Column<double>(type: "double precision", nullable: false),
                    SizeY = table.Column<double>(type: "double precision", nullable: false),
                    Rotation = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStickerStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "ChannelSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageDuration = table.Column<long>(type: "bigint", nullable: false),
                    MessageHighlightThreshold = table.Column<int>(type: "integer", nullable: true),
                    MessageArchiveThreshold = table.Column<int>(type: "integer", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(260)", maxLength: 260, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RefreshToken = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    InboxId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Inboxes_InboxId",
                        column: x => x.InboxId,
                        principalTable: "Inboxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_MessageReacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateArchives",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContentType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    MessageFontFamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageFontStyleId = table.Column<Guid>(type: "uuid", nullable: false),
                    LandmarkId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPinned = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DmId = table.Column<Guid>(type: "uuid", nullable: true),
                    InboxId = table.Column<Guid>(type: "uuid", nullable: true),
                    ArchivedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    FrameType = table.Column<int>(type: "integer", nullable: true),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FrameOptionsId = table.Column<Guid>(type: "uuid", nullable: true),
                    NoteFontStyleId = table.Column<Guid>(type: "uuid", nullable: true),
                    NoteFontFamilyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateArchives_Channels_DmId",
                        column: x => x.DmId,
                        principalTable: "Channels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateArchives_FontFamilies_MessageFontFamilyId",
                        column: x => x.MessageFontFamilyId,
                        principalTable: "FontFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateArchives_FontFamilies_NoteFontFamilyId",
                        column: x => x.NoteFontFamilyId,
                        principalTable: "FontFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateArchives_FontStyles_MessageFontStyleId",
                        column: x => x.MessageFontStyleId,
                        principalTable: "FontStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateArchives_FontStyles_NoteFontStyleId",
                        column: x => x.NoteFontStyleId,
                        principalTable: "FontStyles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateArchives_Inboxes_InboxId",
                        column: x => x.InboxId,
                        principalTable: "Inboxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateArchives_Landmarks_LandmarkId",
                        column: x => x.LandmarkId,
                        principalTable: "Landmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateArchives_MessageFrameOptions_FrameOptionsId",
                        column: x => x.FrameOptionsId,
                        principalTable: "MessageFrameOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateArchives_Users_ArchivedUserId",
                        column: x => x.ArchivedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateArchives_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PrivateMessages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContentType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    MessageFontFamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageFontStyleId = table.Column<Guid>(type: "uuid", nullable: false),
                    LandmarkId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPinned = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DmId = table.Column<Guid>(type: "uuid", nullable: true),
                    InboxId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateMessages_Channels_DmId",
                        column: x => x.DmId,
                        principalTable: "Channels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateMessages_FontFamilies_MessageFontFamilyId",
                        column: x => x.MessageFontFamilyId,
                        principalTable: "FontFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateMessages_FontStyles_MessageFontStyleId",
                        column: x => x.MessageFontStyleId,
                        principalTable: "FontStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateMessages_Inboxes_InboxId",
                        column: x => x.InboxId,
                        principalTable: "Inboxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateMessages_Landmarks_LandmarkId",
                        column: x => x.LandmarkId,
                        principalTable: "Landmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PublicArchives",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContentType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    MessageFontFamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageFontStyleId = table.Column<Guid>(type: "uuid", nullable: false),
                    LandmarkId = table.Column<Guid>(type: "uuid", nullable: false),
                    FrameType = table.Column<int>(type: "integer", nullable: true),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FrameOptionsId = table.Column<Guid>(type: "uuid", nullable: true),
                    NoteFontStyleId = table.Column<Guid>(type: "uuid", nullable: true),
                    NoteFontFamilyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicArchives_FontFamilies_MessageFontFamilyId",
                        column: x => x.MessageFontFamilyId,
                        principalTable: "FontFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicArchives_FontFamilies_NoteFontFamilyId",
                        column: x => x.NoteFontFamilyId,
                        principalTable: "FontFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PublicArchives_FontStyles_MessageFontStyleId",
                        column: x => x.MessageFontStyleId,
                        principalTable: "FontStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicArchives_FontStyles_NoteFontStyleId",
                        column: x => x.NoteFontStyleId,
                        principalTable: "FontStyles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PublicArchives_Landmarks_LandmarkId",
                        column: x => x.LandmarkId,
                        principalTable: "Landmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicArchives_MessageFrameOptions_FrameOptionsId",
                        column: x => x.FrameOptionsId,
                        principalTable: "MessageFrameOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PublicArchives_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PublicMessages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContentType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    MessageFontFamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageFontStyleId = table.Column<Guid>(type: "uuid", nullable: false),
                    LandmarkId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicMessages_FontFamilies_MessageFontFamilyId",
                        column: x => x.MessageFontFamilyId,
                        principalTable: "FontFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicMessages_FontStyles_MessageFontStyleId",
                        column: x => x.MessageFontStyleId,
                        principalTable: "FontStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicMessages_Landmarks_LandmarkId",
                        column: x => x.LandmarkId,
                        principalTable: "Landmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupportTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBlacklist",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlacklistId = table.Column<Guid>(type: "uuid", nullable: false),
                    Since = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Temporary = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBlacklist", x => new { x.UserId, x.BlacklistId });
                    table.ForeignKey(
                        name: "FK_UserBlacklist_Users_BlacklistId",
                        column: x => x.BlacklistId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBlacklist_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DisplayName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Bio = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    DoB = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AvatarUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CoverUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    Country = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfos_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTimeouts",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChannelId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeoutEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTimeouts", x => new { x.UserId, x.ChannelId });
                    table.ForeignKey(
                        name: "FK_UserTimeouts_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTimeouts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "ReportData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataType = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.InsertData(
                table: "CuratorSettings",
                columns: new[] { "Id", "DefaultChannelRadiusInKm", "DefaultMessageArchiveThreshold", "DefaultMessageDurationInHour", "DefaultMessageHighlightThreshold", "DefaultTimeoutPeriodInMinute", "LandmarkTaggableRangeInKm", "PrivateMessagePublishDeadlineInHour", "PublicMessageFrequencyIntervalInSecond", "PublicMessageFrequencyPerInterval" },
                values: new object[] { 1, 1.0, 20, 2f, 5, 20f, 0.1f, 0.25f, 5, 5f });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelPublicMessage_MessagesId",
                table: "ChannelPublicMessage",
                column: "MessagesId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_ArchivedUserId",
                table: "PrivateArchives",
                column: "ArchivedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_DmId",
                table: "PrivateArchives",
                column: "DmId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_DmId_Created",
                table: "PrivateArchives",
                columns: new[] { "DmId", "Created" });

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_FrameOptionsId",
                table: "PrivateArchives",
                column: "FrameOptionsId");

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
                name: "IX_PrivateArchives_NoteFontFamilyId",
                table: "PrivateArchives",
                column: "NoteFontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_NoteFontStyleId",
                table: "PrivateArchives",
                column: "NoteFontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_UserId",
                table: "PrivateArchives",
                column: "UserId");

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
                name: "IX_PublicArchives_FrameOptionsId",
                table: "PublicArchives",
                column: "FrameOptionsId");

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
                name: "IX_PublicArchives_NoteFontFamilyId",
                table: "PublicArchives",
                column: "NoteFontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_NoteFontStyleId",
                table: "PublicArchives",
                column: "NoteFontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_UserId",
                table: "PublicArchives",
                column: "UserId");

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
                name: "IX_ReportData_ReportId",
                table: "ReportData",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_UserId",
                table: "SupportTickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBlacklist_BlacklistId",
                table: "UserBlacklist",
                column: "BlacklistId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InboxId",
                table: "Users",
                column: "InboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTimeouts_ChannelId",
                table: "UserTimeouts",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTimeouts_UserId",
                table: "UserTimeouts",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChannelPublicMessage");

            migrationBuilder.DropTable(
                name: "ChannelSettings");

            migrationBuilder.DropTable(
                name: "CuratorSettings");

            migrationBuilder.DropTable(
                name: "MessageReacts");

            migrationBuilder.DropTable(
                name: "MessageStickerStylePrivateArchive");

            migrationBuilder.DropTable(
                name: "MessageStickerStylePublicArchive");

            migrationBuilder.DropTable(
                name: "PrivateMessages");

            migrationBuilder.DropTable(
                name: "PublicMessages");

            migrationBuilder.DropTable(
                name: "ReportData");

            migrationBuilder.DropTable(
                name: "UserBlacklist");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "UserTimeouts");

            migrationBuilder.DropTable(
                name: "PrivateArchives");

            migrationBuilder.DropTable(
                name: "MessageStickerStyles");

            migrationBuilder.DropTable(
                name: "PublicArchives");

            migrationBuilder.DropTable(
                name: "SupportTickets");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "FontFamilies");

            migrationBuilder.DropTable(
                name: "FontStyles");

            migrationBuilder.DropTable(
                name: "Landmarks");

            migrationBuilder.DropTable(
                name: "MessageFrameOptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Inboxes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
