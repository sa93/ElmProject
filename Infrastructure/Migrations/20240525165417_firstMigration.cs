using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Book",
            //    columns: table => new
            //    {
            //        BookId = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BookInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Book", x => x.BookId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SchemaVersions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ScriptName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Applied = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SchemaVersions", x => x.Id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Book_LastModified",
            //    table: "Book",
            //    column: "LastModified");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Book");

            //migrationBuilder.DropTable(
            //    name: "SchemaVersions");
        }
    }
}
