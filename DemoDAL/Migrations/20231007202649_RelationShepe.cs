using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoDAL.Migrations
{
    public partial class RelationShepe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepurtmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepurtmentId",
                table: "Employees",
                column: "DepurtmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Depurtments_DepurtmentId",
                table: "Employees",
                column: "DepurtmentId",
                principalTable: "Depurtments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Depurtments_DepurtmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepurtmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepurtmentId",
                table: "Employees");
        }
    }
}
