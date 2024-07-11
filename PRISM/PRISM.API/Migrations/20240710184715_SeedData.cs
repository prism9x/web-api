using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PRISM.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c3042129-aeb0-40fb-8406-74039e81e7f3"), "Hard" },
                    { new Guid("e3b3b61e-894d-4f41-a1b1-87efc5c526a4"), "Easy" },
                    { new Guid("ffa84219-5315-46b6-a3c2-724c22fe5004"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("041e5528-e2a1-4864-b1dd-03358ca540f3"), "HNC", "Hà Nội", "https://picsum.photos/200/300" },
                    { new Guid("23e92c3d-6c5a-467c-9c11-7a0cced1c9fb"), "HCM", "Hồ Chí Minh", "https://picsum.photos/200/300" },
                    { new Guid("53030a9a-4557-40ca-8808-82c9a36d14bc"), "DNC", "Đà Nẵng", "https://picsum.photos/200/300" },
                    { new Guid("98f959d9-7399-4f63-be6d-96d1f53bbda6"), "BNC", "Bắc Ninh", "https://picsum.photos/200/300" },
                    { new Guid("ef49d302-eb51-4fed-be02-18885af45742"), "VTC", "Vũng Tàu", "https://picsum.photos/200/300" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("c3042129-aeb0-40fb-8406-74039e81e7f3"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("e3b3b61e-894d-4f41-a1b1-87efc5c526a4"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("ffa84219-5315-46b6-a3c2-724c22fe5004"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("041e5528-e2a1-4864-b1dd-03358ca540f3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("23e92c3d-6c5a-467c-9c11-7a0cced1c9fb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("53030a9a-4557-40ca-8808-82c9a36d14bc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("98f959d9-7399-4f63-be6d-96d1f53bbda6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ef49d302-eb51-4fed-be02-18885af45742"));
        }
    }
}