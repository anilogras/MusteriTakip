using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusteriTakip.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AdSoyad = table.Column<string>(maxLength: 40, nullable: false),
                    Aktif = table.Column<bool>(nullable: false, defaultValue: true),
                    Cinsiyet = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsletmeAdi = table.Column<string>(maxLength: 100, nullable: false),
                    IsletmeYetkilisi = table.Column<string>(maxLength: 50, nullable: false),
                    Aktif = table.Column<bool>(nullable: false, defaultValue: true),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ilceler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sehir = table.Column<int>(nullable: false),
                    IlceAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilceler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iller",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sehir = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KDVs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KDVOrani = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KDVs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CariCep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(nullable: false),
                    Cep = table.Column<string>(type: "char(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariCep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariCep_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CariEMails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(nullable: false),
                    EMail = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariEMails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariEMails_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CariFaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(nullable: false),
                    Fax = table.Column<string>(type: "char(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariFaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariFaxes_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CariTelefons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(nullable: false),
                    Telefon = table.Column<string>(type: "char(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariTelefons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariTelefons_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CariVds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(nullable: false),
                    Unvan = table.Column<string>(maxLength: 100, nullable: true),
                    VDNo = table.Column<string>(type: "char(11)", nullable: true),
                    VdDairesi = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariVds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariVds_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CariWebSites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(nullable: false),
                    WebSite = table.Column<string>(type: "char(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariWebSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariWebSites_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fislers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    OnOdeme = table.Column<double>(nullable: false),
                    FisNot = table.Column<string>(maxLength: 50, nullable: true),
                    FisNo = table.Column<int>(nullable: false),
                    Faturalandir = table.Column<bool>(nullable: false, defaultValue: false),
                    FisKullanicisi = table.Column<string>(maxLength: 40, nullable: false),
                    Silindimi = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fislers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fislers_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fislers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CariAdresCaris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(nullable: false),
                    Adres = table.Column<string>(maxLength: 250, nullable: true),
                    IlId = table.Column<int>(nullable: false),
                    IlceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariAdresCaris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariAdresCaris_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CariAdresCaris_Iller_IlId",
                        column: x => x.IlId,
                        principalTable: "Iller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CariAdresCaris_Ilceler_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilceler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FisOzelliks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FisId = table.Column<int>(nullable: false),
                    FisOzellikId = table.Column<int>(nullable: false),
                    Tanim = table.Column<string>(maxLength: 20, nullable: true),
                    Adet = table.Column<int>(nullable: true),
                    Aciklama = table.Column<string>(maxLength: 50, nullable: true),
                    Olcu = table.Column<string>(maxLength: 20, nullable: true),
                    Fiyat = table.Column<double>(nullable: true),
                    KDV = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FisOzelliks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FisOzelliks_Fislers_FisId",
                        column: x => x.FisId,
                        principalTable: "Fislers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OzellikDurums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FisOzellikId = table.Column<int>(nullable: false),
                    TasarimTarih = table.Column<DateTime>(nullable: true),
                    BaskiTarih = table.Column<DateTime>(nullable: true),
                    UygulamaTarih = table.Column<DateTime>(nullable: true),
                    TeslimTarih = table.Column<DateTime>(nullable: true),
                    Tasarim = table.Column<bool>(nullable: false, defaultValue: false),
                    Baski = table.Column<bool>(nullable: false, defaultValue: false),
                    Uygulama = table.Column<bool>(nullable: false, defaultValue: false),
                    Teslimat = table.Column<bool>(nullable: false, defaultValue: false)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CariAdresCaris_CariId",
                table: "CariAdresCaris",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariAdresCaris_IlId",
                table: "CariAdresCaris",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_CariAdresCaris_IlceId",
                table: "CariAdresCaris",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_CariCep_CariId",
                table: "CariCep",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariEMails_CariId",
                table: "CariEMails",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariFaxes_CariId",
                table: "CariFaxes",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariTelefons_CariId",
                table: "CariTelefons",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariVds_CariId",
                table: "CariVds",
                column: "CariId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CariWebSites_CariId",
                table: "CariWebSites",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_Fislers_CariId",
                table: "Fislers",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_Fislers_UserId",
                table: "Fislers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FisOzelliks_FisId",
                table: "FisOzelliks",
                column: "FisId");

            migrationBuilder.CreateIndex(
                name: "IX_OzellikDurums_FisOzellikId",
                table: "OzellikDurums",
                column: "FisOzellikId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CariAdresCaris");

            migrationBuilder.DropTable(
                name: "CariCep");

            migrationBuilder.DropTable(
                name: "CariEMails");

            migrationBuilder.DropTable(
                name: "CariFaxes");

            migrationBuilder.DropTable(
                name: "CariTelefons");

            migrationBuilder.DropTable(
                name: "CariVds");

            migrationBuilder.DropTable(
                name: "CariWebSites");

            migrationBuilder.DropTable(
                name: "KDVs");

            migrationBuilder.DropTable(
                name: "OzellikDurums");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Iller");

            migrationBuilder.DropTable(
                name: "Ilceler");

            migrationBuilder.DropTable(
                name: "FisOzelliks");

            migrationBuilder.DropTable(
                name: "Fislers");

            migrationBuilder.DropTable(
                name: "Caris");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
