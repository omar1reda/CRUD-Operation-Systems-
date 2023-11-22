using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoDAL.Migrations
{
    public partial class RelationShepe1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Depurtments_DepurtmentId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepurtmentId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Depurtments_DepurtmentId",
                table: "Employees",
                column: "DepurtmentId",
                principalTable: "Depurtments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Depurtments_DepurtmentId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepurtmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Depurtments_DepurtmentId",
                table: "Employees",
                column: "DepurtmentId",
                principalTable: "Depurtments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
