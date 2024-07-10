using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AppUserOperationClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AppUsers_AppUserId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AppUsers_AppUserId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AppUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AppUserId1",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d07144c3-d2fb-4613-8609-f658b9d01ea9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0e90ef7f-67ee-41b5-90a3-78dd5e20fc76"));

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Users");

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
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.GetDynamicAppUser", null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.CreateAppUserContact", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("b376bf00-af0d-4b16-bcfa-a41d4d239a57"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 9, 114, 4, 21, 11, 162, 17, 146, 114, 107, 3, 162, 215, 115, 112, 35, 147, 66, 238, 180, 47, 69, 196, 124, 199, 151, 184, 15, 38, 176, 181, 82, 236, 231, 192, 201, 214, 83, 141, 85, 221, 40, 102, 132, 124, 220, 20, 43, 150, 92, 247, 151, 4, 92, 34, 231, 110, 132, 75, 190, 218, 115, 36, 65 }, new byte[] { 166, 89, 196, 124, 224, 156, 142, 15, 37, 159, 37, 241, 81, 244, 101, 159, 162, 79, 14, 155, 213, 78, 107, 154, 232, 53, 31, 61, 137, 152, 254, 171, 161, 167, 241, 107, 251, 55, 165, 57, 212, 45, 141, 255, 120, 86, 224, 201, 220, 149, 206, 56, 106, 173, 197, 217, 204, 19, 192, 163, 194, 236, 9, 79, 180, 80, 44, 83, 235, 12, 64, 135, 58, 148, 225, 173, 85, 167, 229, 126, 103, 9, 25, 105, 247, 222, 91, 151, 27, 50, 39, 223, 75, 52, 173, 232, 105, 163, 98, 223, 240, 1, 8, 138, 131, 96, 126, 174, 4, 105, 120, 201, 71, 0, 37, 16, 224, 4, 70, 163, 240, 241, 242, 78, 79, 0, 111, 96 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9948a544-a129-4c1f-95bd-fdccedcf9e0f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b376bf00-af0d-4b16-bcfa-a41d4d239a57") });

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
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9948a544-a129-4c1f-95bd-fdccedcf9e0f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b376bf00-af0d-4b16-bcfa-a41d4d239a57"));

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId1",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AppUserId", "AppUserId1", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0e90ef7f-67ee-41b5-90a3-78dd5e20fc76"), null, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 233, 91, 3, 38, 224, 27, 30, 38, 226, 19, 175, 207, 59, 212, 173, 65, 0, 161, 196, 148, 155, 209, 203, 39, 178, 244, 227, 147, 159, 113, 110, 64, 7, 224, 120, 25, 30, 0, 200, 94, 11, 209, 104, 245, 168, 78, 21, 144, 72, 215, 135, 192, 22, 155, 217, 30, 57, 243, 67, 23, 19, 91, 169, 21 }, new byte[] { 206, 189, 114, 167, 28, 90, 107, 79, 174, 49, 128, 122, 180, 199, 56, 47, 232, 204, 234, 32, 136, 59, 145, 169, 72, 200, 182, 52, 79, 206, 220, 92, 109, 189, 188, 22, 67, 63, 167, 244, 217, 178, 155, 134, 109, 7, 31, 32, 10, 142, 233, 208, 4, 190, 219, 44, 246, 189, 150, 27, 155, 254, 239, 7, 209, 50, 25, 55, 251, 17, 35, 172, 196, 133, 101, 28, 173, 81, 10, 190, 248, 55, 107, 156, 51, 12, 68, 160, 220, 249, 65, 231, 146, 254, 221, 145, 19, 132, 103, 201, 155, 190, 229, 119, 224, 82, 92, 103, 69, 29, 252, 199, 250, 7, 82, 123, 5, 35, 228, 147, 24, 235, 172, 65, 190, 87, 122, 73 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d07144c3-d2fb-4613-8609-f658b9d01ea9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0e90ef7f-67ee-41b5-90a3-78dd5e20fc76") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AppUserId",
                table: "Users",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AppUserId1",
                table: "Users",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AppUsers_AppUserId",
                table: "Users",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AppUsers_AppUserId1",
                table: "Users",
                column: "AppUserId1",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }
    }
}
