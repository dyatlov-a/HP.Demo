using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HP.Demo.DataAccess.Migrations
{
    public partial class hpdemo001init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    GroupType = table.Column<int>(nullable: false),
                    Functionals = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Salt = table.Column<byte[]>(nullable: false),
                    Hash = table.Column<byte[]>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "xUserGroups",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xUserGroups", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_xUserGroups_eGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "eGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_xUserGroups_eUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "eUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "eGroups",
                columns: new[] { "Id", "Functionals", "GroupType", "Name" },
                values: new object[] { new Guid("5d52ad35-a76b-427d-a5b2-0a650e285644"), 1, 0, "Users" });

            migrationBuilder.InsertData(
                table: "eGroups",
                columns: new[] { "Id", "Functionals", "GroupType", "Name" },
                values: new object[] { new Guid("cdba21fe-cbe9-4939-8ff4-e1854e574c22"), 62, 1, "Admins" });

            migrationBuilder.InsertData(
                table: "eUsers",
                columns: new[] { "Id", "Email", "Hash", "RowVersion", "Salt" },
                values: new object[] { new Guid("b13f0125-3252-4f3c-9721-43b88ece43e5"), "admin@admin.ru", new byte[] { 55, 118, 136, 246, 211, 107, 228, 57, 161, 18, 172, 28, 73, 40, 163, 90, 206, 252, 96, 5, 238, 5, 214, 231, 169, 212, 30, 6, 226, 236, 250, 229, 179, 11, 116, 26, 196, 127, 153, 106, 68, 79, 206, 237, 12, 16, 193, 81, 51, 54, 14, 247, 55, 224, 93, 53, 107, 152, 235, 154, 127, 90, 36, 170, 162, 48, 176, 77, 67, 245, 121, 97, 190, 3, 33, 56, 225, 56, 14, 98, 227, 157, 150, 242, 244, 12, 163, 31, 186, 28, 119, 44, 7, 77, 86, 179, 248, 56, 237, 144, 116, 75, 15, 241, 26, 129, 65, 30, 86, 121, 200, 131, 156, 81, 134, 49, 143, 22, 18, 254, 155, 223, 213, 215, 243, 225, 96, 51, 37, 17, 16, 42, 13, 163, 195, 1, 89, 176, 21, 219, 243, 57, 98, 225, 160, 22, 127, 211, 123, 208, 94, 216, 35, 37, 92, 167, 132, 20, 80, 100, 139, 170, 175, 70, 75, 237, 140, 126, 28, 232, 76, 239, 172, 225, 34, 41, 9, 168, 255, 181, 109, 45, 69, 184, 43, 204, 96, 181, 52, 68, 42, 223, 240, 160, 45, 41, 233, 84, 141, 1, 51, 19, 69, 76, 148, 248, 137, 128, 68, 77, 179, 249, 160, 21, 192, 92, 113, 11, 164, 25, 54, 27, 237, 37, 106, 47, 180, 115, 95, 138, 94, 158, 35, 140, 146, 39, 172, 48, 163, 236, 64, 162, 142, 11, 181, 54, 152, 226, 56, 128, 17, 70, 253, 48, 235, 88, 96, 147, 218, 246, 39, 162, 230, 102, 78, 108, 51, 78, 9, 194, 10, 107, 152, 38, 51, 198, 155, 98, 245, 99, 187, 91, 123, 85, 166, 14, 13, 74, 15, 250, 28, 30, 130, 235, 37, 82, 179, 206, 246, 156, 176, 213, 26, 64, 142, 146, 7, 27, 4, 168, 235, 174, 249, 149, 216, 51, 246, 56, 224, 157, 194, 220, 81, 127, 132, 90, 54, 163, 130, 227, 106, 119, 103, 104, 101, 147, 165, 86, 236, 154, 74, 255, 132, 111, 105, 156, 41, 41, 234, 201, 46, 6, 133, 71, 66, 154, 87, 18, 10, 127, 191, 6, 191, 62, 52, 241, 144, 254, 243, 89, 163, 193, 219, 20, 21, 226, 104, 106, 105, 3, 41, 64, 64, 109, 44, 32, 238, 54, 74, 118, 209, 197, 150, 123, 209, 65, 210, 44, 160, 236, 231, 85, 104, 63, 201, 169, 94, 29, 24, 115, 189, 207, 132, 208, 177, 61, 129, 40, 170, 54, 252, 44, 76, 12, 156, 203, 185, 33, 138, 22, 143, 43, 228, 101, 64, 229, 150, 242, 176, 132, 117, 0, 114, 211, 177, 98, 154, 100, 59, 143, 228, 190, 225, 157, 242, 36, 225, 157, 38, 252, 158, 30, 168, 12, 115, 214, 1, 170, 66, 53, 134, 65, 103, 116, 114, 125, 171, 87, 203, 137, 81, 147, 68, 214, 157, 220, 28, 222, 162, 25, 164, 161, 168, 185, 73, 44, 40, 89, 85, 154, 161, 227, 239, 134, 185, 189, 188, 251, 119, 145, 213, 122, 213, 139, 205, 207, 35, 111, 18, 85, 131, 92, 2, 66, 144, 90, 34, 200, 126, 5, 71, 208, 117, 41, 216, 169, 196, 197, 135, 33, 81, 139, 2, 139, 220, 7, 161, 181, 51, 77, 62, 84, 47, 139, 250, 238, 44, 8, 132, 223, 229, 103, 242, 204, 208, 109, 12, 139, 171, 246, 68, 155, 87, 235, 169, 26, 220, 112, 233, 139, 99, 86, 205, 212, 160, 220, 46, 112, 215, 188, 33, 14, 213, 196, 143, 199, 129, 234, 52, 15, 102, 65, 109, 24, 86, 100, 177, 104, 13, 187, 0, 167, 12, 137, 64, 6, 18, 17, 97, 111, 86, 146, 180, 151, 154, 84, 88, 154, 229, 207, 33, 116, 176, 116, 96, 91, 80, 240, 50, 106, 185, 65, 26, 52, 123, 226, 221, 173, 101, 174, 69, 224, 196, 54, 76, 68, 35, 4, 56, 199, 174, 211, 251, 124, 229, 0, 23, 84, 101, 208, 254, 114, 189, 222, 120, 243, 208, 242, 165, 6, 4, 108, 152, 251, 175, 83, 6, 148, 242, 37, 110, 32, 159, 166, 190, 86, 12, 198, 150, 174, 178, 151, 104, 145, 47, 48, 36, 18, 93, 24, 158, 146, 95, 228, 229, 179, 193, 126, 102, 155, 131, 87, 209, 68, 186, 149, 61, 191, 49, 87, 181, 130, 226, 4, 25, 244, 74, 249, 90, 157, 249, 2, 205, 14, 185, 166, 147, 90, 15, 159, 221, 167, 44, 188, 141, 118, 197, 239, 251, 142, 52, 11, 63, 227, 110, 9, 252, 22, 233, 126, 70, 70, 229, 29, 75, 153, 191, 117, 16, 110, 173, 96, 212, 7, 29, 208, 243, 247, 166, 171, 104, 63, 193, 37, 101, 5, 54, 48, 231, 248, 2, 47, 202, 146, 143, 112, 183, 226, 247, 193, 114, 39, 9, 167, 149, 91, 47, 15, 75, 52, 42, 89, 245, 98, 221, 174, 164, 120, 108, 73, 122, 149, 17, 113, 34, 63, 108, 43, 67, 139, 239, 195, 121, 109, 199, 111, 134, 102, 1, 156, 170, 92, 3, 226, 6, 217, 217, 141, 105, 134, 45, 91, 37, 165, 30, 77, 180, 129, 1, 174, 52, 251, 153, 74, 250, 228, 252, 208, 142, 253, 19, 41, 55, 0, 255, 237, 11, 94, 110, 28, 33, 203, 180, 84, 234, 98, 2, 231, 200, 236, 194, 135, 103, 13, 95, 110, 220, 229, 56, 65, 4, 136, 82, 48, 134, 158, 131, 233, 179, 236, 206, 68, 216, 151, 106, 185, 218, 7, 201, 224, 43, 48, 225, 144, 103, 61, 158, 214, 207, 66, 156, 13, 146, 44, 49, 170, 156, 69, 134, 225, 38, 31, 240, 243, 136, 246, 83, 139, 127, 42, 225, 189, 87, 154, 96, 152, 164, 29, 19, 60, 106, 169, 36, 77, 165, 107, 75, 65, 75, 177, 189, 221, 30, 125, 212, 24, 229, 106, 12, 162, 140, 125, 178, 187, 251, 55, 39, 71, 110, 11, 113, 6, 75, 26, 233, 13, 50, 102, 209, 233, 73, 145, 2, 124, 40, 236, 65, 30, 183, 140, 63, 134, 143, 126 }, null, new byte[] { 3, 48, 208, 104, 37, 154, 177, 231, 174, 199, 157, 99, 61, 144, 22, 62, 192, 43, 171, 11, 32, 11, 139, 165, 110, 109, 217, 47, 151, 160, 234, 206, 81, 88, 172, 38, 97, 140, 37, 18, 187, 77, 166, 101, 108, 94, 59, 149, 94, 214, 82, 72, 31, 29, 150, 220, 88, 141, 100, 153, 216, 194, 48, 136 } });

            migrationBuilder.InsertData(
                table: "xUserGroups",
                columns: new[] { "UserId", "GroupId" },
                values: new object[] { new Guid("b13f0125-3252-4f3c-9721-43b88ece43e5"), new Guid("5d52ad35-a76b-427d-a5b2-0a650e285644") });

            migrationBuilder.InsertData(
                table: "xUserGroups",
                columns: new[] { "UserId", "GroupId" },
                values: new object[] { new Guid("b13f0125-3252-4f3c-9721-43b88ece43e5"), new Guid("cdba21fe-cbe9-4939-8ff4-e1854e574c22") });

            migrationBuilder.CreateIndex(
                name: "IX_eGroups_Name",
                table: "eGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_eUsers_Email",
                table: "eUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_xUserGroups_GroupId",
                table: "xUserGroups",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "xUserGroups");

            migrationBuilder.DropTable(
                name: "eGroups");

            migrationBuilder.DropTable(
                name: "eUsers");
        }
    }
}
