using Microsoft.EntityFrameworkCore.Migrations;

namespace TelefoniaWooza.Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DDDs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operadoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operadoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: false),
                    Minutos = table.Column<int>(nullable: false),
                    FranquiaInternet = table.Column<float>(nullable: false),
                    Valor = table.Column<float>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Operadora = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DDDPlanos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDDId = table.Column<int>(nullable: false),
                    PlanoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDDPlanos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DDDPlanos_DDDs_DDDId",
                        column: x => x.DDDId,
                        principalTable: "DDDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DDDPlanos_Planos_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DDDPlanos_DDDId",
                table: "DDDPlanos",
                column: "DDDId");

            migrationBuilder.CreateIndex(
                name: "IX_DDDPlanos_PlanoId_DDDId",
                table: "DDDPlanos",
                columns: new[] { "PlanoId", "DDDId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DDDs_Sigla",
                table: "DDDs",
                column: "Sigla",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operadoras_Nome",
                table: "Operadoras",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DDDPlanos");

            migrationBuilder.DropTable(
                name: "Operadoras");

            migrationBuilder.DropTable(
                name: "DDDs");

            migrationBuilder.DropTable(
                name: "Planos");
        }
    }
}
