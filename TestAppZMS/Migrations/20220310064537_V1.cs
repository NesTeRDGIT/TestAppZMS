using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAppZMS.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZGLV",
                columns: table => new
                {
                    ZGLV_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VERSION = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FILENAME = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    CODE = table.Column<int>(type: "int", nullable: false),
                    YEAR = table.Column<int>(type: "int", nullable: false),
                    MONTH = table.Column<int>(type: "int", nullable: false),
                    DAY = table.Column<int>(type: "int", nullable: false),
                    CODE_MO = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CODE_LPU = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZGLV", x => x.ZGLV_ID);
                });

            migrationBuilder.CreateTable(
                name: "ZAP",
                columns: table => new
                {
                    ZAP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZGLV_ID = table.Column<int>(type: "int", nullable: false),
                    N_ZAP = table.Column<int>(type: "int", nullable: false),
                    ID_PAC = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    VPOLIS = table.Column<int>(type: "int", nullable: true),
                    SPOLIS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NPOLIS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SMO = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ST_OKATO = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FAM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    OT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    W = table.Column<int>(type: "int", nullable: false),
                    DR = table.Column<int>(type: "int", nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    COMENTP = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZAP", x => x.ZAP_ID);
                    table.ForeignKey(
                        name: "FK_ZAP_ZGLV_ZGLV_ID",
                        column: x => x.ZGLV_ID,
                        principalTable: "ZGLV",
                        principalColumn: "ZGLV_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NPR",
                columns: table => new
                {
                    NPR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZAP_ID = table.Column<int>(type: "int", nullable: false),
                    IDNPR = table.Column<int>(type: "int", nullable: false),
                    NPR_NUM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FOR_POM = table.Column<int>(type: "int", nullable: false),
                    NPR_MO = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    NPR_LPU = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    DEST_MO = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DEST_LPU = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    DS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PODR = table.Column<int>(type: "int", nullable: true),
                    PROFIL = table.Column<int>(type: "int", nullable: false),
                    PROFK = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CODE_MD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PLAN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COMENTN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPR", x => x.NPR_ID);
                    table.ForeignKey(
                        name: "FK_NPR_ZAP_ZAP_ID",
                        column: x => x.ZAP_ID,
                        principalTable: "ZAP",
                        principalColumn: "ZAP_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NPR_ZAP_ID",
                table: "NPR",
                column: "ZAP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ZAP_ZGLV_ID",
                table: "ZAP",
                column: "ZGLV_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NPR");

            migrationBuilder.DropTable(
                name: "ZAP");

            migrationBuilder.DropTable(
                name: "ZGLV");
        }
    }
}
