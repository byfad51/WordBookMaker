using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserSaver.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba4cd579-2b67-4b7b-9e0b-c5e97e29098a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c1dd0fd-e477-459f-8b58-2361d00ded43", null, "GoldUser", "GOLD_USER" },
                    { "66381a34-dcbf-4b46-831a-31f21f94bc51", null, "Admin", "ADMIN" },
                    { "7591a825-d048-4b6d-b9c2-d4f777e63e7e", null, "SilverUser", "SILVER_USER" },
                    { "f0a4bcce-047c-43c2-b93b-f0fbabf88250", null, "BronzeUser", "BRONZE_USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dfadd28d-9451-4646-80ab-6abb3848654e", 0, "b92c774b-9b12-4576-a64b-d4e9ce505671", null, false, "Mehmet", "Ali", false, null, null, null, null, null, false, "21c85701-1317-4e3b-b920-67fbca7833c7", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c1dd0fd-e477-459f-8b58-2361d00ded43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66381a34-dcbf-4b46-831a-31f21f94bc51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7591a825-d048-4b6d-b9c2-d4f777e63e7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0a4bcce-047c-43c2-b93b-f0fbabf88250");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfadd28d-9451-4646-80ab-6abb3848654e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba4cd579-2b67-4b7b-9e0b-c5e97e29098a", 0, "2492d693-3ec4-4d0b-a57e-0a673461775a", null, false, "Mehmet", "Ali", false, null, null, null, null, null, false, "197a1736-0f03-46a3-b05c-7f1042c74cea", false, null });
        }
    }
}
