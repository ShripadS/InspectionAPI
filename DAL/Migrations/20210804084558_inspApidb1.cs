using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class inspApidb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Inspectors_InspectorID",
                schema: "dbo",
                table: "Inspections");

            migrationBuilder.DropIndex(
                name: "IX_Inspections_InspectorID",
                schema: "dbo",
                table: "Inspections");
        }
    }
}
