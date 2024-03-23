using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserSaver.Migrations
{
    /// <inheritdoc />
    public partial class words_notes_migratin_2103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TurkishMean = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WordNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WordSentence = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordNotes_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_WordNotes_WordId",
                table: "WordNotes",
                column: "WordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordNotes");

            migrationBuilder.DropTable(
                name: "Words");

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
    }
}
