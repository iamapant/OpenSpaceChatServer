using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class NormalizeDecoration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_FontFamilies_NoteFontFamilyId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_FontStyles_NoteFontStyleId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_FrameOptions_FrameOptionsId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_Frames_FrameId",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_FontFamilies_NoteFontFamilyId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_FontStyles_NoteFontStyleId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_FrameOptions_FrameOptionsId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_Frames_FrameId",
                table: "PublicArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_FontFamilies_FontFamilyId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_FontStyles_FontStyleId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_FrameOptions_FrameOptionsId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Frames_FrameId",
                table: "UserInfos");

            migrationBuilder.DropTable(
                name: "UserMessageDecorations");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_FontFamilyId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_FontStyleId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_FrameId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_FrameOptionsId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_PublicArchives_FrameId",
                table: "PublicArchives");

            migrationBuilder.DropIndex(
                name: "IX_PublicArchives_FrameOptionsId",
                table: "PublicArchives");

            migrationBuilder.DropIndex(
                name: "IX_PublicArchives_NoteFontFamilyId",
                table: "PublicArchives");

            migrationBuilder.DropIndex(
                name: "IX_PublicArchives_NoteFontStyleId",
                table: "PublicArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_FrameId",
                table: "PrivateArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_FrameOptionsId",
                table: "PrivateArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_NoteFontFamilyId",
                table: "PrivateArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_NoteFontStyleId",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "FontFamilyId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "FontStyleId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "FrameId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "FrameOptionsId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "FrameId",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "FrameOptionsId",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "NoteFontFamilyId",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "FrameId",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "FrameOptionsId",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "NoteFontFamilyId",
                table: "PrivateArchives");

            migrationBuilder.RenameColumn(
                name: "NoteFontStyleId",
                table: "PublicArchives",
                newName: "DecorationId");

            migrationBuilder.RenameColumn(
                name: "NoteFontStyleId",
                table: "PrivateArchives",
                newName: "DecorationId");

            migrationBuilder.AddColumn<string>(
                name: "DecorationMessageId",
                table: "PublicArchives",
                type: "character varying(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DecorationTempId1",
                table: "PublicArchives",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DecorationMessageId",
                table: "PrivateArchives",
                type: "character varying(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DecorationTempId",
                table: "PrivateArchives",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Decorations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FontFamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    FontStyleId = table.Column<Guid>(type: "uuid", nullable: false),
                    FrameId = table.Column<Guid>(type: "uuid", nullable: false),
                    FrameOptionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decorations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decorations_FontFamilies_FontFamilyId",
                        column: x => x.FontFamilyId,
                        principalTable: "FontFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decorations_FontStyles_FontStyleId",
                        column: x => x.FontStyleId,
                        principalTable: "FontStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decorations_FrameOptions_FrameOptionsId",
                        column: x => x.FrameOptionsId,
                        principalTable: "FrameOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decorations_Frames_FrameId",
                        column: x => x.FrameId,
                        principalTable: "Frames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageDecorations",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DecorationId = table.Column<Guid>(type: "uuid", nullable: false),
                    FontFamilyId = table.Column<Guid>(type: "uuid", nullable: true),
                    FontStyleId = table.Column<Guid>(type: "uuid", nullable: true),
                    FrameId = table.Column<Guid>(type: "uuid", nullable: true),
                    FrameOptionsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageDecorations", x => new { x.MessageId, x.DecorationId });
                    table.ForeignKey(
                        name: "FK_MessageDecorations_Decorations_DecorationId",
                        column: x => x.DecorationId,
                        principalTable: "Decorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageDecorations_FontFamilies_FontFamilyId",
                        column: x => x.FontFamilyId,
                        principalTable: "FontFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageDecorations_FontStyles_FontStyleId",
                        column: x => x.FontStyleId,
                        principalTable: "FontStyles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageDecorations_FrameOptions_FrameOptionsId",
                        column: x => x.FrameOptionsId,
                        principalTable: "FrameOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageDecorations_Frames_FrameId",
                        column: x => x.FrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageDecorations_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDecorations",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DecorationId = table.Column<Guid>(type: "uuid", nullable: false),
                    FontFamilyId = table.Column<Guid>(type: "uuid", nullable: true),
                    FontStyleId = table.Column<Guid>(type: "uuid", nullable: true),
                    FrameId = table.Column<Guid>(type: "uuid", nullable: true),
                    FrameOptionsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDecorations", x => new { x.UserId, x.DecorationId });
                    table.ForeignKey(
                        name: "FK_UserDecorations_Decorations_DecorationId",
                        column: x => x.DecorationId,
                        principalTable: "Decorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDecorations_FontFamilies_FontFamilyId",
                        column: x => x.FontFamilyId,
                        principalTable: "FontFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDecorations_FontStyles_FontStyleId",
                        column: x => x.FontStyleId,
                        principalTable: "FontStyles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDecorations_FrameOptions_FrameOptionsId",
                        column: x => x.FrameOptionsId,
                        principalTable: "FrameOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDecorations_Frames_FrameId",
                        column: x => x.FrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDecorations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_DecorationTempId1",
                table: "PublicArchives",
                column: "DecorationTempId1");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_DecorationTempId",
                table: "PrivateArchives",
                column: "DecorationTempId");

            migrationBuilder.CreateIndex(
                name: "IX_Decorations_FontFamilyId",
                table: "Decorations",
                column: "FontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Decorations_FontStyleId",
                table: "Decorations",
                column: "FontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Decorations_FrameId",
                table: "Decorations",
                column: "FrameId");

            migrationBuilder.CreateIndex(
                name: "IX_Decorations_FrameOptionsId",
                table: "Decorations",
                column: "FrameOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDecorations_DecorationId",
                table: "MessageDecorations",
                column: "DecorationId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDecorations_FontFamilyId",
                table: "MessageDecorations",
                column: "FontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDecorations_FontStyleId",
                table: "MessageDecorations",
                column: "FontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDecorations_FrameId",
                table: "MessageDecorations",
                column: "FrameId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDecorations_FrameOptionsId",
                table: "MessageDecorations",
                column: "FrameOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDecorations_MessageId",
                table: "MessageDecorations",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDecorations_DecorationId",
                table: "UserDecorations",
                column: "DecorationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDecorations_FontFamilyId",
                table: "UserDecorations",
                column: "FontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDecorations_FontStyleId",
                table: "UserDecorations",
                column: "FontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDecorations_FrameId",
                table: "UserDecorations",
                column: "FrameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDecorations_FrameOptionsId",
                table: "UserDecorations",
                column: "FrameOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDecorations_UserId",
                table: "UserDecorations",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_MessageDecorations_DecorationMessageId_Deco~",
                table: "PrivateArchives",
                columns: new[] { "DecorationMessageId", "DecorationId" },
                principalTable: "MessageDecorations",
                principalColumns: new[] { "MessageId", "DecorationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_MessageDecorations_DecorationMessageId_Decor~",
                table: "PublicArchives",
                columns: new[] { "DecorationMessageId", "DecorationId" },
                principalTable: "MessageDecorations",
                principalColumns: new[] { "MessageId", "DecorationId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateArchives_MessageDecorations_DecorationMessageId_Deco~",
                table: "PrivateArchives");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicArchives_MessageDecorations_DecorationMessageId_Decor~",
                table: "PublicArchives");

            migrationBuilder.DropTable(
                name: "MessageDecorations");

            migrationBuilder.DropTable(
                name: "UserDecorations");

            migrationBuilder.DropTable(
                name: "Decorations");

            migrationBuilder.DropIndex(
                name: "IX_PublicArchives_DecorationTempId1",
                table: "PublicArchives");

            migrationBuilder.DropIndex(
                name: "IX_PrivateArchives_DecorationTempId",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "DecorationMessageId",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "DecorationTempId1",
                table: "PublicArchives");

            migrationBuilder.DropColumn(
                name: "DecorationMessageId",
                table: "PrivateArchives");

            migrationBuilder.DropColumn(
                name: "DecorationTempId",
                table: "PrivateArchives");

            migrationBuilder.RenameColumn(
                name: "DecorationId",
                table: "PublicArchives",
                newName: "NoteFontStyleId");

            migrationBuilder.RenameColumn(
                name: "DecorationId",
                table: "PrivateArchives",
                newName: "NoteFontStyleId");

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
                name: "FrameId",
                table: "UserInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FrameOptionsId",
                table: "UserInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FrameId",
                table: "PublicArchives",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FrameOptionsId",
                table: "PublicArchives",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NoteFontFamilyId",
                table: "PublicArchives",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FrameId",
                table: "PrivateArchives",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FrameOptionsId",
                table: "PrivateArchives",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NoteFontFamilyId",
                table: "PrivateArchives",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserMessageDecorations",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FrameId = table.Column<Guid>(type: "uuid", nullable: true),
                    FrameOptionsId = table.Column<Guid>(type: "uuid", nullable: true),
                    NoteFontFamilyId = table.Column<Guid>(type: "uuid", nullable: true),
                    NoteFontStyleId = table.Column<Guid>(type: "uuid", nullable: true),
                    MessageColorPrimary = table.Column<int>(type: "integer", nullable: true),
                    MessageColorSecondary = table.Column<int>(type: "integer", nullable: true)
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
                        name: "FK_UserMessageDecorations_FrameOptions_FrameOptionsId",
                        column: x => x.FrameOptionsId,
                        principalTable: "FrameOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMessageDecorations_Frames_FrameId",
                        column: x => x.FrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMessageDecorations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("019a3686-7e19-75d0-bf65-96f0f919394e"),
                columns: new[] { "FontFamilyId", "FontStyleId", "FrameId", "FrameOptionsId" },
                values: new object[] { null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_FontFamilyId",
                table: "UserInfos",
                column: "FontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_FontStyleId",
                table: "UserInfos",
                column: "FontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_FrameId",
                table: "UserInfos",
                column: "FrameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_FrameOptionsId",
                table: "UserInfos",
                column: "FrameOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_FrameId",
                table: "PublicArchives",
                column: "FrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_FrameOptionsId",
                table: "PublicArchives",
                column: "FrameOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_NoteFontFamilyId",
                table: "PublicArchives",
                column: "NoteFontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicArchives_NoteFontStyleId",
                table: "PublicArchives",
                column: "NoteFontStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_FrameId",
                table: "PrivateArchives",
                column: "FrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_FrameOptionsId",
                table: "PrivateArchives",
                column: "FrameOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_NoteFontFamilyId",
                table: "PrivateArchives",
                column: "NoteFontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateArchives_NoteFontStyleId",
                table: "PrivateArchives",
                column: "NoteFontStyleId");

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
                name: "FK_PrivateArchives_FontFamilies_NoteFontFamilyId",
                table: "PrivateArchives",
                column: "NoteFontFamilyId",
                principalTable: "FontFamilies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateArchives_FontStyles_NoteFontStyleId",
                table: "PrivateArchives",
                column: "NoteFontStyleId",
                principalTable: "FontStyles",
                principalColumn: "Id");

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
                name: "FK_PublicArchives_FontFamilies_NoteFontFamilyId",
                table: "PublicArchives",
                column: "NoteFontFamilyId",
                principalTable: "FontFamilies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicArchives_FontStyles_NoteFontStyleId",
                table: "PublicArchives",
                column: "NoteFontStyleId",
                principalTable: "FontStyles",
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
        }
    }
}
