using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateAppuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AppUsers_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AppUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "AppUserAppUser");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("26d736c1-db0b-4333-9171-acbf261179b0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("02a2b4d5-b54e-4d6c-82d5-135243e55b7f"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AppUsers_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AppUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AppUsers_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AppUsers_SenderId",
                table: "Messages");

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
                values: new object[] { new Guid("02a2b4d5-b54e-4d6c-82d5-135243e55b7f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 168, 23, 111, 9, 255, 150, 11, 56, 102, 189, 87, 39, 51, 152, 158, 164, 246, 249, 239, 193, 121, 236, 113, 184, 162, 76, 57, 94, 173, 75, 169, 252, 88, 116, 88, 109, 221, 222, 84, 59, 49, 124, 24, 50, 201, 8, 81, 204, 151, 166, 194, 36, 53, 8, 239, 34, 225, 75, 204, 88, 219, 217, 190, 121 }, new byte[] { 249, 74, 213, 170, 116, 148, 108, 82, 71, 142, 208, 79, 108, 87, 197, 20, 121, 7, 94, 38, 173, 5, 46, 69, 165, 169, 252, 85, 140, 132, 0, 16, 247, 145, 172, 142, 93, 255, 177, 254, 64, 44, 49, 245, 17, 21, 225, 224, 213, 159, 23, 31, 158, 183, 198, 221, 222, 116, 243, 70, 183, 233, 217, 69, 21, 100, 76, 50, 139, 221, 39, 59, 56, 182, 62, 104, 45, 187, 244, 72, 134, 210, 180, 126, 178, 27, 51, 159, 95, 178, 202, 75, 148, 126, 101, 228, 91, 202, 169, 48, 33, 145, 15, 185, 197, 253, 233, 215, 199, 54, 186, 160, 84, 243, 74, 129, 199, 69, 190, 215, 235, 223, 2, 182, 59, 240, 108, 8 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("26d736c1-db0b-4333-9171-acbf261179b0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("02a2b4d5-b54e-4d6c-82d5-135243e55b7f") });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAppUser_ContactsId",
                table: "AppUserAppUser",
                column: "ContactsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AppUsers_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AppUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
