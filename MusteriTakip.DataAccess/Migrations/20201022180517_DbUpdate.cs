using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusteriTakip.DataAccess.Migrations
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OzellikDurums");

            migrationBuilder.AddColumn<int>(
                name: "Durum",
                table: "FisOzelliks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Durum",
                table: "FisOzelliks");

            migrationBuilder.CreateTable(
                name: "OzellikDurums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baski = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    BaskiTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FisOzellikId = table.Column<int>(type: "int", nullable: false),
                    Tasarim = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TasarimTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TeslimTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Teslimat = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Uygulama = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UygulamaTarih = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OzellikDurums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OzellikDurums_FisOzelliks_FisOzellikId",
                        column: x => x.FisOzellikId,
                        principalTable: "FisOzelliks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OzellikDurums_FisOzellikId",
                table: "OzellikDurums",
                column: "FisOzellikId",
                unique: true);
        }
    }
}
