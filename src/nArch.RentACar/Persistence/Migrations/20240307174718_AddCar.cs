using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ff990740-21fb-43d8-b827-a13c678f127b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("450d48ed-8595-4e42-9c7d-6e53fa3a67c4"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Admin", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Read", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Write", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Create", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Update", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("58eb7aab-5b79-4e69-add8-6e4a6e946510"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 56, 254, 92, 147, 81, 158, 247, 165, 14, 173, 157, 225, 205, 255, 149, 147, 207, 137, 204, 80, 69, 69, 184, 234, 211, 216, 111, 222, 148, 77, 112, 91, 155, 238, 175, 219, 207, 31, 252, 252, 75, 201, 17, 161, 166, 22, 34, 99, 231, 181, 61, 146, 138, 167, 82, 59, 55, 13, 39, 51, 192, 197, 203, 124 }, new byte[] { 139, 102, 28, 236, 67, 156, 178, 86, 195, 118, 43, 120, 7, 123, 145, 89, 207, 102, 100, 95, 253, 184, 71, 136, 60, 89, 32, 204, 157, 32, 35, 85, 150, 125, 65, 207, 83, 234, 112, 141, 188, 53, 191, 203, 226, 241, 101, 89, 132, 48, 35, 90, 159, 135, 56, 27, 19, 144, 220, 150, 111, 250, 217, 222, 4, 85, 65, 76, 199, 70, 183, 102, 72, 219, 237, 105, 198, 105, 254, 160, 128, 26, 52, 175, 212, 244, 93, 136, 146, 242, 121, 44, 51, 177, 157, 4, 151, 114, 150, 71, 207, 245, 69, 223, 135, 193, 22, 94, 25, 129, 164, 136, 120, 95, 62, 67, 123, 69, 192, 78, 86, 169, 216, 122, 250, 166, 203, 23 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d337f50b-2d1e-46e6-a688-0d29296f69e7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("58eb7aab-5b79-4e69-add8-6e4a6e946510") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d337f50b-2d1e-46e6-a688-0d29296f69e7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("58eb7aab-5b79-4e69-add8-6e4a6e946510"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("450d48ed-8595-4e42-9c7d-6e53fa3a67c4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 79, 83, 246, 153, 152, 69, 51, 105, 38, 44, 232, 255, 211, 97, 169, 123, 240, 235, 32, 185, 16, 245, 62, 35, 232, 167, 233, 92, 118, 51, 197, 183, 41, 124, 155, 38, 17, 168, 20, 61, 190, 152, 150, 56, 156, 247, 58, 249, 156, 215, 77, 19, 72, 225, 241, 48, 99, 214, 179, 138, 171, 21, 227, 76 }, new byte[] { 115, 149, 87, 233, 106, 54, 181, 176, 3, 53, 236, 81, 248, 36, 12, 104, 44, 212, 238, 71, 185, 150, 147, 152, 74, 100, 65, 199, 180, 189, 15, 23, 43, 136, 56, 75, 48, 116, 211, 239, 210, 43, 86, 149, 204, 179, 174, 203, 130, 180, 241, 8, 78, 27, 118, 14, 12, 165, 255, 134, 199, 98, 83, 23, 183, 17, 31, 161, 72, 173, 156, 76, 218, 191, 154, 23, 68, 253, 254, 201, 52, 89, 85, 204, 27, 219, 0, 25, 178, 152, 48, 26, 179, 171, 70, 215, 125, 53, 195, 135, 8, 89, 204, 49, 74, 43, 73, 84, 11, 250, 212, 114, 197, 108, 150, 170, 99, 225, 159, 217, 209, 241, 52, 124, 9, 140, 131, 221 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("ff990740-21fb-43d8-b827-a13c678f127b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("450d48ed-8595-4e42-9c7d-6e53fa3a67c4") });
        }
    }
}
