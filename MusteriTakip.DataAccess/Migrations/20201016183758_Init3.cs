using Microsoft.EntityFrameworkCore.Migrations;

namespace MusteriTakip.DataAccess.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FisNo",
                table: "Fislers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FisNo",
                table: "Fislers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
