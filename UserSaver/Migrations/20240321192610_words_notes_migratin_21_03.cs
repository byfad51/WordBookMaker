using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserSaver.Migrations
{
    /// <inheritdoc />
    public partial class words_notes_migratin_21_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f507433-12ff-4c9c-ac06-efd5b5a55275");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22c615de-b794-48f6-b577-816c3abcae5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3304a741-b95e-4b38-ac67-b86246f307ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89dda4ea-4ddb-4644-8838-d14673bfc400");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "974388f6-1f26-4c45-a0fb-64ac70e1aeab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dddb23e-5d59-413c-ae61-8fb733fd2849", null, "Admin", "ADMIN" },
                    { "22720ff2-a115-46fe-8501-fd668f501bd8", null, "SilverUser", "SILVER_USER" },
                    { "775f3e59-7b22-48cd-a871-204a15250563", null, "GoldUser", "GOLD_USER" },
                    { "ca33917f-b93b-4f07-9fac-c0995f0cfda2", null, "BronzeUser", "BRONZE_USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ca1c76b8-a42f-4d3e-872b-cbe61a36e147", 0, "0c4c1d9a-6091-4ba8-a8fc-b73890bbd312", null, false, "Mehmet", "Ali", false, null, null, null, null, null, false, "ce944396-2047-42a5-bbee-26e58b696e9c", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dddb23e-5d59-413c-ae61-8fb733fd2849");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22720ff2-a115-46fe-8501-fd668f501bd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "775f3e59-7b22-48cd-a871-204a15250563");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca33917f-b93b-4f07-9fac-c0995f0cfda2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca1c76b8-a42f-4d3e-872b-cbe61a36e147");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f507433-12ff-4c9c-ac06-efd5b5a55275", null, "SilverUser", "SILVER_USER" },
                    { "22c615de-b794-48f6-b577-816c3abcae5b", null, "Admin", "ADMIN" },
                    { "3304a741-b95e-4b38-ac67-b86246f307ee", null, "BronzeUser", "BRONZE_USER" },
                    { "89dda4ea-4ddb-4644-8838-d14673bfc400", null, "GoldUser", "GOLD_USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "974388f6-1f26-4c45-a0fb-64ac70e1aeab", 0, "e74aba14-341a-4c9d-a217-9ee4f83c1bd7", null, false, "Mehmet", "Ali", false, null, null, null, null, null, false, "f264a145-5828-485f-9162-5005cf1e6f60", false, null });
        }
    }
}
