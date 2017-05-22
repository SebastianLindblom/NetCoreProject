using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CloudburryNet.Data.Migrations
{
    public partial class UpdateDatamodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Post",
                newName: "Width");

            migrationBuilder.AddColumn<string>(
                name: "Visible",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRelatedPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelationType = table.Column<string>(nullable: true),
                    UserPostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRelatedPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRelatedPost_UserPost_UserPostId",
                        column: x => x.UserPostId,
                        principalTable: "UserPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRelatedPost_UserPostId",
                table: "UserRelatedPost",
                column: "UserPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRelatedPost");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Post",
                newName: "Length");
        }
    }
}
