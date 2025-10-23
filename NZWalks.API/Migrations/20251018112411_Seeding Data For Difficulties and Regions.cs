using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5c516eec-c4f0-4b0b-9af7-799f881bcfca"), "Easy" },
                    { new Guid("95d87504-2845-4693-98b3-4b052b817e54"), "Medium" },
                    { new Guid("c0f57b50-cdcf-4597-8b8b-721127e68f1a"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0dbb8f1f-59e4-4a92-b77a-a0224842897d"), "WRS", "Warsaw", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photos-vectors%2Fimagem&psig=AOvVaw1-RxayNMuCv7Un0jXyokNv&ust=1760872815555000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCPDNlsjQrZADFQAAAAAdAAAAABAE" },
                    { new Guid("3b9f4bfb-6419-4f4c-b81d-1b14eb7204e6"), "NRT", "Northland", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photos-vectors%2Fimagem&psig=AOvVaw1-RxayNMuCv7Un0jXyokNv&ust=1760872815555000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCPDNlsjQrZADFQAAAAAdAAAAABAE" },
                    { new Guid("b13cf54a-6f5c-4613-8ce3-f944e74a0c56"), "ASKL", "ASuckland", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photos-vectors%2Fimagem&psig=AOvVaw1-RxayNMuCv7Un0jXyokNv&ust=1760872815555000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCPDNlsjQrZADFQAAAAAdAAAAABAE" },
                    { new Guid("cf7bca57-d87d-4a30-814c-0e8b5f1eafc9"), "NY", "New York", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photos-vectors%2Fimagem&psig=AOvVaw1-RxayNMuCv7Un0jXyokNv&ust=1760872815555000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCPDNlsjQrZADFQAAAAAdAAAAABAE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5c516eec-c4f0-4b0b-9af7-799f881bcfca"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("95d87504-2845-4693-98b3-4b052b817e54"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c0f57b50-cdcf-4597-8b8b-721127e68f1a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0dbb8f1f-59e4-4a92-b77a-a0224842897d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3b9f4bfb-6419-4f4c-b81d-1b14eb7204e6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b13cf54a-6f5c-4613-8ce3-f944e74a0c56"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cf7bca57-d87d-4a30-814c-0e8b5f1eafc9"));
        }
    }
}
