using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsStore.DAL.Migrations
{
    public partial class check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailFeature",
                table: "DetailFeature");

            migrationBuilder.DropIndex(
                name: "IX_DetailFeature_FeatureId",
                table: "DetailFeature");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DetailFeature");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailFeature",
                table: "DetailFeature",
                columns: new[] { "FeatureId", "DetailId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailFeature",
                table: "DetailFeature");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "DetailFeature",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailFeature",
                table: "DetailFeature",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DetailFeature_FeatureId",
                table: "DetailFeature",
                column: "FeatureId");
        }
    }
}
