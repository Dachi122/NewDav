using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewDav.Migrations
{
    public partial class AddDateTimeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Ambebis",
                type: "DateTime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Ambebis");
        }
    }
}
