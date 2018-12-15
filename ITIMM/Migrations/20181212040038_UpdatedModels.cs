using Microsoft.EntityFrameworkCore.Migrations;

namespace ITIMM.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CostCenter",
                table: "Assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Spec",
                table: "Assets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostCenter",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Spec",
                table: "Assets");
        }
    }
}
