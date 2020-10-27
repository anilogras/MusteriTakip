using Microsoft.EntityFrameworkCore.Migrations;

namespace MusteriTakip.DataAccess.Migrations
{
    public partial class DbUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FisOzellikId",
                table: "FisOzelliks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FisOzellikId",
                table: "FisOzelliks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
