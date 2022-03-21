using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assessment.Migrations
{
    public partial class CreateUpdatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDatetime",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IpAdres",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDatetime",
                table: "Persons",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDatetime",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IpAdres",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UpdateDatetime",
                table: "Persons");
        }
    }
}
