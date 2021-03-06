﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingSoldier.Migrations
{
    public partial class AddPostUrltoPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostUrl",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostUrl",
                table: "Posts");
        }
    }
}
