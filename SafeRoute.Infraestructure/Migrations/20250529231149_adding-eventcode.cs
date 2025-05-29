﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeRoute.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class addingeventcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventCode",
                table: "Events",
                type: "NVARCHAR2(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventCode",
                table: "Events");
        }
    }
}
