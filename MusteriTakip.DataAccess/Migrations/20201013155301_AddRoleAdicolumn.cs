using Microsoft.EntityFrameworkCore.Migrations;

namespace MusteriTakip.DataAccess.Migrations
{
    public partial class AddRoleAdicolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RolAdi",
                table: "AspNetRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RolAdi",
                table: "AspNetRoles");
        }
    }
}
