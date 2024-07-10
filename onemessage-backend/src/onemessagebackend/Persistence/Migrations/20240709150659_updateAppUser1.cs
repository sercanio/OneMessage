using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateAppUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserBlocking");

            migrationBuilder.DropTable(
                name: "AppUserContact");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4c23846a-cf68-4d42-9bd7-93be17c70f5b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("99c78e00-0b61-4477-89d3-f1ef9bafc6d2"));

            migrationBuilder.RenameIndex(
                name: "AppUser_UserID_UK",
                table: "AppUsers",
                newName: "IX_AppUsers_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AppUsers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "AppUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AvatarURL",
                table: "AppUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AppUserAppUser",
                columns: table => new
                {
                    BlockingsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAppUser", x => new { x.BlockingsId, x.ContactsId });
                    table.ForeignKey(
                        name: "FK_AppUserAppUser_AppUsers_BlockingsId",
                        column: x => x.BlockingsId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserAppUser_AppUsers_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("2c9cff6f-977a-48b2-be87-3c0bf8397078"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 163, 28, 108, 177, 16, 85, 175, 117, 171, 170, 216, 222, 226, 238, 47, 198, 27, 43, 236, 33, 158, 246, 206, 94, 201, 29, 76, 230, 176, 61, 169, 102, 252, 195, 184, 49, 168, 174, 160, 155, 234, 148, 104, 202, 38, 158, 90, 181, 43, 238, 232, 100, 1, 57, 156, 243, 218, 244, 85, 47, 189, 107, 112, 16 }, new byte[] { 21, 226, 20, 77, 76, 184, 63, 131, 34, 108, 102, 96, 19, 13, 20, 139, 216, 189, 22, 101, 5, 20, 130, 224, 147, 31, 237, 252, 112, 156, 215, 128, 181, 107, 226, 98, 254, 55, 227, 224, 107, 168, 129, 165, 17, 15, 143, 49, 5, 207, 248, 222, 202, 195, 85, 44, 121, 48, 104, 67, 59, 200, 167, 82, 10, 96, 145, 190, 237, 64, 95, 198, 122, 173, 116, 39, 42, 224, 147, 106, 2, 186, 232, 40, 90, 125, 140, 235, 151, 160, 143, 90, 94, 229, 176, 96, 117, 248, 194, 218, 236, 211, 120, 123, 154, 35, 194, 103, 95, 130, 193, 169, 166, 11, 102, 189, 103, 91, 87, 88, 215, 164, 114, 243, 39, 155, 175, 105 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1043d551-5843-4776-a4d8-442f8c06afc4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2c9cff6f-977a-48b2-be87-3c0bf8397078") });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAppUser_ContactsId",
                table: "AppUserAppUser",
                column: "ContactsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserAppUser");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1043d551-5843-4776-a4d8-442f8c06afc4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2c9cff6f-977a-48b2-be87-3c0bf8397078"));

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_UserId",
                table: "AppUsers",
                newName: "AppUser_UserID_UK");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AppUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "AppUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AvatarURL",
                table: "AppUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AppUserBlocking",
                columns: table => new
                {
                    BlockedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlockingUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserBlocking", x => new { x.BlockedUserId, x.BlockingUserId });
                    table.ForeignKey(
                        name: "FK_AppUserBlocking_AppUsers_BlockedUserId",
                        column: x => x.BlockedUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserBlocking_AppUsers_BlockingUserId",
                        column: x => x.BlockingUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserContact",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserContact", x => new { x.ContactId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AppUserContact_AppUsers_ContactId",
                        column: x => x.ContactId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserContact_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("99c78e00-0b61-4477-89d3-f1ef9bafc6d2"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 7, 233, 126, 192, 97, 252, 76, 102, 14, 228, 40, 72, 122, 123, 77, 111, 253, 82, 185, 23, 115, 178, 225, 139, 154, 219, 169, 178, 240, 199, 23, 179, 181, 1, 65, 145, 182, 7, 20, 138, 186, 122, 91, 107, 33, 109, 60, 65, 63, 176, 244, 33, 155, 174, 43, 37, 239, 101, 33, 1, 168, 110, 198, 26 }, new byte[] { 196, 186, 3, 135, 72, 168, 134, 40, 158, 18, 143, 59, 52, 106, 63, 188, 165, 10, 175, 52, 200, 85, 111, 125, 169, 54, 12, 124, 136, 49, 107, 84, 245, 0, 20, 165, 41, 193, 146, 27, 103, 175, 14, 106, 16, 183, 95, 178, 32, 110, 78, 4, 96, 176, 75, 97, 239, 147, 169, 44, 15, 71, 120, 224, 171, 190, 208, 3, 124, 232, 180, 155, 111, 18, 59, 52, 162, 135, 35, 54, 118, 139, 215, 0, 108, 42, 57, 2, 236, 124, 147, 147, 153, 85, 248, 149, 112, 24, 68, 73, 246, 162, 171, 202, 115, 226, 36, 199, 239, 149, 3, 58, 223, 180, 143, 203, 235, 47, 217, 165, 109, 74, 91, 175, 235, 194, 93, 239 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4c23846a-cf68-4d42-9bd7-93be17c70f5b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("99c78e00-0b61-4477-89d3-f1ef9bafc6d2") });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBlocking_BlockingUserId",
                table: "AppUserBlocking",
                column: "BlockingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserContact_UserId",
                table: "AppUserContact",
                column: "UserId");
        }
    }
}
