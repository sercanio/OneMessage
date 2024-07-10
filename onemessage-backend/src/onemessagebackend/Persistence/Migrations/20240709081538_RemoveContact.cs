using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9948a544-a129-4c1f-95bd-fdccedcf9e0f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b376bf00-af0d-4b16-bcfa-a41d4d239a57"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[] { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.DeleteAppUserContact", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("1c416822-ae22-43b7-b101-be4f6fadab4e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 40, 59, 164, 249, 141, 19, 75, 18, 58, 35, 175, 202, 8, 38, 120, 218, 126, 210, 221, 164, 102, 235, 93, 125, 48, 1, 31, 164, 32, 108, 189, 194, 237, 108, 24, 67, 90, 249, 240, 189, 190, 150, 224, 25, 53, 67, 81, 237, 24, 198, 236, 169, 114, 148, 32, 201, 148, 91, 220, 19, 102, 127, 123, 198 }, new byte[] { 252, 241, 96, 76, 37, 114, 100, 17, 251, 15, 147, 206, 136, 55, 88, 44, 165, 191, 222, 241, 76, 25, 225, 128, 36, 122, 160, 105, 74, 196, 168, 39, 161, 35, 109, 219, 41, 254, 148, 180, 205, 225, 179, 249, 235, 214, 57, 124, 173, 241, 63, 136, 33, 79, 149, 226, 190, 201, 192, 235, 57, 130, 7, 95, 37, 203, 144, 199, 50, 32, 28, 24, 220, 5, 133, 20, 217, 132, 198, 48, 216, 118, 70, 166, 233, 11, 28, 101, 214, 80, 25, 208, 79, 24, 191, 165, 22, 198, 174, 7, 43, 105, 27, 246, 222, 73, 23, 102, 247, 150, 111, 57, 88, 144, 43, 55, 24, 78, 25, 178, 49, 15, 121, 59, 152, 60, 246, 246 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("703f65c0-650a-4920-9aa9-474cd560cc69"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1c416822-ae22-43b7-b101-be4f6fadab4e") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("703f65c0-650a-4920-9aa9-474cd560cc69"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c416822-ae22-43b7-b101-be4f6fadab4e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("b376bf00-af0d-4b16-bcfa-a41d4d239a57"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 9, 114, 4, 21, 11, 162, 17, 146, 114, 107, 3, 162, 215, 115, 112, 35, 147, 66, 238, 180, 47, 69, 196, 124, 199, 151, 184, 15, 38, 176, 181, 82, 236, 231, 192, 201, 214, 83, 141, 85, 221, 40, 102, 132, 124, 220, 20, 43, 150, 92, 247, 151, 4, 92, 34, 231, 110, 132, 75, 190, 218, 115, 36, 65 }, new byte[] { 166, 89, 196, 124, 224, 156, 142, 15, 37, 159, 37, 241, 81, 244, 101, 159, 162, 79, 14, 155, 213, 78, 107, 154, 232, 53, 31, 61, 137, 152, 254, 171, 161, 167, 241, 107, 251, 55, 165, 57, 212, 45, 141, 255, 120, 86, 224, 201, 220, 149, 206, 56, 106, 173, 197, 217, 204, 19, 192, 163, 194, 236, 9, 79, 180, 80, 44, 83, 235, 12, 64, 135, 58, 148, 225, 173, 85, 167, 229, 126, 103, 9, 25, 105, 247, 222, 91, 151, 27, 50, 39, 223, 75, 52, 173, 232, 105, 163, 98, 223, 240, 1, 8, 138, 131, 96, 126, 174, 4, 105, 120, 201, 71, 0, 37, 16, 224, 4, 70, 163, 240, 241, 242, 78, 79, 0, 111, 96 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9948a544-a129-4c1f-95bd-fdccedcf9e0f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b376bf00-af0d-4b16-bcfa-a41d4d239a57") });
        }
    }
}
