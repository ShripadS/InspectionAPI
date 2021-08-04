using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Inspectors_InspectorID",
                schema: "dbo",
                table: "Inspections");

            migrationBuilder.DropIndex(
                name: "IX_Inspections_InspectorID",
                schema: "dbo",
                table: "Inspections");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectedOn",
                schema: "dbo",
                table: "Inspections",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectedOn",
                schema: "dbo",
                table: "Inspections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_InspectorID",
                schema: "dbo",
                table: "Inspections",
                column: "InspectorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Inspectors_InspectorID",
                schema: "dbo",
                table: "Inspections",
                column: "InspectorID",
                principalSchema: "dbo",
                principalTable: "Inspectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
