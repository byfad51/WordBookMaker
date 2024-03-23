using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserSaver.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba4cd579-2b67-4b7b-9e0b-c5e97e29098a", 0, "2492d693-3ec4-4d0b-a57e-0a673461775a", null, false, "Mehmet", "Ali", false, null, null, null, null, null, false, "197a1736-0f03-46a3-b05c-7f1042c74cea", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba4cd579-2b67-4b7b-9e0b-c5e97e29098a");
        }
    }
}
