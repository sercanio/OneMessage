using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c253fdbe-a76e-4956-9230-2acb38705cb1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f808eba6-43db-4524-9762-e1d151b87ad9"));

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Seen = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AppUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AppUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Admin", null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Read", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Write", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Create", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Update", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Delete", null }
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
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("26d736c1-db0b-4333-9171-acbf261179b0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("02a2b4d5-b54e-4d6c-82d5-135243e55b7f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f808eba6-43db-4524-9762-e1d151b87ad9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 152, 233, 160, 253, 207, 39, 53, 33, 50, 171, 88, 135, 52, 69, 89, 130, 170, 186, 201, 166, 80, 49, 83, 156, 132, 175, 174, 14, 197, 231, 93, 119, 76, 127, 62, 2, 228, 61, 211, 95, 27, 141, 240, 65, 54, 199, 176, 15, 217, 95, 6, 140, 146, 48, 95, 171, 17, 120, 130, 194, 54, 162, 211, 22 }, new byte[] { 135, 14, 200, 70, 4, 8, 40, 215, 146, 218, 184, 24, 44, 110, 197, 217, 192, 22, 93, 104, 95, 47, 65, 235, 245, 162, 104, 138, 175, 252, 51, 88, 222, 62, 12, 60, 187, 56, 85, 181, 29, 180, 60, 135, 214, 189, 206, 90, 142, 94, 16, 121, 143, 158, 27, 195, 242, 240, 209, 248, 89, 6, 49, 62, 119, 144, 177, 245, 178, 131, 77, 115, 138, 161, 157, 152, 120, 95, 165, 242, 116, 44, 247, 76, 118, 121, 213, 78, 79, 76, 208, 196, 84, 209, 205, 185, 181, 118, 174, 226, 161, 235, 20, 42, 222, 225, 77, 92, 62, 111, 106, 77, 114, 235, 172, 72, 110, 81, 71, 54, 234, 87, 202, 180, 94, 121, 33, 102 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c253fdbe-a76e-4956-9230-2acb38705cb1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f808eba6-43db-4524-9762-e1d151b87ad9") });
        }
    }
}
