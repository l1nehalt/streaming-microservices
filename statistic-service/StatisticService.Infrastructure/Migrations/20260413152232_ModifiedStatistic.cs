using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StatisticService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedStatistic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Statistics",
                table: "Statistics");

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Statistics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statistics",
                table: "Statistics",
                columns: new[] { "TrackId", "PlayCount" });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "PlayCount", "TrackId" },
                values: new object[,]
                {
                    { 3131, 3 },
                    { 33123, 33 },
                    { 10931, 49 },
                    { 5543, 76 },
                    { 122, 102 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Statistics",
                table: "Statistics");

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumns: new[] { "PlayCount", "TrackId" },
                keyValues: new object[] { 3131, 3 });

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumns: new[] { "PlayCount", "TrackId" },
                keyValues: new object[] { 33123, 33 });

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumns: new[] { "PlayCount", "TrackId" },
                keyValues: new object[] { 10931, 49 });

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumns: new[] { "PlayCount", "TrackId" },
                keyValues: new object[] { 5543, 76 });

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumns: new[] { "PlayCount", "TrackId" },
                keyValues: new object[] { 122, 102 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Statistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statistics",
                table: "Statistics",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "Id", "PlayCount", "TrackId" },
                values: new object[,]
                {
                    { 1, 3131, 3 },
                    { 2, 33123, 33 },
                    { 3, 10931, 49 },
                    { 4, 5543, 76 },
                    { 5, 122, 102 }
                });
        }
    }
}
