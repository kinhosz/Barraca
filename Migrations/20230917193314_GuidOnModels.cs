using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace barraca.Migrations
{
    /// <inheritdoc />
    public partial class GuidOnModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Uuid",
                table: "Replenishments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Uuid",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Uuid",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Replenishments");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Orders");
        }
    }
}
