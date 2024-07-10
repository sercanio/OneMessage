using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBlocking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3577af89-9bdf-486e-ae7e-3f674a83448b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c02aa1ce-9d82-49a0-b54a-3eafca539ed6"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[] { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.DeleteAppUserBlocking", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f808eba6-43db-4524-9762-e1d151b87ad9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 152, 233, 160, 253, 207, 39, 53, 33, 50, 171, 88, 135, 52, 69, 89, 130, 170, 186, 201, 166, 80, 49, 83, 156, 132, 175, 174, 14, 197, 231, 93, 119, 76, 127, 62, 2, 228, 61, 211, 95, 27, 141, 240, 65, 54, 199, 176, 15, 217, 95, 6, 140, 146, 48, 95, 171, 17, 120, 130, 194, 54, 162, 211, 22 }, new byte[] { 135, 14, 200, 70, 4, 8, 40, 215, 146, 218, 184, 24, 44, 110, 197, 217, 192, 22, 93, 104, 95, 47, 65, 235, 245, 162, 104, 138, 175, 252, 51, 88, 222, 62, 12, 60, 187, 56, 85, 181, 29, 180, 60, 135, 214, 189, 206, 90, 142, 94, 16, 121, 143, 158, 27, 195, 242, 240, 209, 248, 89, 6, 49, 62, 119, 144, 177, 245, 178, 131, 77, 115, 138, 161, 157, 152, 120, 95, 165, 242, 116, 44, 247, 76, 118, 121, 213, 78, 79, 76, 208, 196, 84, 209, 205, 185, 181, 118, 174, 226, 161, 235, 20, 42, 222, 225, 77, 92, 62, 111, 106, 77, 114, 235, 172, 72, 110, 81, 71, 54, 234, 87, 202, 180, 94, 121, 33, 102 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c253fdbe-a76e-4956-9230-2acb38705cb1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f808eba6-43db-4524-9762-e1d151b87ad9") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c253fdbe-a76e-4956-9230-2acb38705cb1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f808eba6-43db-4524-9762-e1d151b87ad9"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c02aa1ce-9d82-49a0-b54a-3eafca539ed6"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 26, 14, 207, 87, 96, 84, 237, 173, 84, 85, 2, 119, 149, 250, 74, 38, 145, 82, 215, 219, 2, 167, 90, 184, 6, 77, 63, 48, 176, 228, 226, 201, 18, 137, 244, 135, 121, 131, 68, 230, 84, 228, 6, 10, 10, 74, 241, 13, 218, 95, 129, 4, 218, 89, 247, 107, 58, 1, 120, 152, 115, 2, 229, 29 }, new byte[] { 6, 156, 241, 85, 3, 244, 53, 101, 28, 122, 9, 30, 2, 116, 245, 228, 207, 121, 232, 155, 144, 34, 39, 92, 55, 153, 108, 101, 142, 13, 228, 30, 128, 18, 134, 83, 218, 23, 22, 113, 191, 96, 42, 90, 157, 216, 61, 39, 149, 159, 0, 94, 174, 82, 90, 90, 238, 126, 129, 4, 36, 26, 24, 182, 139, 253, 211, 119, 110, 230, 154, 137, 88, 219, 180, 184, 154, 130, 5, 235, 31, 188, 146, 28, 102, 175, 199, 73, 128, 117, 51, 240, 120, 220, 74, 208, 229, 139, 119, 170, 211, 154, 127, 174, 64, 190, 107, 25, 223, 6, 186, 130, 60, 236, 107, 42, 97, 17, 120, 197, 106, 150, 241, 92, 107, 166, 165, 76 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3577af89-9bdf-486e-ae7e-3f674a83448b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c02aa1ce-9d82-49a0-b54a-3eafca539ed6") });
        }
    }
}
