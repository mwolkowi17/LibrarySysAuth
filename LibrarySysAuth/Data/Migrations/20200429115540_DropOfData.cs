﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySysAuth.Data.Migrations
{
    public partial class DropOfData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DropOfData",
                table: "BookC",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropOfData",
                table: "BookC");
        }
    }
}
