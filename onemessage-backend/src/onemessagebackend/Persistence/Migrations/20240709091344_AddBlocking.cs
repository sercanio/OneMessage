using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBlocking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("703f65c0-650a-4920-9aa9-474cd560cc69"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c416822-ae22-43b7-b101-be4f6fadab4e"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[] { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.CreateAppUserBlocking", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c02aa1ce-9d82-49a0-b54a-3eafca539ed6"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 26, 14, 207, 87, 96, 84, 237, 173, 84, 85, 2, 119, 149, 250, 74, 38, 145, 82, 215, 219, 2, 167, 90, 184, 6, 77, 63, 48, 176, 228, 226, 201, 18, 137, 244, 135, 121, 131, 68, 230, 84, 228, 6, 10, 10, 74, 241, 13, 218, 95, 129, 4, 218, 89, 247, 107, 58, 1, 120, 152, 115, 2, 229, 29 }, new byte[] { 6, 156, 241, 85, 3, 244, 53, 101, 28, 122, 9, 30, 2, 116, 245, 228, 207, 121, 232, 155, 144, 34, 39, 92, 55, 153, 108, 101, 142, 13, 228, 30, 128, 18, 134, 83, 218, 23, 22, 113, 191, 96, 42, 90, 157, 216, 61, 39, 149, 159, 0, 94, 174, 82, 90, 90, 238, 126, 129, 4, 36, 26, 24, 182, 139, 253, 211, 119, 110, 230, 154, 137, 88, 219, 180, 184, 154, 130, 5, 235, 31, 188, 146, 28, 102, 175, 199, 73, 128, 117, 51, 240, 120, 220, 74, 208, 229, 139, 119, 170, 211, 154, 127, 174, 64, 190, 107, 25, 223, 6, 186, 130, 60, 236, 107, 42, 97, 17, 120, 197, 106, 150, 241, 92, 107, 166, 165, 76 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3577af89-9bdf-486e-ae7e-3f674a83448b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c02aa1ce-9d82-49a0-b54a-3eafca539ed6") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3577af89-9bdf-486e-ae7e-3f674a83448b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c02aa1ce-9d82-49a0-b54a-3eafca539ed6"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("1c416822-ae22-43b7-b101-be4f6fadab4e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 40, 59, 164, 249, 141, 19, 75, 18, 58, 35, 175, 202, 8, 38, 120, 218, 126, 210, 221, 164, 102, 235, 93, 125, 48, 1, 31, 164, 32, 108, 189, 194, 237, 108, 24, 67, 90, 249, 240, 189, 190, 150, 224, 25, 53, 67, 81, 237, 24, 198, 236, 169, 114, 148, 32, 201, 148, 91, 220, 19, 102, 127, 123, 198 }, new byte[] { 252, 241, 96, 76, 37, 114, 100, 17, 251, 15, 147, 206, 136, 55, 88, 44, 165, 191, 222, 241, 76, 25, 225, 128, 36, 122, 160, 105, 74, 196, 168, 39, 161, 35, 109, 219, 41, 254, 148, 180, 205, 225, 179, 249, 235, 214, 57, 124, 173, 241, 63, 136, 33, 79, 149, 226, 190, 201, 192, 235, 57, 130, 7, 95, 37, 203, 144, 199, 50, 32, 28, 24, 220, 5, 133, 20, 217, 132, 198, 48, 216, 118, 70, 166, 233, 11, 28, 101, 214, 80, 25, 208, 79, 24, 191, 165, 22, 198, 174, 7, 43, 105, 27, 246, 222, 73, 23, 102, 247, 150, 111, 57, 88, 144, 43, 55, 24, 78, 25, 178, 49, 15, 121, 59, 152, 60, 246, 246 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("703f65c0-650a-4920-9aa9-474cd560cc69"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1c416822-ae22-43b7-b101-be4f6fadab4e") });
        }
    }
}
